using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGenerator : MonoBehaviour
{
    BoxCollider roadBoxCollider;

    public GameObject roadPiece;
    GameObject[] generatedRoadPieces;

    float zHalfExtents;
    float zCenter;
    float zFront;

    int frontRoadPiece;
    int lastRoadPiece;

    public int numOfRoadPieces;


    // Start is called before the first frame update
    void Start()
    {
        frontRoadPiece = 0;
        lastRoadPiece = numOfRoadPieces - 1;
        generatedRoadPieces = new GameObject[numOfRoadPieces];
        generatedRoadPieces[0] = Instantiate(roadPiece, new Vector3(0, 0, 0), transform.rotation);
        roadBoxCollider = generatedRoadPieces[0].GetComponent<BoxCollider>();
        zHalfExtents = roadBoxCollider.bounds.extents.z;
        zCenter = roadBoxCollider.bounds.center.z;
        zFront = transform.position.z + (zCenter + zHalfExtents);
        buildRoads(numOfRoadPieces);
    }

    // Update is called once per frame
    void Update()
    {
        if(generatedRoadPieces[frontRoadPiece].transform.position.z <= -40)
        {
            recycleRoads();
        }
    }

    void buildRoads(int numOfRoads)
    {
        for(int i = 1; i < numOfRoads; i++)
        {
            float newZCenter = zFront + zHalfExtents;
            generatedRoadPieces[i] = Instantiate(roadPiece, new Vector3(0, 0, newZCenter), transform.rotation);
            zFront = newZCenter + zHalfExtents;
        }
        foreach(GameObject roadPiece in generatedRoadPieces)
        {
            roadPiece.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -10);
        }
    }

    void recycleRoads()
    {
        float zFullExtents = zHalfExtents * 2;
        generatedRoadPieces[frontRoadPiece].transform.position = new Vector3(0, 0, generatedRoadPieces[lastRoadPiece].transform.position.z + zFullExtents);
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
}
