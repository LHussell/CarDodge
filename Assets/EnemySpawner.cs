using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab;
    
    public void spawnEnemyAt(GameObject houseLocation)
    {
        if (enemyPrefab != null)
        {
            Instantiate(enemyPrefab, houseLocation.transform.position + new Vector3(0, 0, 10), transform.rotation);
        }
    }
}
