using System;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public void SpawnEnemyAt(GameObject gameObject)
    {
        System.Random random = new System.Random();
        GameObject enemySpawnLocation = gameObject.transform.Find("Lane_Location" + random.Next(1, 4)).gameObject;
        Instantiate(Resources.Load("Cars/Car_" + random.Next(1, 4)) as GameObject, enemySpawnLocation.transform.position, transform.rotation * Quaternion.Euler(0f, 180f, 0f));
    }
}
