using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 用于和指定物体保持距离，并保持看向指定物体
/// </summary>
public class KeepDistance : MonoBehaviour
{

  public float distance = 10;

  public bool isLookAt = true;

  public Transform target;

  void Update()
  {
    if (target.transform == null)
    {
      return;
    }
    // keep current object's height is heigher than target
    transform.position = new Vector3(transform.position.x, target.transform.transform.position.y + 5, transform.position.z);
    if (isLookAt)
    {
      // make current object look at target
      transform.LookAt(target.transform.transform.position);
      // invert the rotation because the object should face the target
      transform.rotation *= Quaternion.Euler(0, 180f, 0);
    }
    // Get the position of the target
    Vector3 targetPos = target.transform.position;
    // Calculate the direction from the camera to this object
    Vector3 direction = transform.position - targetPos;
    // Normalize the direction vector and multiply it by the desired distance
    transform.position = targetPos + direction.normalized * distance;
  }
}
