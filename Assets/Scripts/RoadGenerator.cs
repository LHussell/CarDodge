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
        Rigidbody frontRoadRigidBody = generatedRoadPieces[frontRoadPiece].GetComponent<Rigidbody>();
        HouseSpawner houseSpawner = generatedRoadPieces[frontRoadPiece].GetComponent<HouseSpawner>();
        frontRoadRigidBody.transform.position = endPosition;
        frontRoadRigidBody.transform.position += movementStep * Time.deltaTime;
        houseSpawner.buildHouses(generatedRoadPieces[frontRoadPiece]);
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
