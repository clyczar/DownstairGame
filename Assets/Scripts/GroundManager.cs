using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroundManager : MonoBehaviour
{
    readonly float initPositionY = 0;
    readonly float leftBorder = -3;
    readonly float rightBorder = 3;
    readonly int MAX_GROUND_COUNT = 10;
    readonly int MIN_GROUND_COUNT_UNDER_PLAYER = 3;
    static int groundNumber = -1;
    [Range(2, 6)] public float spacingY;
    [Range(1, 20)] public float singleFloorHeight;
    public List<Transform> grounds;
    public Transform player;
    public Text displayCountFloor;
    void Start()
    {
        grounds = new List<Transform>();
        for (int i = 0; i < MAX_GROUND_COUNT; i++)
        {
            SpawnGround();
        }
        
    }
    public void ControlSpawnGround()
    {
        int groundsCountUnderPlayer = 0;
        foreach (Transform ground in grounds)
        {
            if (ground.position.y < player.position.y)
            {
                groundsCountUnderPlayer++;
            }
        }
        if(groundsCountUnderPlayer < MIN_GROUND_COUNT_UNDER_PLAYER)
        {
            SpawnGround();
            ControlGroundsCount();
        }
    }

    public void ControlGroundsCount()
    {
        if (grounds.Count > MAX_GROUND_COUNT)
        {
            Destroy(grounds[0].gameObject);
            grounds.RemoveAt(0);
        }    
    }

    float NewGroundPositionX()
    {
        if (grounds.Count == 0)
        {
            return 0;
        }
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
        newGround.transform.position = new Vector3(NewGroundPositionX(), NewGroundPositionY(), 0);
        grounds.Add(newGround.transform);
    }

    float CountLowerGroundFloor()
    {
        float playerPositionY = player.transform.position.y;
        float deep = Mathf.Abs(initPositionY - playerPositionY);
        return (deep / singleFloorHeight) + 1;
    }

    void DiplayCountFloor()
    {
        displayCountFloor.text = "Level" + CountLowerGroundFloor().ToString("0000");
    }
    void Update()
    {
        ControlSpawnGround();
        DiplayCountFloor();
    }
}
