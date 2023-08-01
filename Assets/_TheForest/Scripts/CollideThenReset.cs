using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideThenReset : MonoBehaviour
{
  public Transform resetTraget;

  public string collideTag = "Land";

  // Update is called once per frame
  void OnCollisionEnter(Collision other)
  {
    if (other.gameObject.tag == collideTag)
    {
      transform.position = resetTraget.position;
    }
  }
}
