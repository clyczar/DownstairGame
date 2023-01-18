using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public float downSpeed;
    private int i = 1;
    void Start()
    {
        
    }

    // Update 50 times per second
    void FixedUpdate()
    {
        transform.Translate(0, -downSpeed * Time.deltaTime, 0);
    }
}
