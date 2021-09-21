using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BNG
{
    public class MenuPointer : MonoBehaviour
    {
        public float FixedPointerLength = 20f;

        LineRenderer lineRenderer;
        InputBridge input;

        private void Awake()
        {
            lineRenderer = GetComponent<LineRenderer>();
        }

        private void Start()
        {
            input = InputBridge.Instance;
        }

        // Update is called once per frame
        void Update()
        {
            lineRenderer.useWorldSpace = false;
            lineRenderer.SetPosition(0, Vector3.zero);

            Vector3 fwd = transform.TransformDirection(Vector3.forward);

            RaycastHit hit;

            Debug.DrawRay(transform.position, fwd * 30, Color.black, 2, false);

            if (Physics.Raycast(transform.position, fwd, out hit, 30) && hit.transform.tag.Equals("MenuItem"))
            {
                if (input.RightTriggerDown)
                {
                    StartMenu.instance.TriggerMenuInstruction(hit.transform.name);
                }
                StartMenu.instance.HighlightMenuItem(hit.transform.name);
            }
            else StartMenu.instance.ClearHighlight();
        }
    }
}
