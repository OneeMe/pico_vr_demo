using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class Ghost : MonoBehaviour
{
  // 定义 GhostDestroyed 事件
  public event Action GhostDestroyed;

  // 幽灵的移动速度
  public float speed = 5.0f;

  // 标记幽灵是否死亡
  bool isDead = false;

  // 幽灵对象
  Transform ghostTransform;

  GameObject player;

  public String collideTag = "Weapon";

  // 幽灵距离玩家的范围
  private float distanceRatio = 1.0f;

  // 在 Start() 方法中获取幽灵对象和动画播放器
  void Start()
  {
    player = Camera.main.gameObject;
    ghostTransform = transform;
    distanceRatio = UnityEngine.Random.Range(1.0f, 2.0f);
  }

  // 在 Update() 方法中更新幽灵的位置
  void Update()
  {
    // 如果幽灵死亡，销毁该对象并退出 Update() 方法
    if (isDead)
    {
      OnDestroy();
      Destroy(gameObject);
      return;
    }

    // 计算幽灵的目标位置（例如，靠近玩家）
    Vector3 targetPosition = player.transform.position;
    // 将幽灵的角度设置为面向玩家的角度
    ghostTransform.LookAt(targetPosition);
    // 如果幽灵在玩家下方，则将其Y轴位置设置为玩家的Y轴位置
    if (ghostTransform.position.y < player.transform.position.y)
    {
      Vector3 newPosition = new Vector3(ghostTransform.position.x, player.transform.position.y, ghostTransform.position.z);
      ghostTransform.position = newPosition;
    }

    // 使幽灵向目标位置靠近
    ghostTransform.position = Vector3.MoveTowards(ghostTransform.position, targetPosition, speed * Time.deltaTime);

    // 播放上下抖动动画
    float offset = Mathf.Sin(Time.time * 10.0f) * 0.001f;
    ghostTransform.position += new Vector3(0.0f, offset, 0.0f);

    // 获取所有幽灵的对象
    GameObject[] ghosts = GameObject.FindGameObjectsWithTag("Ghost");

    // 遍历所有幽灵，并确保它们之间不会重叠
    //在计算新位置时用了一个更加平滑的算法
    foreach (GameObject ghost in ghosts)
    {
      if (ghost != gameObject)// 排除当前幽灵自身
      {
        float distance = Vector3.Distance(ghostTransform.position, ghost.transform.position);

        if (distance < 1.0f)// 如果距离太近，调整位置
        {
          // Vector3 newPosition = ghostTransform.position + (ghostTransform.position - ghost.transform.position).normalized * (1.0f - distance);
          // ghostTransform.position = newPosition;

          // 当两个幽灵的距离小于 1.0f 时，你可以采用以下方式平滑地调整它们的位置，而不是直接设置新的位置
          // 这个算法会根据幽灵之间的距离差值来计算平滑移动的向量，同时还允许使用 deltaTime 来控制移动速度，使得幽灵之间的距离调整更加自然和平滑。
          Vector3 dir = (ghostTransform.position - ghost.transform.position).normalized;
          float moveDist = 1.0f - distance;
          Vector3 moveVector = dir * moveDist * moveDist * Time.deltaTime;

          ghostTransform.position += moveVector;
        }
      }
      // 避免和玩家重叠
      float playerDistance = Vector3.Distance(ghostTransform.position, player.transform.position);
      if (playerDistance < MinDistance())
      {
        Vector3 newPosition = ghostTransform.position + (ghostTransform.position - player.transform.position).normalized * (MinDistance() - playerDistance);
        ghostTransform.position = newPosition;
      }
    }
  }

  private float MinDistance()
  {
    return 0.3f * distanceRatio;
  }

  // 外部调用此方法使幽灵死亡
  public void Die()
  {
    // 标记幽灵为已死亡
    isDead = true;

    // 销毁幽灵
    Destroy(gameObject);
  }

  // 当对象被销毁时触发 GhostDestroyed 事件
  void OnDestroy()
  {
    if (GhostDestroyed != null)
    {
      GhostDestroyed();
    }
  }

  void OnTriggerEnter(Collider collider)
  {
    Debug.Log($"Ghot OnCollisionEnter, other is {collider.gameObject.tag}");
    if (collider.gameObject.tag == collideTag)
    {
      ScoreManager.instance.AddScore(1);
      Die();
    }
  }
}
