using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] private CameraTransitionManager cameraTransitionManager;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            SwitchCamera();
        }
    }

    public void SwitchCamera()
    {
        if (cameraTransitionManager.mainCamera.enabled)
        {
            cameraTransitionManager.TransitionToVehicleCamera();
        } else {
            cameraTransitionManager.TransitionToMainCamera();
        }

    }
}
