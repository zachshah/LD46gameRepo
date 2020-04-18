using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boomerang : MonoBehaviour
{
    public float howLongGoOut;
    public Transform returnLoc;
    public float speed;
    public bool go;
    private bool going;
    private bool sendBack;
    // Start is called before the first frame update
    void Start()
    {
        go = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (go == true&&!going)
        {
            going = true;
            StartCoroutine(Loop());
        }
        if (go == true && !sendBack)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if (go == true && sendBack)
        {
            transform.position = Vector3.MoveTowards(transform.position, returnLoc.position, speed*Time.deltaTime);
        }
    }
    IEnumerator Loop()
    {
        transform.parent = null;
        go = true;
        sendBack = false;
        yield return new WaitForSeconds(howLongGoOut);
        
        sendBack = true;
    }
    private void OnTriggerEnter(Collider other)
    {
       // Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Wall")
        {
            sendBack = true;
        }
        if (other.gameObject.tag == returnLoc.gameObject.tag&&sendBack)
        {
            
            transform.parent = returnLoc;
           
            go = false;
            going = false;
            sendBack = false;
            transform.position = returnLoc.position;
       
            transform.rotation = returnLoc.rotation;
           
          

        }
    }
}
