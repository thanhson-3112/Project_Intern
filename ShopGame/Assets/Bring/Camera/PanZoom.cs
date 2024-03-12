using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanZoom : MonoBehaviour
{
    [Header("Zoom")]
    [SerializeField] private float zoomOutMin;
    [SerializeField] private float zoomOutMax;
    [SerializeField] private float zoomSpeedMultiply;
    
    [Header("Camera Bound")]
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;

    private Vector3 touchStart;


    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // true on start pressed
        {
            if (Camera.main != null){
                touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }

        if (Input.GetMouseButton(0)) // true the whole pressed down
        {
            if (Camera.main != null) {
                Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
                MoveCamera(direction);
            }
        }

        // Zoom(Input.GetAxis("Mouse ScrollWheel"));

        // mobile pinch zoom
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch TouchOne = Input.GetTouch(1);
            
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition; // compare current touch position from the last position
            Vector2 touchOnePrevPos = TouchOne.position - TouchOne.deltaPosition; // deltaPosition is last position since last frame

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude; // calculate the length/ distance between point
            float currentMagnitude = (touchZero.position - TouchOne.position).magnitude;

            /* The magnitudes represent the distance between the two touches in the previous and current frames. 
             This is typically used to determine the pinch gesture's scale. */

            float difference = currentMagnitude - prevMagnitude; // indicates how much the user has pinched (zoomed in or out) since the last frame.

            Zoom(difference * 0.01f);
        }

        ClampCameraPosition();
    }

    void Zoom(float increment){
        if (Camera.main != null)
        {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment * zoomSpeedMultiply, zoomOutMin, zoomOutMax);
        }
    }

    void MoveCamera(Vector3 direction)
    {
        if (Camera.main != null)
        {
            Vector3 newPosition = Camera.main.transform.position + direction;
            Camera.main.transform.position = new Vector3(
                Mathf.Clamp(newPosition.x, minX, maxX),
                Mathf.Clamp(newPosition.y, minY, maxY),
                Camera.main.transform.position.z
            );
        }
    }

    void ClampCameraPosition()
    {
        if (Camera.main != null)
        {
            Camera.main.transform.position = new Vector3(
            Mathf.Clamp(Camera.main.transform.position.x, minX, maxX),
            Mathf.Clamp(Camera.main.transform.position.y, minY, maxY),
            Camera.main.transform.position.z
        );
        }
    }
}
