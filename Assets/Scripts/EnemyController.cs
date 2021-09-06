using UnityEngine;

public class EnemyController : MonoBehaviour
{

    Rigidbody enemyRigidBody;

    private void Start()
    {
        enemyRigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        enemyRigidBody.MovePosition(transform.position + (new Vector3(0, 0, -1) * 15) * Time.deltaTime);

        if (transform.position.z < -10)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag.Equals("Projectile"))
        {
            Destroy(collision.collider.gameObject);
            Destroy(gameObject);
            PlayerStateController.instance.AddScorePoint();
        }
    }
}
