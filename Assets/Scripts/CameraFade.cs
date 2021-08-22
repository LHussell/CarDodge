using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFade : MonoBehaviour
{
    void Start()
    {
        Camera camera = GetComponent<Camera>();
        camera.farClipPlane = 300f;
    }
}
