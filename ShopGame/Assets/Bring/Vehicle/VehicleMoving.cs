using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class VehicleMoving : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] private float rightBound;
    [SerializeField] private float leftBound;

    [SerializeField] private CameraManager cameraManager;
    private float direction = 1;
    public enum State
    {
        Normal,
        Driving
    }
    
    void Start()
    {
        spriteRenderer.flipX = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            cameraManager.SwitchCamera(cameraManager.vehicleCamera);
        }
        if (Input.GetKeyDown(KeyCode.L)) {
            cameraManager.SwitchCamera(cameraManager.cityCamera);

        }
    }

    private void FixedUpdate()
    {
        float moveSpeed = 10;

        transform.Translate(Vector3.right * moveSpeed * direction * Time.deltaTime);
        if (transform.position.x >= rightBound)
        {
            direction = -1;
            spriteRenderer.flipX = false;

        } else if (transform.position.x <= leftBound)
        {
            direction = 1;
            spriteRenderer.flipX = true;
        }

    }
}
