using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidewalkItemSpawner : MonoBehaviour
{

    public GameObject fireHydrantPrefab;
    public GameObject lamppostPrefab;

    GameObject house;
    GameObject hydrant;
    GameObject lamppost;

    public void BuildHouses(GameObject gameObject)
    {
        GameObject houseLocation = gameObject.transform.Find("House_Location" + RandomNumGen.instance.GetRandomNumber(1, 3)).gameObject;
        house = Instantiate(Resources.Load("House_" + RandomNumGen.instance.GetRandomNumber(1, 5)) as GameObject, houseLocation.transform.position, transform.rotation);
        house.transform.parent = houseLocation.transform;
    }

    public void SpawnHydrant(GameObject gameObject)
    {
        hydrant = Instantiate(fireHydrantPrefab, gameObject.transform.Find("Sidewalk_Location1").transform.position, transform.rotation);
        hydrant.transform.parent = gameObject.transform.Find("Sidewalk_Location1").transform;
    }

    public void SpawnLamppost(GameObject gameObject, bool isLeftSide)
    {
        var sidewalkSide = isLeftSide ? "1" : "2";
        var lampostZRotation = isLeftSide ? 90f : -90f;
        lamppost = Instantiate(lamppostPrefab, gameObject.transform.Find("Sidewalk_Location" + sidewalkSide).transform.position, transform.rotation * Quaternion.Euler(0f, lampostZRotation, 0f));
        lamppost.transform.parent = gameObject.transform.Find("Sidewalk_Location" + sidewalkSide).transform;
    }

    public void ClearItems()
    {
        Destroy(house);
        Destroy(hydrant);
        Destroy(lamppost);
    }
}
