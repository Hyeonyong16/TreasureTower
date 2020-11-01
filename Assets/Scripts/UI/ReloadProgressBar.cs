using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadProgressBar : MonoBehaviour
{
    private PlayerStat playerStat;
    public GameObject reloadUI;
    public Slider reloadProgressBar;

    private float time;
    private bool reloadTimerCheck;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        reloadTimerCheck = false;
        playerStat = GameObject.Find("Player").gameObject.GetComponent<PlayerStat>();
    }

    // Update is called once per frame
    void Update()
    {
        if(reloadTimerCheck)
        {
            time += Time.deltaTime;
        }

        if (reloadProgressBar.value < 1)
        {
            Debug.Log(time);
            reloadProgressBar.value = (float)time / (float)playerStat.ReloadTime;
        }
    }

    public void timerReset()
    {
        time = 0;
        reloadTimerCheck = false;
        reloadProgressBar.value = 0;
        Debug.Log(reloadTimerCheck);
    }

    public void timerStart()
    {
        reloadTimerCheck = true;
    }
}
