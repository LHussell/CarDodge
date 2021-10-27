using UnityEngine;
using SimpleBallistic;

public class EnemyPlayerController : MonoBehaviour
{
    Animator animator;
    Rigidbody objectToThrowRigidBody;
    GameObject objectInstantiation;


    public Transform hand;
    public float speed = 20;

    GameObject player;
    public GameObject objectToThrow;

    void Start()
    {
        animator = GetComponent<Animator>();

        InvokeRepeating("Throw", 0, 3);
    }

    void Update()
    {
        if (objectInstantiation == null)
        {
            objectInstantiation = Instantiate(objectToThrow, transform.position, transform.rotation);
            objectInstantiation.transform.SetParent(hand);
            objectToThrowRigidBody = objectInstantiation.GetComponent<Rigidbody>();
        }
    }

    public void Throw()
    {
        if (transform.position.z < 100)
        {
            animator.SetTrigger("Throw");
            Debug.Log("Throw triggered");
        }
    }

    public void ReleaseExplosive()
    {
        var mainPlayerPosition = MainPlayerController.instance.transform.position;
        objectToThrowRigidBody.isKinematic = false;
        objectToThrowRigidBody.useGravity = true;

        var angle = Ballistics.GetAngle(objectToThrowRigidBody.transform.position, mainPlayerPosition, 50);
        objectInstantiation.transform.SetParent(null);
        LookAtAngle(angle[1], mainPlayerPosition);
        objectToThrowRigidBody.velocity = objectToThrowRigidBody.transform.forward * 50;
        objectToThrowRigidBody.transform.Rotate(90, 0, 0);
        objectToThrowRigidBody.GetComponent<TntController>().isReleased = true;
    }

    protected void LookAtAngle(float _angle, Vector3 mainPlayerPosition)
    {
        Vector3 axis = mainPlayerPosition - objectToThrowRigidBody.transform.position;
        axis.y = 0;
        axis.Normalize();
        axis = Quaternion.AngleAxis(_angle, Vector3.Cross(axis, Vector3.up)) * axis;
        objectToThrowRigidBody.transform.forward = axis;
    }
}
