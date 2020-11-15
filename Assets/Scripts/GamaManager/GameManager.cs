using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int stage = 0;

    public Vector2 playerPos;

    public bool isPlayerFighting = false;

    public int[] roomSetList;
    public GameObject[] roomPrefabList;

    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.Find("Player").GetComponent<PlayerPosition>().playerCurPos;
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = GameObject.Find("Player").GetComponent<PlayerPosition>().playerCurPos;
    }

    public void SetSideWall()
    {
        foreach (GameObject sideWall in roomPrefabList)
        {
            sideWall.transform.Find("SideWalls").GetComponent<SetWallScript>().SetWall();
        }
    }
}
