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

        StartMenu startMenu;

        private void Awake()
        {
            lineRenderer = GetComponent<LineRenderer>();
            startMenu = StartMenu.instance;
        }

        private void Start()
        {
            input = InputBridge.Instance;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (!startMenu.gameRunning)
            {
                lineRenderer.enabled = true;
                lineRenderer.useWorldSpace = false;
                lineRenderer.SetPosition(0, Vector3.zero);

                Vector3 fwd = transform.TransformDirection(Vector3.forward);

                RaycastHit hit;

                Debug.DrawRay(transform.position, fwd * 30, Color.black, 2, false);

                if (Physics.Raycast(transform.position, fwd, out hit, 30) && hit.transform.tag.Equals("MenuItem"))
                {
                    if (input.RightTriggerDown)
                    {
                        startMenu.TriggerMenuInstruction(hit.transform.name);
                    }
                    startMenu.HighlightMenuItem(hit.transform.name);
                }
                else if (startMenu.menuItemSelected) startMenu.ClearHighlight();
            }
            else
            {
                lineRenderer.enabled = false;
            }
        }
    }
}
