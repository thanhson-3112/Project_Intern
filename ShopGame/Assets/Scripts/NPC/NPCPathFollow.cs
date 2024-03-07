using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCPathFollow : MonoBehaviour
{
    [SerializeField] Transform target;

    [SerializeField] private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update()
    {
        SetGuestDestination(target.position);
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
