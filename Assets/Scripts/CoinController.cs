using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{

    Rigidbody coinRigidBody;

    private void Start()
    {
        coinRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        coinRigidBody.MovePosition(transform.position + new Vector3(0, 0, -25) * Time.deltaTime);

        if (transform.position.z < -10)
        {
            Destroy(gameObject);
        }
    }
}
