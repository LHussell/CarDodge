using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{

    public GameObject coin;

    public void BuildCoins(GameObject gameObject)
    {
        System.Random random = new System.Random();
        GameObject coinSpawnLocation = gameObject.transform.Find("Lane_Location" + random.Next(1, 4)).gameObject;
        Instantiate(coin, coinSpawnLocation.transform.position, transform.rotation);
    }
}
