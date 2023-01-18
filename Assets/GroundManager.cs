using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    readonly float initPositionY = 0;
    readonly float leftBorder = -3;
    readonly float rightBorder = 3;
    [Range(2, 6)] public float spacingY;
    public List<Transform> grounds;
    void Start()
    {
        grounds = new List<Transform>();
        for (int i = 0; i < 3; i++)
        {
            SpawnGround();
        }
        
    }

    float NewGroundPositionX()
    {
        return Random.Range(leftBorder, rightBorder);
    }

    float NewGroundPositionY()
    {
        if (grounds.Count == 0)
        {
            return initPositionY;
        }
        int lowerIndex = grounds.Count - 1;
        return grounds[lowerIndex].transform.position.y - spacingY;
    }

    void SpawnGround()
    {
        GameObject newGround = Instantiate(Resources.Load<GameObject>("Ground"));
        //float newGroundPositionY = initPositionY - spacingY * i;
        newGround.transform.position = new Vector3(NewGroundPositionX(), NewGroundPositionY(), 0);
        grounds.Add(newGround.transform);
    }
    void Update()
    {
        
    }
}
