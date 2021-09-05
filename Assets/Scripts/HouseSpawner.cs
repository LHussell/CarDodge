using System;
using UnityEngine;

public class HouseSpawner : MonoBehaviour
{

    GameObject house;

    public void BuildHouses(GameObject gameObject)
    {
        Destroy(house);
        System.Random random = new System.Random();
        GameObject houseLocation = gameObject.transform.Find("House_Location" + RandomNumGen.instance.GetRandomNumber(1, 3)).gameObject;
        house = Instantiate(Resources.Load("House_" + RandomNumGen.instance.GetRandomNumber(1, 5)) as GameObject, houseLocation.transform.position, transform.rotation);
        house.transform.parent = houseLocation.transform;
    }
}
