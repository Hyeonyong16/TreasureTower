using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletTextUI : MonoBehaviour
{
    TextMeshProUGUI bulletText;

    PlayerStat playerStat;

    // Start is called before the first frame update
    void Start()
    {
        bulletText = GetComponent<TextMeshProUGUI>();
        playerStat = GameObject.Find("Player").gameObject.GetComponent<PlayerStat>();
    }

    // Update is called once per frame
    void Update()
    {
        bulletText.text = playerStat.CurrentAmmo.ToString() + " / " + playerStat.FullAmmo.ToString();
    }
}
