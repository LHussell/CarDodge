using System;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    System.Random random;

    private void Awake()
    {
        random = new System.Random();
    }
    public void SpawnEnemyAt(GameObject gameObject)
    {
        GameObject enemySpawnLocation = gameObject.transform.Find("Lane_Location" + RandomNumGen.instance.GetRandomNumber(1, 4)).gameObject;
        Instantiate(Resources.Load("Cars/Car_" + RandomNumGen.instance.GetRandomNumber(1, 4)) as GameObject, enemySpawnLocation.transform.position, transform.rotation * Quaternion.Euler(0f, 180f, 0f));
    }
}
