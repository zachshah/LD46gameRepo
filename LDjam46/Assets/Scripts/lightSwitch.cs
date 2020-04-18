using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightSwitch : MonoBehaviour
{
    public float lightVal;
    public float lightIncreaseRate;
    private bool isInZone;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isInZone)
        {
            lightVal += lightIncreaseRate * Time.deltaTime;
            Debug.Log("light on, light val: " + lightVal);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isInZone = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isInZone = false;
        }
    }
}
