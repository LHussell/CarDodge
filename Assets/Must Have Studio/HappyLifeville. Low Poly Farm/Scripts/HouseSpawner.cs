using System;
using UnityEngine;

public class HouseSpawner : MonoBehaviour
{

    GameObject house;

    public void buildHouses(GameObject gameObject)
    {
        Destroy(house);
        System.Random random = new System.Random();
        GameObject houseLocation = gameObject.transform.Find("House_Location" + random.Next(1, 5)).gameObject;
        house = Instantiate(Resources.Load("House_" + random.Next(1, 5)) as GameObject, houseLocation.transform.position, transform.rotation);
        house.transform.parent = houseLocation.transform;
    }
}
