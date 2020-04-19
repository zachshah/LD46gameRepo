using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPlayer : MonoBehaviour
{
    private GameObject playerP;
    public int whichPnum;
    public GameObject p1;
    public GameObject p2;
    public GameObject p3;
    public GameObject p4;
    public bool spawned;
    // Start is called before the first frame update
    void Start()
    {
        playerP = GameObject.FindGameObjectWithTag("PlayerPref");
        whichPnum = playerP.GetComponent<ChangePlayer>().whichPnum;
    }

    // Update is called once per frame
    void Update()
    {
        if (!spawned)
        {
            if (whichPnum == 0)
            {

                Instantiate(p1, transform.position, transform.rotation);
            }
            if (whichPnum == 1)
            {
                Instantiate(p2, transform.position, transform.rotation);
            }
            if (whichPnum == 2)
            {
                Instantiate(p3, transform.position, transform.rotation);
            }
            if (whichPnum == 3)
            {
                Instantiate(p4, transform.position, transform.rotation);
            }
            spawned = true;
        }
    }
}
