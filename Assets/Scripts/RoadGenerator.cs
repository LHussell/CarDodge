using System;
using UnityEngine;

public class RoadGenerator : MonoBehaviour
{
    BoxCollider roadBoxCollider;

    public float roadSpeed;

    public GameObject roadPiece;
    GameObject[] generatedRoadPieces;

    float zFullExtent;

    int frontRoadPiece = 0;
    int lastRoadPiece;


    public int maxEnemySpace;
    public int maxHouseSpace;


    int enemySpace = 0;
    int houseSpace = 0;



    public int numOfRoadPieces;

    Vector3 movementStep;


    // Start is called before the first frame update
    void Start()
    {
        movementStep = new Vector3(0, 0, -1) * roadSpeed;
        lastRoadPiece = numOfRoadPieces - 1;
        generatedRoadPieces = new GameObject[numOfRoadPieces];
        generatedRoadPieces[0] = Instantiate(roadPiece, new Vector3(0, 0, 0), transform.rotation);
        roadBoxCollider = generatedRoadPieces[0].GetComponent<BoxCollider>();
        zFullExtent = roadBoxCollider.bounds.extents.z * 2;
        buildRoads(numOfRoadPieces);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (generatedRoadPieces[frontRoadPiece].transform.position.z <= -40)
        {
            recycleRoads();
        }
        moveRoads();
    }

    void buildRoads(int numOfRoads)
    {
        float newZCenter = roadBoxCollider.center.z + zFullExtent;
        for (int i = 1; i < numOfRoads; i++)
        {
            generatedRoadPieces[i] = Instantiate(roadPiece, new Vector3(0, 0, newZCenter), transform.rotation);
            newZCenter += zFullExtent;
        }
    }



    void recycleRoads()
    {
        var endPosition = new Vector3(0, 0, generatedRoadPieces[lastRoadPiece].transform.position.z + zFullExtent);
        var tempFrontRoadPiece = generatedRoadPieces[frontRoadPiece];
        Rigidbody frontRoadRigidBody = tempFrontRoadPiece.GetComponent<Rigidbody>();
        HouseSpawner houseSpawner = tempFrontRoadPiece.GetComponent<HouseSpawner>();
        EnemySpawner enemySpawner = tempFrontRoadPiece.GetComponent<EnemySpawner>();
        CoinSpawner coinSpawner = tempFrontRoadPiece.GetComponent<CoinSpawner>();

        frontRoadRigidBody.transform.position = endPosition;
        frontRoadRigidBody.transform.position += movementStep * Time.deltaTime;

        System.Random rand = new System.Random();

        if (houseSpace == 0) houseSpawner.BuildHouses(tempFrontRoadPiece);
        if (enemySpace == 0) enemySpawner.SpawnEnemyAt(tempFrontRoadPiece);
        else if (RandomNumGen.instance.GetRandomNumber(1, 11) < 3) coinSpawner.BuildCoins(tempFrontRoadPiece);

        if (houseSpace < maxHouseSpace) houseSpace++; else houseSpace = 0;
        if (enemySpace < maxEnemySpace) enemySpace++; else enemySpace = 0;

        if (frontRoadPiece == numOfRoadPieces - 1)
        {
            lastRoadPiece = numOfRoadPieces - 1;
            frontRoadPiece = 0;
        }
        else
        {
            lastRoadPiece = frontRoadPiece;
            frontRoadPiece++;
        }
    }

    void moveRoads()
    {
        foreach (GameObject roadPiece in generatedRoadPieces)
        {
            roadPiece.GetComponent<Rigidbody>().MovePosition(roadPiece.transform.position + movementStep * Time.deltaTime);
        }
    }
}
