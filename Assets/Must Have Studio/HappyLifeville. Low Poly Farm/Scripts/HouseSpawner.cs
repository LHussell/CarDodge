using System;
using UnityEngine;

public class HouseSpawner : MonoBehaviour
{
    public void buildHouses(GameObject gameObject)
    {
        System.Random random = new System.Random();
        GameObject houseLocation = gameObject.transform.Find("House_Location" + random.Next(1, 5)).gameObject;
        var house = Instantiate(Resources.Load("House_" + random.Next(1, 5)) as GameObject, houseLocation.transform.position, transform.rotation);
        house.transform.parent = houseLocation.transform;
    }
}
