using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float stoppingDistance = 0.8f; // Khoảng cách để dừng lại khi gặp vật cản

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

        // Kiểm tra nếu đang gần với mục tiêu và không thể di chuyển tiếp
        if (agent.remainingDistance <= stoppingDistance && !agent.pathPending)
        {
            // Dừng lại
            agent.isStopped = true;
        }
        else
        {
            // Tiếp tục di chuyển
            agent.isStopped = false;
        }
    }
}
