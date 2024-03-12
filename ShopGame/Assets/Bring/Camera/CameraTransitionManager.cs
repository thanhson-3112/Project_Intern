using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraTransitionManager : MonoBehaviour
{
    public Camera mainCamera;
    public Camera vehicleCamera;
    // Start is called before the first frame update
    private void Start()
    {
        vehicleCamera.enabled = false;
    }

    public void TransitionToMainCamera()
    {
        mainCamera.enabled = true;
        vehicleCamera.enabled = false;
    }

    public void TransitionToVehicleCamera()
    {
        mainCamera.enabled = false;     
        vehicleCamera.enabled = true;
    }
}
