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
    public int maxHydrantSpace;
    public int maxLamppostSpace;

    int enemySpace = 0;
    int houseSpace = 0;
    int hydrantSpace = 0;
    int lamppostSpace = 0;
    bool isLamppostLeftSide = true;


    public int numOfRoadPieces;

    Vector3 movementStep;

    void Start()
    {
        // Initialise and build all roadpieces to move at set speed.
        movementStep = new Vector3(0, 0, -1) * roadSpeed;
        lastRoadPiece = numOfRoadPieces - 1;
        generatedRoadPieces = new GameObject[numOfRoadPieces];
        generatedRoadPieces[0] = Instantiate(roadPiece, new Vector3(0, 0, 0), transform.rotation);
        roadBoxCollider = generatedRoadPieces[0].GetComponent<BoxCollider>();
        zFullExtent = roadBoxCollider.bounds.extents.z * 2;
        buildRoads(numOfRoadPieces);
    }

    void FixedUpdate()
    {
        if (StartMenu.instance.gameRunning)
        {
            if (generatedRoadPieces[frontRoadPiece].transform.position.z <= -40)
            {
                recycleRoads();
            }
            moveRoads();
        }
    }

    // Builds all the roads in the initialisation. numOfRoads defines how long the road should be in front of the player. 
    void buildRoads(int numOfRoads)
    {
        float newZCenter = roadBoxCollider.center.z + zFullExtent;
        for (int i = 1; i < numOfRoads; i++)
        {
            generatedRoadPieces[i] = Instantiate(roadPiece, new Vector3(0, 0, newZCenter), transform.rotation);
            newZCenter += zFullExtent;
        }
    }


    // Recycle roads and instantiate objects on them according spacing between objects defined. 
    void recycleRoads()
    {
        // Find new position of where to change the position of roadpiece and find roadpiece to move and move them.
        var endPosition = new Vector3(0, 0, generatedRoadPieces[lastRoadPiece].transform.position.z + zFullExtent);
        var tempFrontRoadPiece = generatedRoadPieces[frontRoadPiece];
        Rigidbody frontRoadRigidBody = tempFrontRoadPiece.GetComponent<Rigidbody>();
        frontRoadRigidBody.transform.position = endPosition;
        frontRoadRigidBody.transform.position += movementStep * Time.deltaTime;

        // Clear previous items from roadpiece
        var sideWalkSpawner = tempFrontRoadPiece.GetComponent<SidewalkItemSpawner>();
        sideWalkSpawner.ClearItems();

        // Instantiate gameobjects when conditions are met.
        if (enemySpace == 0) tempFrontRoadPiece.GetComponent<EnemySpawner>().SpawnEnemyAt(tempFrontRoadPiece);
        else if (RandomNumGen.instance.GetRandomNumber(1, 11) < 3) tempFrontRoadPiece.GetComponent<CoinSpawner>().BuildCoins(tempFrontRoadPiece);
        if (houseSpace == 0) sideWalkSpawner.BuildHouses(tempFrontRoadPiece);
        if (hydrantSpace == 0) sideWalkSpawner.SpawnHydrant(tempFrontRoadPiece);
        if (lamppostSpace == 0)
        {
            sideWalkSpawner.SpawnLamppost(tempFrontRoadPiece, isLamppostLeftSide);
            isLamppostLeftSide = !isLamppostLeftSide;
        }

        // Increment item spaces.
        if (houseSpace < maxHouseSpace) houseSpace++; else houseSpace = 0;
        if (enemySpace < maxEnemySpace) enemySpace++; else enemySpace = 0;
        if (hydrantSpace < maxHydrantSpace) hydrantSpace++; else hydrantSpace = 0;
        if (lamppostSpace < maxLamppostSpace) lamppostSpace++; else lamppostSpace = 0;
        

        // Update frontRoadPiece in array.
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

    // Method for moving the transform position of the roadpieces.
    void moveRoads()
    {
        foreach (GameObject roadPiece in generatedRoadPieces)
        {
            roadPiece.GetComponent<Rigidbody>().MovePosition(roadPiece.transform.position + movementStep * Time.deltaTime);
        }
    }
}
