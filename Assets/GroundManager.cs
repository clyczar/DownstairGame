using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    readonly float initPositionY = 0;
    readonly float leftBorder = -3;
    readonly float rightBorder = 3;
    [Range(2, 6)] public float spacingY;

    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject newGround = Instantiate(Resources.Load<GameObject>("Ground"));
            float newGroundPositionY = initPositionY - spacingY * i;
            newGround.transform.position = new Vector3 (NewGroundPositionX(), newGroundPositionY, 0);
        }
        
    }

    float NewGroundPositionX()
    {
        return Random.Range(leftBorder, rightBorder);
    }

    void Update()
    {
        
    }
}
