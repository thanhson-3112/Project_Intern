using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;
    public CinemachineVirtualCamera[] cameras;

    public CinemachineVirtualCamera cityCamera;
    public CinemachineVirtualCamera vehicleCamera;

    public CinemachineVirtualCamera startCamera;
    private CinemachineVirtualCamera currentCamera;

    void Start()
    {
        startCamera = currentCamera;

        for (int i = 0; i < cameras.Length; i++)
        {
            if (cameras[i] == currentCamera)
            {
                cameras[i].Priority = 20;
            }else
            {
                cameras[i].Priority = 10;
            }
        }
    }

    public void SwitchCamera(CinemachineVirtualCamera newCamera)
    {
        currentCamera = newCamera;

        currentCamera.Priority = 20;

        for(int i = 0; i < cameras.Length; i++)
        {
            if (cameras[i] != currentCamera)
            {
                cameras[i].Priority = 10;
            }
        }
    }
}
