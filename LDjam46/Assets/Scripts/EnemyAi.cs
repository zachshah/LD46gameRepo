using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    private AudioSource aSource;
    public float health;
    public GameObject playerPos;
    public NavMeshAgent agent;
    public PlayerMovement pMove;
    public bool isChasingPlayer;
    public GameObject[] allLights;
    public int maxEnemies;
    private bool notDeadYet = false;
    // Start is called before the first frame update
    void Start()
    {
        aSource = GetComponent<AudioSource>();
        health = 100;
       
       
        playerPos = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        pMove = playerPos.GetComponent<PlayerMovement>();
        

        
        allLights = GameObject.FindGameObjectsWithTag("Light");

        if (FindClosestTarget().transform.parent.gameObject.GetComponent<lightSwitch>().lightVal<5)
        {
            
            agent.SetDestination(allLights[Random.Range(0,3)].transform.position);
        }
        else
        {
            agent.SetDestination(FindClosestTarget().transform.position);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (health <= 0&&!notDeadYet)
        {
            notDeadYet = true;
            aSource.Play();
        }
        if (health <= 0)
        {
            GetComponent<NavMeshAgent>().enabled = false;
            transform.position += new Vector3(0, 100, 0);
        }
        if (GetComponent<NavMeshAgent>().enabled == false)
        {
            StartCoroutine(DestroyEnemy());
        }
        if (isChasingPlayer)
        {
            transform.LookAt(new Vector3(playerPos.transform.position.x, transform.position.y, playerPos.transform.position.z));
            agent.SetDestination(playerPos.transform.position);
        }
        else
        {
            transform.LookAt(new Vector3(agent.destination.x, transform.position.y, agent.destination.z));
        }
    }
    void LateUpdate()
    {
        if (pMove.enemiesChasingThisObject.Count < maxEnemies) {
            if (isChasingPlayer == false)
            {
                pMove.enemiesChasingThisObject.Add(this.gameObject);
                isChasingPlayer = true;

            }
        }
        
    }
    public GameObject FindClosestTarget()
    {
        GameObject[] possibleTargets;
        possibleTargets = GameObject.FindGameObjectsWithTag("Light");
       
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject possibleTarget in possibleTargets)
        {
            Vector3 diff = possibleTarget.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = possibleTarget;
                distance = curDistance;
            }
        }
        return closest;
    }
    IEnumerator DestroyEnemy()
    {
      
        yield return new WaitForSeconds(.4f);
        Destroy(this.gameObject);
    }
}
