using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugManager : MonoBehaviour
{
  public bool isDebug;

  // Start is called before the first frame update
  void OnEnable()
  {
    SetupEditorOnly();
    SetupDebugOnly();
  }

  private void SetupEditorOnly()
  {
    GameObject[] editorOnlyObjects = GameObject.FindGameObjectsWithTag("EditorOnly");
    Debug.Log("editorOnlyObjects length is " + editorOnlyObjects.Length);
    var isEnable = false;
    // log current platform
    Debug.Log("Current Platform: " + Application.platform);
    if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor)
    {
      isEnable = true;
    }
    else
    {
      isEnable = false;
    }
    foreach (GameObject obj in editorOnlyObjects)
    {
      Debug.Log("current obj is " + obj.name);
      obj.SetActive(isEnable);
    }
  }

  private void SetupDebugOnly()
  {
    GameObject[] debugOnlyObjects = GameObject.FindGameObjectsWithTag("Debug");
    Debug.Log("debugOnlyObjects length is " + debugOnlyObjects.Length);
    var isEnable = false;
    // log current is debug or release
    Debug.Log("Is Debug: " + isDebug);
    if (isDebug)
    {
      isEnable = true;
    }
    else
    {
      isEnable = false;
    }
    foreach (GameObject obj in debugOnlyObjects)
    {
      obj.SetActive(isEnable);
    }
  }
}
