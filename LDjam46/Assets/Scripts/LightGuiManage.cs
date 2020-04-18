using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightGuiManage : MonoBehaviour
{
    public List<GameObject> lightList = new List<GameObject>();
    public int whichLight;
    public bool checkedAlready;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitToCount());
    }

    // Update is called once per frame
    void Update()
    {
        if (checkedAlready)
        {
            float LightValue = lightList[whichLight].GetComponent<lightSwitch>().lightVal;
            GetComponent<Image>().fillAmount = LightValue / 50;
        }
    }
    void checkLights() {
        foreach (GameObject lightObj in GameObject.FindGameObjectsWithTag("Light"))
        {

            lightList.Add(lightObj.transform.parent.gameObject);
        }
        checkedAlready = true;
    }

IEnumerator waitToCount()
    {
        yield return new WaitForSeconds(5f);
        checkLights();
    }
}
