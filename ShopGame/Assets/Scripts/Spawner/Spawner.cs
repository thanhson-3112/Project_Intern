using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private float NPCSpawnRate = 2f;

    [SerializeField] private GameObject[] NPCPrefabs;
    [SerializeField] private SpawnPoint spawnPoint;

    private bool canSpawn = true;

    void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(NPCSpawnRate);

        while (canSpawn)
        {
            yield return wait;

            Transform spawnTransform = spawnPoint.GetRandomPoint();
            if (spawnTransform != null)
            {
                GameObject NPCToSpawn = NPCPrefabs[Random.Range(0, NPCPrefabs.Length)];
                Instantiate(NPCToSpawn, spawnTransform.position, Quaternion.identity);
            }
            else
            {
                Debug.LogWarning("Failed to spawn enemy. No valid spawn point.");
            }
        }
    }
}
