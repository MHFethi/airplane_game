using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyMotor : MonoBehaviour
{
    public GameObject player;
    public float distance;

    public bool isTriggered;

    public NavMeshAgent agent;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.transform.position, this.transform.position);

        isTriggered = distance <= 5f;// Ternary expression : if(distance <= 5f) ... else ...

        if (isTriggered)
        {
            agent.isStopped = false;
            agent.SetDestination(player.transform.position);
        }
        else
            agent.isStopped = true;
    }
    
}
