using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public Vector2 spawnWaveWaitTimeMinMax;
    public Vector2 spawnWaveInBetweenWaitTimeMinMax;
    public Vector2 SpawnWaveAmountMinMax;
    public GameObject enemyToSpawn;
    public GameObject enemySpawnPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(6f);
        while (1 == 1)
        {
           
            yield return new WaitForSeconds(Random.Range(spawnWaveWaitTimeMinMax.x, spawnWaveWaitTimeMinMax.y));
            for(int i=0;i< Random.Range(SpawnWaveAmountMinMax.x, SpawnWaveAmountMinMax.y); i++)
            {
                yield return new WaitForSeconds(Random.Range(spawnWaveInBetweenWaitTimeMinMax.x, spawnWaveInBetweenWaitTimeMinMax.y));
                Instantiate(enemyToSpawn, enemySpawnPoint.transform.position, enemySpawnPoint.transform.rotation);
            }
        }
    }
}
