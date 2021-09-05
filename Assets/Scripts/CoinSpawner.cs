using System;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{

    public GameObject coin;
    System.Random random;


    private void Awake()
    {
        random = new System.Random();
    }

    public void BuildCoins(GameObject gameObject)
    {
        GameObject coinSpawnLocation = gameObject.transform.Find("Lane_Location" + RandomNumGen.instance.GetRandomNumber(1, 4)).gameObject;
        Instantiate(coin, coinSpawnLocation.transform.position + new Vector3(0, 2, 0), transform.rotation);
    }
}
