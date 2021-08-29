using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    Rigidbody enemyRigidBody;
    Animator enemyAnimator;

    private void Start()
    {
        enemyRigidBody = GetComponent<Rigidbody>();
        enemyAnimator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (transform.position.x > 13)
        {
            enemyRigidBody.MovePosition(transform.position + new Vector3(-1, 0, -1) * Time.deltaTime);
            enemyAnimator.SetBool("Running", true);
        }
        else if (transform.position.x < -13)
        {
            enemyRigidBody.MovePosition(transform.position + new Vector3(1, 0, -1) * Time.deltaTime);
            enemyAnimator.SetBool("Running", true);
        }
        else
        {
            enemyRigidBody.MovePosition(transform.position + new Vector3(0, 0, -1) * Time.deltaTime);
            enemyAnimator.SetBool("Running", true);
        }
    }

}
