using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BNG
{
    public class VehicleMovement : MonoBehaviour
    {

        Rigidbody vehicleRigidBody;

        [Tooltip("Used to determine which direction to move. Example : Left Thumbstick Axis or Touchpad. ")]
        public List<InputAxis> inputAxis = new List<InputAxis>() { InputAxis.LeftThumbStickAxis };

        // Start is called before the first frame update
        void Start()
        {
            vehicleRigidBody = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            // Check raw input bindings
            if (inputAxis != null)
            {
                for (int i = 0; i < inputAxis.Count; i++)
                {
                    Vector3 axisVal = InputBridge.Instance.GetInputAxisValue(inputAxis[i]);
                    var xPos = transform.position.x;
                    if (xPos < 6.6 && axisVal.x > 0)
                    {
                        vehicleRigidBody.MovePosition(transform.position + new Vector3(axisVal.x * 3, 0, 0) * Time.deltaTime);
                    }
                    if (xPos > -6.6 && axisVal.x < 0)
                    {
                        vehicleRigidBody.MovePosition(transform.position + new Vector3(axisVal.x * 3, 0, 0) * Time.deltaTime);
                    }
                }
            }
        }
    }
}

