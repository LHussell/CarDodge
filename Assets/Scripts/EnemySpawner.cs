using System;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemy;

    public void SpawnEnemyAt(GameObject gameObject)
    {
        GameObject enemySpawnLocation = gameObject.transform.Find("Lane_Location" + RandomNumGen.instance.GetRandomNumber(1, 4)).gameObject;
        GameObject enemyCar = Instantiate(Resources.Load("Cars/Car_1") as GameObject, enemySpawnLocation.transform.position, transform.rotation * Quaternion.Euler(0f, 180f, 0f));
        if (RandomNumGen.instance.GetRandomNumber(1,3) == 1 && enemy != null)
        {
            GameObject enemySpawned = Instantiate(enemy, enemyCar.transform.Find("EnemySpawnPoint").transform.position + new Vector3(0, -0.5f, 0), transform.rotation * Quaternion.Euler(0f, 180f, 0f));
            enemySpawned.transform.parent = enemyCar.transform.Find("EnemySpawnPoint").transform;
        }
    }
}
