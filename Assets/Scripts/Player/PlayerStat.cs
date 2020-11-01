using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    public int FullAmmo;
    public int CurrentAmmo;

    public float shotRate = 0.5f;    //총 발사속도
    public bool shotCheck = true;    //true = 발사가능 false = 발사불가능

    public float ReloadTime = 1.5f;     //장전 속도
    public bool ReloadCheck = false;    //true = 장전중 - 총 발사 안됨, false = 장전중이 아님 - 총 발사 됨

    public float playerDamage = 10.0f;  //플레이어 공격 데미지


    // Start is called before the first frame update
    void Start()
    {
        FullAmmo = 30;
        CurrentAmmo = 30;
        shotCheck = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
