using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserFireProjectile : MonoBehaviour
{
    public LayerMask layerMask;
    public LineRenderer lineR;
    public GameObject physicalMouse;
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        physicalMouse = GameObject.FindGameObjectWithTag("PhysicalMouse");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            lineR.enabled = true;
            RaycastHit hit;
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
            {
                if (hit.distance < 9.5)
                {
                    damage = (10 - hit.distance) *200* Time.deltaTime;
                }
                else
                {
                    damage = .5f*200*Time.deltaTime;
                }
                lineR.SetPosition(0, transform.position);
                if (hit.distance < Vector3.Distance(physicalMouse.transform.position, transform.position))
                {
                    lineR.SetPosition(1, hit.point);
                }
                else
                {
                    lineR.SetPosition(1, new Vector3(physicalMouse.transform.position.x, transform.position.y, physicalMouse.transform.position.z));
                }
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                Debug.Log("Did Hit");
                hit.collider.gameObject.GetComponent<EnemyAi>().health -= damage;
            }
            else
            {
                lineR.SetPosition(0, transform.position);
                lineR.SetPosition(1, new Vector3(physicalMouse.transform.position.x,transform.position.y, physicalMouse.transform.position.z));
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.green);
                Debug.Log("Did not Hit");
            }
        }
        else
        {
            lineR.enabled = false;
        }
    }
}
