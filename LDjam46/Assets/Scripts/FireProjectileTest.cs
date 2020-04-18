using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectileTest : MonoBehaviour
{
    public GameObject projectile;
    public Transform spawnPos;

    public bool isFiring = false;
   
    PlayerCamera cam;
    GameObject spawnBulletPos;

    public float timeBetweenShots;
    private float shotCounter;
    // Start is called before the first frame update
    void Start()
    {
        cam = FindObjectOfType<PlayerCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFiring)
        {
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0)
            {

                shotCounter = timeBetweenShots;
               

                spawnBulletPos = Instantiate(projectile, spawnPos.position, spawnPos.rotation);
                cam.Shake((transform.position - spawnBulletPos.transform.position).normalized, 3.5f, 0.05f);
            }
        }
        else
        {
            shotCounter = 0;
        }

        if (Input.GetButton("Fire1"))
        {
            isFiring = true;
        }
        else
        {
            isFiring = false;
        }


    }
}
