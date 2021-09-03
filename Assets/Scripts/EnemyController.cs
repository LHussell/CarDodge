using UnityEngine;

public class EnemyController : MonoBehaviour
{

    Rigidbody enemyRigidBody;
    Animator enemyAnimator;

    bool movingEnabled = true;

    private void Start()
    {
        enemyRigidBody = GetComponent<Rigidbody>();
        enemyAnimator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (movingEnabled)
        {
            if (transform.position.x > 8)
            {
                enemyRigidBody.MovePosition(transform.position + (new Vector3(-0.2f, 0, -1) * 30) * Time.deltaTime);
                enemyAnimator.SetBool("Running", true);
            }
            else if (transform.position.x < -8)
            {
                enemyRigidBody.MovePosition(transform.position + (new Vector3(0.2f, 0, -1) * 30) * Time.deltaTime);
                enemyAnimator.SetBool("Running", true);
            }
            else
            {
                enemyRigidBody.MovePosition(transform.position + (new Vector3(0, 0, -1) * 30) * Time.deltaTime);
                enemyAnimator.SetBool("Running", true);
            }

            if (transform.position.z < -10)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag.Equals("Projectile"))
        {
            Destroy(collision.collider.gameObject);
            enemyAnimator.SetBool("Running", false);
            enemyAnimator.SetBool("Dead", true);
            movingEnabled = false;
            Destroy(gameObject, 5);
            ScoreCounter.instance.AddPoint();
        }
    }
}
