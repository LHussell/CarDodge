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
        if (StartMenu.instance.gameRunning)
            enemyRigidBody.MovePosition(transform.position + (new Vector3(0, 0, -1) * 15) * Time.deltaTime);

        if (transform.position.z < -10)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag.Equals("Projectile"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            PlayerStateController.instance.AddScorePoint();
        }
        if (collision.tag.Equals("Player"))
        {
            StartMenu.instance.gameRunning = false;
            StartMenu.instance.gameOver = true;
        }
    }
}
