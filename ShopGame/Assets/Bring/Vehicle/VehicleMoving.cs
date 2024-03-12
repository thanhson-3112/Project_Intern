using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Rendering;

public class VehicleMoving : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] private float rightBound;
    [SerializeField] private float leftBound;
    [SerializeField] private float moveSpeed;

    private float direction = 1;
    
    void Start()
    {
        spriteRenderer.flipX = true;
    }

    private void FixedUpdate()
    {
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
