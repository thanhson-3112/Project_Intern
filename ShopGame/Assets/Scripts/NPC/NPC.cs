using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] private float minMoveSpeed;
    [SerializeField] private float maxMoveSpeed;

    [SerializeField] private Rigidbody2D rb2D;
    void Start()
    {
        NPCMovement();
    }

    void Update()
    {

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
}
