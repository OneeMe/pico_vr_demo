
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerSwitch : MonoBehaviour
{
  [Tooltip("First Controller to use")]
  public List<GameObject> controllerRelatedObjects = new List<GameObject>();


  [Tooltip("Second Controller to use")]
  public List<GameObject> handRelatedObjects = new List<GameObject>();


  public void Toogle()
  {
    if (controllerRelatedObjects.TrueForAll(x => x.activeSelf))
    {
      controllerRelatedObjects.ForEach(x => x.SetActive(false));
      handRelatedObjects.ForEach(x => x.SetActive(true));
    }
    else
    {
      controllerRelatedObjects.ForEach(x => x.SetActive(true));
      handRelatedObjects.ForEach(x => x.SetActive(false));
    }
  }

}
