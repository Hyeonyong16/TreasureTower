using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStat : MonoBehaviour
{
    public float enemyHP = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyHP <= 0)
        {
            PlayerAttack playerAttack = GameObject.Find("Player").gameObject.GetComponent<PlayerAttack>();
            playerAttack.enemyBulletEffect.SetActive(false);
            Destroy(gameObject, 0.1f);
        }
    }
}
