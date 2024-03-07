using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCPathFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float stoppingDistance = 0.8f; // Khoảng cách để dừng lại khi gặp vật cản

    [SerializeField] private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        target = GameObject.FindGameObjectWithTag("Door").transform;
    }

    private void Update()
    {
        SetGuestDestination(target.position);

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

    public void SetGuestDestination(Vector3 destination)
    {
        agent.SetDestination(destination);
    }

    public void MoveTo<T1, T2>(Vector3 destination, T2 destination2)
    {
        agent.Move(destination);
    }
    public void MoveTo(Vector3 destination)
    {
        agent.Move(destination);
    }
}
