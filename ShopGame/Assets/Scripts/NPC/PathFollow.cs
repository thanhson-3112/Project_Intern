using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float stoppingDistance = 0.8f; // Kho?ng cách ?? d?ng l?i khi g?p v?t c?n

    NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        target = GameObject.FindGameObjectWithTag("Door").transform;
    }

    private void Update()
    {
        agent.SetDestination(target.position);

        // Ki?m tra n?u ?ang g?n v?i m?c tiêu và không th? di chuy?n ti?p
        if (agent.remainingDistance <= stoppingDistance && !agent.pathPending)
        {
            // D?ng l?i
            agent.isStopped = true;
        }
        else
        {
            // Ti?p t?c di chuy?n
            agent.isStopped = false;
        }
    }
}
