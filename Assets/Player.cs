using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float forceX;
    Rigidbody2D playerRigidbody2D;
    readonly float toLeft = -1;
    readonly float toRight = 1;
    readonly float stop = 0;
    float directionX;
    void Start()
    {
        playerRigidbody2D=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            directionX=toLeft;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            directionX=toRight;
        }
        else
        {
            directionX = stop;
        }

        Vector2 newDirection = new Vector2 (directionX,0);
        playerRigidbody2D.AddForce(newDirection * forceX);
    }
}
