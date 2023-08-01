using System.Collections;
using System.Collections.Generic;
using Unity.XR.PXR;
using UnityEngine;
using static Unity.XR.PXR.PXR_Input;

public class HapticsFor : MonoBehaviour
{
  public void HapticFor(float duration)
  {
    int durationInMs = (int)(duration * 1000);
    PXR_Input.SendHapticImpulse(VibrateType.RightController, 0.5f, durationInMs, 100);
    PXR_Input.SendHapticImpulse(VibrateType.LeftController, 0.5f, durationInMs, 100);
    Invoke("stop", duration);
  }

  private void stop()
  {
    PXR_Input.SendHapticImpulse(VibrateType.RightController, 0.0f, 0, 100);
    PXR_Input.SendHapticImpulse(VibrateType.LeftController, 0.0f, 0, 100);
  }
}
