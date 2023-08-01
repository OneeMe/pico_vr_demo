using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
  public Camera mainCamera;
  //旋转角度
  private float xRotation = 0.0f;
  private float yRotation = 0.0f;

  // Start is called before the first frame update
  void Start()
  {
    if (mainCamera == null)
    {
      mainCamera = Camera.main;
    }

    if (mainCamera == null)
    {
      Debug.LogError("camera get error, there is no camera taged MainCamera");
    }
    else
    {
      Debug.Log("camera get success");
    }
  }

  // Update is called once per frame
  void Update()
  {
    if (mainCamera == null)
    {
      return;
    }
    if (Input.GetMouseButtonDown(0))
    {
      Cursor.lockState = CursorLockMode.Locked;
      Cursor.visible = false;
    }
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      Cursor.lockState = CursorLockMode.None;
      Cursor.visible = true;
    }

    if (Cursor.visible)
    {
      return;
    }

    if ((Input.mousePosition.x < 0) || (Input.mousePosition.y < 0) ||
        (Input.mousePosition.x > Screen.width) || (Input.mousePosition.y > Screen.height))
    {
      return;
    }

    if (Input.GetKey(KeyCode.W))
    {
      mainCamera.transform.Translate(Vector3.forward * Time.deltaTime * 10);
    }

    if (Input.GetKey(KeyCode.S))
    {
      mainCamera.transform.Translate(Vector3.back * Time.deltaTime * 10);
    }

    if (Input.GetKey(KeyCode.A))
    {
      mainCamera.transform.Translate(Vector3.left * Time.deltaTime * 10);
    }

    if (Input.GetKey(KeyCode.D))
    {
      mainCamera.transform.Translate(Vector3.right * Time.deltaTime * 10);
    }

    // 接受鼠标信息
    xRotation -= Input.GetAxis("Mouse X") * 5;
    yRotation += Input.GetAxis("Mouse Y") * 5;
    // 控制最大角度
    yRotation = ClampValue(yRotation, -20, 80);
    //camera.transform.rotation = Quaternion.Euler(-yRotation, -xRotation, 0);
    mainCamera.transform.localEulerAngles = new Vector3(-yRotation, -xRotation, 0);
  }

  float ClampValue(float value, float min, float max)
  {
    if (value < -360)
      value += 360;
    if (value > 360)
      value -= 360;
    return Mathf.Clamp(value, min, max);
  }
}
