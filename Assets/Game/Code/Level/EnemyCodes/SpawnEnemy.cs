using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject spawnPosition;
    void Start()
    {
        Invoke("SpawningEnemy", 5);
    }

    private void SpawningEnemy()
    {
        Instantiate(enemyPrefab, spawnPosition.transform.position, spawnPosition.transform.rotation);
        Invoke("SpawningEnemy", 5);
    }

}
