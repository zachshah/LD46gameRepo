using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class healthScriptUi : MonoBehaviour
{
    public GameObject player;
    private Image healthStat;
    public float startHealth;
    public bool healthed;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        healthStat = GetComponent<Image>();
        startHealth = player.GetComponent<PlayerMovement>().health;
       
    }
   
    // Update is called once per frame
    void Update()
    {
        if (startHealth != 0)
        {
            healthed = true;
        }
        player = GameObject.FindGameObjectWithTag("Player");
        if (healthed)
        {
            healthStat.fillAmount = player.GetComponent<PlayerMovement>().health / startHealth;
        }
        else
        {
            startHealth = player.GetComponent<PlayerMovement>().health;
        }
    }
}
