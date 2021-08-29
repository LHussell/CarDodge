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
            Instantiate(enemyPrefab, houseLocation.transform.position + new Vector3(0, 0, 20), transform.rotation * Quaternion.Euler(0f, 180f, 0f));
        }
    }
}
