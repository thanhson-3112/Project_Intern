using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] NPCPrefab;
    [SerializeField] private Transform spawnPointA;
    [SerializeField] private Transform spawnPointB;

    [SerializeField] private float spawnNPCTimer;
    void Start()
    {
        InvokeRepeating("SpawnNPCOnRandomPoint", 5, spawnNPCTimer);
    }

    private void SpawnNPC()
    {
        // offset to spawn off screen
        float spawnOffsetX = 8;
        float spawnOffsetY = -2.5f;

        
        int randomPrefabIndex = Random.Range(0, NPCPrefab.Length);
        Vector3 spawnPosition = new Vector3(spawnOffsetX, spawnOffsetY, 0);
        Instantiate(NPCPrefab[randomPrefabIndex], spawnPosition, Quaternion.identity);
    }

    private void SpawnNPCOnRandomPoint()
    {
        int randomPrefabIndex = Random.Range(0, NPCPrefab.Length);
        if (spawnPointA != null && spawnPointB != null && NPCPrefab != null)
        {
            Transform spawnPoint = Random.Range(0,2) == 0 ? spawnPointA : spawnPointB;
            Instantiate(NPCPrefab[randomPrefabIndex], spawnPoint.position, Quaternion.identity);
        }
        else
        {
            Debug.Log("You are missing Assign Prefab, spawnPointA or spawnPointB");
        }

    }
}
