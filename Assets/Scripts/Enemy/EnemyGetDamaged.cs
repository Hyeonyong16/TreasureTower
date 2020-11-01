using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGetDamaged : MonoBehaviour
{
    EnemyStat enemyStat;

    // Start is called before the first frame update
    void Start()
    {
        enemyStat = GetComponent<EnemyStat>();
    }

    private void Update()
    {
        
    }

    public void GetDamage(float damage)
    {
        if(enemyStat.enemyHP > 0)
            enemyStat.enemyHP -= damage;
    }
}
