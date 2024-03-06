using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
    [SerializeField] private float minMoveSpeed;
    [SerializeField] private float maxMoveSpeed;

    [SerializeField] private Rigidbody2D rb2D;
    void Start()
    {
        NPCMovement();
        // MoveToRandomBuilding();
    }

    void Update()
    {
        NPCWalkOutOfScreen();
    }

    private void NPCMovement()
    {
        float randomMoveSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);

        float minMoveDirX = -1f;
        float maxMoveDirX = 1f;
        float moveDirX = Random.Range(minMoveDirX, maxMoveDirX);

        Vector3 moveDir = new Vector3(moveDirX, 0, 0);
        rb2D.velocity = moveDir * randomMoveSpeed;
    }

    private void NPCWalkOutOfScreen()
    {
        float xBoundary = 20f;
        if (transform.position.x < -xBoundary || transform.position.x > xBoundary)
        {
            Destroy(gameObject);
        }
    }

    private void NPCRotate()
    {

    }

    private void MoveToRandomBuilding()
    {
        Vector2 randomPosition = new Vector2(Random.Range(-10f, 10f), Random.Range(-10f, 10f));
        transform.position = randomPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Building"))
        {

        }
    }
}
