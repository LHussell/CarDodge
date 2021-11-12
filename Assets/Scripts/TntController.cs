using UnityEngine;

public class TntController : MonoBehaviour
{

    Rigidbody tntRigidBody;

    public bool isReleased;

    private void Awake()
    {
        tntRigidBody = GetComponent<Rigidbody>();

        isReleased = false;
    }

    private void FixedUpdate()
    {
        if (isReleased)
        {
            Quaternion deltaRotation = Quaternion.Euler(new Vector3(50, 0, 450) * Time.fixedDeltaTime);
            tntRigidBody.MoveRotation(tntRigidBody.rotation * deltaRotation);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (!collision.transform.tag.Equals("EnemyCar") || !collision.transform.tag.Equals("Coin"))
        {
            Instantiate(Resources.Load("FX_AerialExplosion_AC") as GameObject, gameObject.transform.position, transform.rotation);
            Destroy(gameObject);
            if (collision.transform.tag.Equals("Player"))
            {
                StartMenu.instance.gameRunning = false;
                StartMenu.instance.gameOver = true;
            }
        }

    }
}
