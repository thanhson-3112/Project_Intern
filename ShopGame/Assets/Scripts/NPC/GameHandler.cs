using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    // vi tri 5 vector 0 0 0 0 0 -> Khi khach 1 den thi add vao list[0], khach 2 add vao list[1], 
    // khi khach 1 di thi khach 2 len list[0]

    [SerializeField] private GameObject dotPrefab;
    private void Start()
    {
        List<Vector3> waitingQueuePositionList = new List<Vector3>();
        Vector3 lineStartPosition = new Vector3(-0.1f, 0);
        float positionSize = .8f;
        for (int i = 0; i < 5; i++)
        {
            Instantiate(dotPrefab, lineStartPosition + new Vector3(0, -1) * positionSize * i, Quaternion.identity);
            waitingQueuePositionList.Add(lineStartPosition + new Vector3(0, -1) * positionSize * i);
        }

        // Kiem tra neu vi tri co the vao

    }



}
