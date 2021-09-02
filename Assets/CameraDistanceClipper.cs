using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDistanceClipper : MonoBehaviour
{

    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        cam.farClipPlane = 200f;
    }
}
