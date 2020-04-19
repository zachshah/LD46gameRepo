using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pointManage : MonoBehaviour
{
    public bool isDead;
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

    private PlayerMovement pMove;

    private bool endisNie;

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        pMove = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        StartCoroutine(Begin());
    }
    IEnumerator Begin()
    {
       
        pMove.enabled = false;
        yield return new WaitForSeconds(7);
        anim.SetBool("isLoading", true);
        pMove.enabled = true;
    }
    IEnumerator Death()
    {
        anim.SetBool("isLoading", false);
        endisNie = true;
        anim.SetBool("Failed", true);
        Time.timeScale = .5f;
        yield return new WaitForSeconds(2);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        Time.timeScale = 1f;
    }
    IEnumerator nextFloor()
    {
        anim.SetBool("isLoading", false);
        endisNie = true;
        anim.SetBool("Success", true);
        Time.timeScale = .5f;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;

    }
    // Update is called once per frame
    void Update()
    {
        
        badPt.fillAmount = badTally / tallyMax;
        goodPt.fillAmount = goodTally / tallyMax;
        if (badPt.fillAmount == 1||isDead)
        {
            if (!endisNie)
            {
                
                StartCoroutine(Death());
            }
        }
        if (goodPt.fillAmount == 1)
        {
            if (!endisNie)
                StartCoroutine(nextFloor());
        }
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
