using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameChargeFireProjectile : MonoBehaviour
{
    public GameObject projectileStationary;
    public GameObject projectileFirable;
    public Transform SpawnPos;
    public float scaleSpeed;
    private GameObject chargeShot;
    private GameObject fireShot;
    PlayerCamera cam;
    // Use this for initialization
    void Start()
    {
        cam = FindObjectOfType<PlayerCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {

            chargeShot = Instantiate(projectileStationary, SpawnPos.position, SpawnPos.rotation);
            chargeShot.transform.parent = SpawnPos.gameObject.transform;
            chargeShot.transform.localScale = new Vector3(.7f, .7f, .7f);
        }
        if (Input.GetButton("Fire1"))
        {

            if (chargeShot.transform.localScale.x <= 5f)
            {

                chargeShot.transform.localScale += chargeShot.transform.localScale * (scaleSpeed * Time.deltaTime);
            }
        }
        if (Input.GetButtonUp("Fire1"))
        {

            Destroy(chargeShot);
            fireShot = Instantiate(projectileFirable, SpawnPos.position, SpawnPos.rotation);
            
            cam.Shake((transform.position - fireShot.transform.position).normalized, chargeShot.transform.localScale.x, 0.1f);
            fireShot.transform.localScale = chargeShot.transform.localScale/2;
            if (fireShot.transform.localScale.x > 2.45)
            {
                fireShot.GetComponent<Bullet>().health = 2;
            }
        }
    }
}
