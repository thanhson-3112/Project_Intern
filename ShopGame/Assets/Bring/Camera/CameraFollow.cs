using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform followTarget;
    [SerializeField] private float smoothness;

    [SerializeField] private float xtargetOffset;
    [SerializeField] private float ytargetOffset;
    private void FixedUpdate() {
        if (followTarget != null)
        {
            // Calculate the desired camera position based on the target's position
            Vector3 targetPosition = new Vector3(followTarget.position.x + xtargetOffset, followTarget.position.y + ytargetOffset, transform.position.z);

            // Smoothly move the camera towards the desired position
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothness * Time.deltaTime);
        }
    }
}
