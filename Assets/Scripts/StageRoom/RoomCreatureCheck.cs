using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCreatureCheck : MonoBehaviour
{
    public bool playerEnterCheck = false;   //플레이어 입장여부 확인
    public bool playerRoomClear = false;    //현재 방의 클리어 여부 확인

    public int monsterCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerEnterCheck = true;

            StageCreate sc = GameObject.Find("GameManager").GetComponent<StageCreate>();
            int temp = 0;
            Debug.Log(gameObject.transform.parent.gameObject);
            for (int i = 0; i < (sc.stage+4)*(sc.stage+4); i++)
            {
                if(gameObject.transform.parent.gameObject == sc.roomPrefabList[i])
                {
                    Debug.Log(i);
                    temp = i;
                    other.GetComponent<PlayerPosition>().playerCurPos = new Vector2(temp % (sc.stage + 4), temp / (sc.stage + 4));
                    break;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            playerEnterCheck = false;
            //playerRoomClear = true;
        }
    }
}
