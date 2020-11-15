using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetWallScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetWall()
    {
        int temp = 0;

        GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        GameObject parentObject = gameObject.transform.parent.gameObject;
        for(int i = 0; i < (gm.stage+4)*(gm.stage+4); i++)
        {
            if(gm.roomPrefabList[i] == parentObject)
            {
                temp = i;
                break;
            }
        }

        if (temp / (gm.stage+4) == 0)
        {
            gameObject.transform.Find("SideWalls_South").transform.Find("WallDoor").gameObject.SetActive(true);
            gameObject.transform.Find("SideWalls_South").transform.Find("Wall_Entrance").gameObject.SetActive(false);
        }

        if(temp / (gm.stage+4) == (gm.stage + 3))
        {
            gameObject.transform.Find("SideWalls_North").transform.Find("WallDoor").gameObject.SetActive(true);
            gameObject.transform.Find("SideWalls_North").transform.Find("Wall_Entrance").gameObject.SetActive(false);
        }

        if(temp % (gm.stage+4) == 0)
        {
            gameObject.transform.Find("SideWalls_East").transform.Find("WallDoor").gameObject.SetActive(true);
            gameObject.transform.Find("SideWalls_East").transform.Find("Wall_Entrance").gameObject.SetActive(false);
        }

        if(temp % (gm.stage+4) == (gm.stage + 3))
        {
            gameObject.transform.Find("SideWalls_West").transform.Find("WallDoor").gameObject.SetActive(true);
            gameObject.transform.Find("SideWalls_West").transform.Find("Wall_Entrance").gameObject.SetActive(false);
        }
    }
}
