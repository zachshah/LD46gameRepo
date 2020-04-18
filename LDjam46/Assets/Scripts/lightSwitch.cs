using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lightSwitch : MonoBehaviour
{
    public float lightVal;
    public float lightIncreaseRate;
    public int isInZone;
    public Image lightUi;
    // Start is called before the first frame update
    void Start()
    {
        lightUi = FindObjectOfType<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        lightUi.fillAmount = lightVal / 50;
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
