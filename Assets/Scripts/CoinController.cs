using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{

    Rigidbody coinRigidBody;

    bool isMoving = true;
    bool triggerJump = false;

    private void Start()
    {
        coinRigidBody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isMoving && StartMenu.instance.gameRunning)
        {
            coinRigidBody.MovePosition(transform.position + new Vector3(0, 0, -25) * Time.deltaTime);
            Quaternion deltaRotation = Quaternion.Euler(new Vector3(0, 100, 0) * Time.fixedDeltaTime);
            coinRigidBody.MoveRotation(coinRigidBody.rotation * deltaRotation);
        } 
        else if(transform.localScale.x > 0)
        {
            Quaternion deltaRotation = Quaternion.Euler(new Vector3(0, 1500, 0) * Time.fixedDeltaTime);
            coinRigidBody.MoveRotation(coinRigidBody.rotation * deltaRotation);
            transform.localScale -= new Vector3(2, 2, 2) * Time.deltaTime;
        } 
        else Destroy(gameObject);

        if (triggerJump)
        {
            coinRigidBody.AddForce(new Vector3(0, 4, 0), ForceMode.Impulse);
            coinRigidBody.useGravity = true;
            triggerJump = false;
        }

        if (transform.position.z < -10)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            PlayerStateController.instance.AddCoin();
            isMoving = false;
            triggerJump = true;
        }
    }
}
