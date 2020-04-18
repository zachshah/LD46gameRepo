using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateToAllign : MonoBehaviour
{
    public bool collisionCount=false;
   
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (collisionCount == false)
        {
            transform.rotation *= Quaternion.Euler(0,90,0);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Floor") {
            collisionCount = true;
          
        }
      //  Debug.Log("AYYYY");
       
    }
    private void OnTriggerExit(Collider other)
    {
        collisionCount = false;
    }
}
