using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    public Vector2 playerCurPos;
    public Vector2 playerPrevPos;

    // Start is called before the first frame update
    void Start()
    {
        playerCurPos = new Vector2(0, 0);
        playerPrevPos = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
