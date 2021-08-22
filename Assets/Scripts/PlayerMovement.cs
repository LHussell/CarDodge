using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody playerRigidBody;
    BoxCollider playerBoxCollider;

    CarDirectionPressed direction;

    float maxVelocity = 60;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
        direction = CarDirectionPressed.None;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("a") && playerRigidBody.velocity.x >= maxVelocity * -1 && direction != CarDirectionPressed.Left)
        {
            direction = CarDirectionPressed.Left;
        }
        else if (Input.GetKey("d") && playerRigidBody.velocity.x <= maxVelocity && direction != CarDirectionPressed.Right)
        {
            direction = CarDirectionPressed.Right;
        }
    }

    private void FixedUpdate()
    {

        if (direction == CarDirectionPressed.Left)
        {
            playerRigidBody.AddForce(-2, 0, 0, ForceMode.Force);
        }
        else if (direction == CarDirectionPressed.Right)
        {
            playerRigidBody.AddForce(2, 0, 0, ForceMode.Force);
        }
        

    }
}

enum CarDirectionPressed
{
    Left,
    Right,
    None
}
