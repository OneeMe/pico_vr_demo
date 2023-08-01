using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(GameManager))]

public class GhostSpawnArea : MonoBehaviour
{

  private GameManager gameManager;

  public int maxGhostCount; // 最大幽灵数
  public float spawnInterval; // 生成间隔时间
  public GameObject ghostPrefab; // 幽灵预制体

  private float durationSinceLastSpawn; // 计时器
  private int currentGhostCount; // 当前幽灵数

  public float radius = 2.0f; // 幽灵生成范围

  void Start()
  {
    gameManager = GetComponent<GameManager>();
    gameManager.endGameAction += EndGame;
  }

  private void Update()
  {
    if (!gameManager.isGamePlaying())
    {
      return;
    }

    if (currentGhostCount >= maxGhostCount)
    {
      // 幽灵数已到最大值，停止生成
      return;
    }
    // 每隔spawnInterval秒尝试生成一只幽灵
    durationSinceLastSpawn += Time.deltaTime;
    if (durationSinceLastSpawn >= spawnInterval)
    {
      durationSinceLastSpawn = 0;
      GenerateGhost();
    }
  }

  private void EndGame()
  {
    // 销毁所有的 Ghost 对象
    GameObject[] ghosts = GameObject.FindGameObjectsWithTag("Ghost");
    foreach (GameObject ghost in ghosts)
    {
      Destroy(ghost);
    }
  }

  private void GenerateGhost()
  {
    Transform targetTransform = transform;
    // 在GhostSpawnArea周围随机一个位置生成幽灵
    Vector3 spawnPosition = targetTransform.position + UnityEngine.Random.insideUnitSphere * radius;
    GameObject ghost = Instantiate(ghostPrefab, spawnPosition, Quaternion.identity, this.transform);
    // 更新当前幽灵数
    currentGhostCount++;
    // 当幽灵被消除时，减少当前幽灵数
    ghost.GetComponent<Ghost>().GhostDestroyed += () => currentGhostCount--;
  }

  private void OnDrawGizmosSelected()
  {
    // 在编辑器场景中绘制出GhostSpawnArea的范围
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(transform.position, radius);
  }
}
