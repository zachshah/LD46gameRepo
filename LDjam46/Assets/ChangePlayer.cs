using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;




public class ChangePlayer : MonoBehaviour
{
    public Text whichPlayer;
    public int whichPnum;
    public GameObject playerToSpawn;
    public GameObject p1;
    public GameObject p2;
    public GameObject p3;
    public GameObject p4;
    // Start is called before the first frame update
    void Start()
    {
        whichPnum = 5;
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (whichPnum == 0)
        {
            whichPlayer.text = "SELECTED - SCORCH";
            playerToSpawn = p1;
        }
        if (whichPnum == 1)
        {
            whichPlayer.text = "SELECTED - PHASER";
            playerToSpawn = p2;
        }
        if (whichPnum == 2)
        {
            whichPlayer.text = "SELECTED - NOIR";
            playerToSpawn = p3;
        }
        if (whichPnum == 3)
        {
            whichPlayer.text = "SELECTED - AXEL";
            playerToSpawn = p4;
        }
    }
    public void pressed1()
    {
        whichPnum = 0;
    }
    public void pressed2()
    {
        whichPnum = 1;
    }
    public void pressed3()
    {
        whichPnum = 2;
    }
    public void pressed4()
    {
        whichPnum = 3;
    }
    public void loadFloor()
    {
        if(playerToSpawn!=null)
        SceneManager.LoadScene(1);
        else
            whichPlayer.text = "UP UP DOWN DOWN LEFT RIGHT LEFT RIGHT B A START - SELECT A PLAYER PLEASE - ";
    }
}
