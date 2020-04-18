using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstFIreProjectile : MonoBehaviour
{
    public Transform spawnPos;
    public GameObject projectile;
    public float fireRate = 1f;
    PlayerCamera cam;
    GameObject spawnBulletPos;

    private float nextTimeToFire = 0f;
    // Start is called before the first frame update
    void Start()
    {
        cam = FindObjectOfType<PlayerCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1")&&Time.time>=nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1 / fireRate;
            StartCoroutine(FireBurst(projectile, 3, .1f));
        }
    }
    public IEnumerator FireBurst(GameObject bulletPrefab, int burstSize, float rateOfFire)
    {
        
        // rate of fire in weapons is in rounds per minute (RPM), therefore we should calculate how much time passes before firing a new round in the same burst.
        for (int i = 0; i < burstSize; i++)
        {
            spawnBulletPos = Instantiate(bulletPrefab,spawnPos.position,spawnPos.rotation); // It would be wise to use the gun barrel's position and rotation to align the bullet to.
            cam.Shake((transform.position - spawnBulletPos.transform.position).normalized, 1.5f, 0.05f);
           

            yield return new WaitForSeconds(rateOfFire); // wait till the next round
        }
    }
}
