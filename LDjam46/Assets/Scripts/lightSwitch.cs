using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lightSwitch : MonoBehaviour
{
    public float lightVal=26f;
    public float lightIncreaseRate;
    public int isInZone;
    public SpriteRenderer mySprt;
 
    // Start is called before the first frame update
    void Start()
    {
        lightVal = Random.Range(23, 26);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isInZone>0)
        {
            if (lightVal < 50)
            {
                lightVal += lightIncreaseRate*(isInZone/2) * Time.deltaTime;
            }
            Debug.Log("light on, light val: " + lightVal);
        }else if (isInZone < 0)
        {
            if (lightVal > 2)
            {
               
                lightVal += lightIncreaseRate * (isInZone / 2) * Time.deltaTime;
            }
        }
        if (lightVal > 30)
        {
            mySprt.color = Color.green;
        }
       else if (lightVal < 20)
        {
            mySprt.color = Color.red;
        }
        else
        {
            mySprt.color = Color.yellow;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isInZone +=3;
        }
        if (other.gameObject.tag == "Enemy")
        {
            isInZone -= 1;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isInZone -=3;
        }
        if (other.gameObject.tag == "Enemy")
        {
            isInZone += 1;
        }
    }
}
