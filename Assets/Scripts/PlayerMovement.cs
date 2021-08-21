using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody playerRigidBody;
    BoxCollider playerBoxCollider;

    float maxVelocity = 60;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("a") && playerRigidBody.velocity.x >= maxVelocity * -1)
        {
            playerRigidBody.AddForce(-1, 0, 0, ForceMode.Force);
        }
        if (Input.GetKey("d") && playerRigidBody.velocity.x <= maxVelocity)
        {
            playerRigidBody.AddForce(1, 0, 0, ForceMode.Force);
        }
    }
}
