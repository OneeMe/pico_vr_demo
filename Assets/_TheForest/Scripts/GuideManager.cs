using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideManager : MonoBehaviour
{

  public GameObject target;
  public GameObject Guide;
  // Start is called before the first frame update
  void Start()
  {
    if (target == null)
    {
      target = Camera.main.gameObject;
    }
  }

  // Update is called once per frame
  void Update()
  {
    // calculate the distance between the target and the this object
    float distance = Vector3.Distance(target.transform.position, this.transform.position);
    // print the distance to the console
    // Debug.Log("Distance: " + distance);
    // if distance is less than 1.5, then set the object to active
    if (distance < 5.0f)
    {
      Guide.SetActive(true);
    }
    else
    {
      Guide.SetActive(false);
    }
  }

}
