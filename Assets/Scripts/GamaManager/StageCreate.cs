using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCreate : MonoBehaviour
{
    public bool checkTest = false;

    public GameObject StartZone;    //0
    public GameObject Room1;        //1
    public GameObject Room2;        //2
    public GameObject Room3;        //3
    public GameObject Room4;        //4
    public GameObject Shop;         //5
    public GameObject FinishZone;   //6

    public float distance;

    public int stage;

    public int[] roomSetList;  //방목록
    public GameObject[] roomPrefabList;    //바닥에 깔은 방 프리팹목록

    public Vector2 _PlayerPos;

    // Start is called before the first frame update
    void Start()
    {
        roomSetList = new int[(stage + 4) * (stage + 4)];
        roomPrefabList = new GameObject[(stage + 4) * (stage + 4)];

        SetStageRoom(Random.Range(0, 10000));
    }

    // Update is called once per frame
    void Update()
    {
        CreatePosRoom(_PlayerPos);
    }

    void SetStageRoom(int seed)
    {
        Random.InitState(seed);

        int shopMax = stage + 1;
        int shopNum = 0;


        for (int i = 0; i < (stage + 4) * (stage + 4); i++)
        {
            int temp = Random.Range(1, 6);
            if (temp == 5)
            {
                if (shopNum >= shopMax)
                {
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
        for (int i = 0; i < stage + 4; i++)
        {
            for (int j = 0; j < stage + 4; j++)
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
                roomPrefabList[((stage + 4) * i) + j].transform.SetParent(GameObject.Find("StageRooms").gameObject.transform);
                roomPrefabList[((stage + 4) * i) + j].SetActive(false);

            }
        }
    }

    public void CreatePosRoom(Vector2 playerPos)
    {
        int x = (int)playerPos.x;
        int y = (int)playerPos.y;
        bool[] roomActiveCheck = new bool[(stage+4)*(stage+4)];

        for (int i = 0; i < (stage + 4) * (stage + 4); i++)
            roomActiveCheck[i] = false;

        roomActiveCheck[((stage + 4) * y) + x] = true;

        if (x == 0)
        {
            if (y == 0)
            {
                roomActiveCheck[((stage + 4) * (y+1)) + x] = true;
                roomActiveCheck[((stage + 4) * y) + (x+1)] = true;
            }

            else if (y == (stage + 3))
            {
                roomActiveCheck[((stage + 4) * (y-1)) + x] = true;
                roomActiveCheck[((stage + 4) * y) + (x+1)] = true;
            }

            else
            {
                roomActiveCheck[((stage + 4) * (y-1)) + x] = true;
                roomActiveCheck[((stage + 4) * y) + (x+1)] = true;
                roomActiveCheck[((stage + 4) * (y+1)) + x] = true;
            }
        }

        else if(x == (stage + 3))
        {
            if (y == 0)
            {
                roomActiveCheck[((stage + 4) * (y+1)) + x] = true;
                roomActiveCheck[((stage + 4) * y) + (x-1)] = true;
            }

            else if (y == (stage + 3))
            {
                roomActiveCheck[((stage + 4) * y) + (x-1)] = true;
                roomActiveCheck[((stage + 4) * (y-1)) + x] = true;
            }

            else
            {
                roomActiveCheck[((stage + 4) * (y-1)) + x] = true;
                roomActiveCheck[((stage + 4) * y) + (x-1)] = true;
                roomActiveCheck[((stage + 4) * (y+1)) + x] = true;
            }
        }

        else//여기고칠차례
        {
            if (y == 0)
            {
                roomActiveCheck[((stage + 4) * y) + (x-1)] = true;
                roomActiveCheck[((stage + 4) * y) + (x+1)] = true;
                roomActiveCheck[((stage + 4) * (y+1)) + x] = true;
            }

            else if (y == (stage + 3))
            {
                roomActiveCheck[((stage + 4) * y) + (x - 1)] = true;
                roomActiveCheck[((stage + 4) * y) + (x + 1)] = true;
                roomActiveCheck[((stage + 4) * (y-1)) + x] = true;
            }

            else
            {
                roomActiveCheck[((stage + 4) * y) + (x - 1)] = true;
                roomActiveCheck[((stage + 4) * (y - 1)) + x] = true;
                roomActiveCheck[((stage + 4) * y) + (x + 1)] = true;
                roomActiveCheck[((stage + 4) * (y + 1)) + x] = true;
            }
        }

        for (int i = 0; i < (stage + 4) * (stage + 4); i++)
        {
            if(checkTest)
                roomPrefabList[i].SetActive(true);

            else
                roomPrefabList[i].SetActive(roomActiveCheck[i]);
        }
    }
}
