using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] NPCPrefab;

    [SerializeField] private float spawnNPCTimer;
    void Start()
    {
        InvokeRepeating("SpawnNPC", 5, spawnNPCTimer);
    }

    void Update()
    {
        
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
}
