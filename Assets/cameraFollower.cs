using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollower : MonoBehaviour
{
    void Start()
    {
        transform.parent = transform.parent.gameObject.transform;
    }

    private void Update()
    {
        if (StartMenu.instance.gameOver)
        {
            gameObject.SetActive(true);
        }
    }
}
