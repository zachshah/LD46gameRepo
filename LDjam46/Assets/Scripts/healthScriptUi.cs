﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class healthScriptUi : MonoBehaviour
{
    private GameObject player;
    private Image healthStat;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        healthStat = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        healthStat.fillAmount = player.GetComponent<PlayerMovement>().health / 100;
    }
}