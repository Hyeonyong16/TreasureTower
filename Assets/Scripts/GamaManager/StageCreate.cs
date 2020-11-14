using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCreate : MonoBehaviour
{
    public GameObject Room1;
    public GameObject Room2;
    public GameObject Room3;
    public GameObject Room4;

    public GameObject StartZone;
    public GameObject FinishZone;
    public GameObject Shop;

    public float distance;

    public int stage;

    public int[] roomSetList;  //방목록
    public GameObject[] roomPrefabList;    //바닥에 깔은 방 프리팹목록

    // Start is called before the first frame update
    void Start()
    {
        roomSetList = new int[(stage+4)*(stage+4)];
        roomPrefabList = new GameObject[(stage + 4)*(stage + 4)];

        SetStageRoom(Random.Range(0, 10000));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetStageRoom(int seed)
    {
        Random.InitState(seed);

        int shopMax = stage + 1;
        int shopNum = 0;


        for(int i = 0; i < (stage+4)*(stage+4); i++)
        {
            int temp = Random.Range(1, 6);
            if(temp == 5)
            {
                if (shopNum >= shopMax) {
                    temp = Random.Range(1, 5);
                }

                else
                {
                    shopNum++;
                }
            }

            roomSetList[i] = temp;
        }

        if (Random.Range(0, 2) == 0)
        {
            roomSetList[0] = 0;                                 //시작
            roomSetList[(stage + 4) * (stage + 4) - 1] = 6;     //끝
        }

        else
        {
            roomSetList[stage + 3] = 0;                     //시작
            roomSetList[(stage + 4) * (stage + 3)] = 6;     //끝
        }

        SetRoomList();
    }   //방 배치

    void SetRoomList()
    {
        for(int i = 0; i < stage+4; i++)
        {
            for(int j = 0; j < stage+4; j++)
            {
                switch (roomSetList[((stage + 4) * i) + j])
                {
                    case 0:
                        roomPrefabList[((stage + 4) * i) + j] = Instantiate(StartZone, new Vector3((i * distance), 0, (j * distance)), Quaternion.identity);
                        break;
                    case 1:
                        roomPrefabList[((stage + 4) * i) + j] = Instantiate(Room1, new Vector3((i * distance), 0, (j * distance)), Quaternion.identity);
                        break;
                    case 2:
                        roomPrefabList[((stage + 4) * i) + j] = Instantiate(Room2, new Vector3((i * distance), 0, (j * distance)), Quaternion.identity);
                        break;
                    case 3:
                        roomPrefabList[((stage + 4) * i) + j] = Instantiate(Room3, new Vector3((i * distance), 0, (j * distance)), Quaternion.identity);
                        break;
                    case 4:
                        roomPrefabList[((stage + 4) * i) + j] = Instantiate(Room4, new Vector3((i * distance), 0, (j * distance)), Quaternion.identity);
                        break;
                    case 5:
                        roomPrefabList[((stage + 4) * i) + j] = Instantiate(Shop, new Vector3((i * distance), 0, (j * distance)), Quaternion.identity);
                        break;
                    case 6:
                        roomPrefabList[((stage + 4) * i) + j] = Instantiate(FinishZone, new Vector3((i * distance), 0, (j * distance)), Quaternion.identity);
                        break;
                }
            }
        }
    }
}
