using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pointManage : MonoBehaviour
{
    public Image goodPt;
    public Image badPt;

    public Image guiOne;
    public Image guiTwo;
    public Image guiThree;
    public Image guiFour;
    public int pointTotal;
    private int guiPtOne;
    private int guiPtTwo;
    private int guiPtThree;
    private int guiPtFour;
    public float goodTally;
    public float badTally;
    public int tallyMax;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (badPt.fillAmount == 1)
        {

        }
        if (goodPt.fillAmount == 1)
        {

        }
        badPt.fillAmount = badTally / tallyMax;
        goodPt.fillAmount = goodTally / tallyMax;

        if (pointTotal > 0)
        {
            if (goodTally < tallyMax)
                goodTally += pointTotal * Time.deltaTime;
            
        }else if (pointTotal < 0)
        {
            if(badTally<tallyMax)
            badTally += Mathf.Abs(pointTotal) * Time.deltaTime;
           
        }
        pointTotal = guiPtOne + guiPtTwo + guiPtThree + guiPtFour;


        if (guiOne.fillAmount >= .6)
        {
            guiPtOne = 1;
        }else if(guiOne.fillAmount <= .4)
        {
            guiPtOne = -1;
        }
        else
        {
            guiPtOne = 0;
        }

        if (guiTwo.fillAmount >= .6)
        {
            guiPtTwo = 1;
        }
        else if (guiTwo.fillAmount <= .4)
        {
            guiPtTwo = -1;
        }
        else
        {
            guiPtTwo = 0;
        }

        if (guiThree.fillAmount >= .6)
        {
            guiPtThree = 1;
        }
        else if (guiThree.fillAmount <= .4)
        {
            guiPtThree = -1;
        }
        else
        {
            guiPtThree = 0;
        }

        if (guiFour.fillAmount >= .6)
        {
            guiPtFour = 1;
        }
        else if (guiFour.fillAmount <= .4)
        {
            guiPtFour = -1;
        }
        else
        {
            guiPtFour = 0;
        }
    }
}
