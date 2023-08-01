using Unity.XR.PXR;
using UnityEngine;
using UnityEngine.XR;

public class SeeThroughControl : MonoBehaviour
{

    private bool primaryButton;
    private bool secondaryButton;
    private bool currentState;

    private void Awake()
    {
        PXR_Boundary.EnableSeeThroughManual(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        InputDevices.GetDeviceAtXRNode(XRNode.RightHand).TryGetFeatureValue(CommonUsages.primaryButton, out primaryButton);
        InputDevices.GetDeviceAtXRNode(XRNode.RightHand).TryGetFeatureValue(CommonUsages.secondaryButton, out secondaryButton);

        if (primaryButton == true)
        {
            PXR_Boundary.EnableSeeThroughManual(true);
            currentState = true;
        }

        if (secondaryButton == true)
        {
            PXR_Boundary.EnableSeeThroughManual(false);
            currentState = false;
        }
    }

    private void OnApplicationPause(bool pause)
    {
        if (!pause)
        {
            PXR_Boundary.EnableSeeThroughManual(currentState);
        }
    }
}
