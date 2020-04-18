using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    public GameObject playerPos;
    public NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(new Vector3(playerPos.transform.position.x, transform.position.y, playerPos.transform.position.z));
    }
    void LateUpdate()
    {
        agent.SetDestination(playerPos.transform.position);
    }
}
