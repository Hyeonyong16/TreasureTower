using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    public Vector2 playerCurPos;
    //public Vector2 playerPrevPos;

    bool initCheck = false;

    // Start is called before the first frame update
    void Start()
    {
        StageCreate sc = GameObject.Find("GameManager").GetComponent<StageCreate>();

        playerCurPos = new Vector2(sc.GetStartPos() % (sc.stage + 4), sc.GetStartPos() / (sc.stage + 4));
        //playerPrevPos = new Vector2(sc.GetStartPos() % (sc.stage + 4), sc.GetStartPos() / (sc.stage + 4));
    }

    // Update is called once per frame
    void Update()
    {
        //if(!initCheck)
        //{
        //    StageCreate sc = GameObject.Find("GameManager").GetComponent<StageCreate>();

        //    playerCurPos = new Vector2(sc.GetStartPos() % (sc.stage + 4), sc.GetStartPos() / (sc.stage + 4));

        //    Vector3 temp = sc.roomPrefabList[((sc.stage + 4) * (int)playerCurPos.y) + (int)playerCurPos.x].transform.position;
        //    gameObject.transform.position = new Vector3(temp.x, 1.5f, temp.z);
        //    initCheck = true;
        //}   
    }

    public void playerPosInit()
    {
        StageCreate sc = GameObject.Find("GameManager").GetComponent<StageCreate>();

        playerCurPos = new Vector2(sc.GetStartPos() % (sc.stage + 4), sc.GetStartPos() / (sc.stage + 4));

        Vector3 temp = sc.roomPrefabList[((sc.stage + 4) * (int)playerCurPos.y) + (int)playerCurPos.x].transform.position;
        gameObject.transform.position = new Vector3(temp.x, 1.5f, temp.z);
    }
}
