using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
  public Transform followTarget;

  public float yOffset = 0.0f;

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    transform.position = new Vector3(followTarget.position.x, followTarget.position.y + yOffset, followTarget.transform.position.z);
    transform.eulerAngles = new Vector3(0, followTarget.eulerAngles.y, 0);
  }
}
