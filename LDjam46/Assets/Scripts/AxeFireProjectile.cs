using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeFireProjectile : MonoBehaviour
{
    private AudioSource aSource;
    public Transform spawnPos;
    public GameObject projectile;
    public boomerang Boom;
    public float fireRate = 1f;
    PlayerCamera cam;
    GameObject spawnBulletPos;
    
    private float nextTimeToFire = 0f;
    // Start is called before the first frame update
    void Start()
    {
        aSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") &&Boom.go==false)
        {
            aSource.Play();
           Boom.go = true;
        }
      
    }
}
