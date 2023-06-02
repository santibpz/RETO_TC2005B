// script for controlling an enemy
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyController : MonoBehaviour
{
    [SerializeField] public Enemy enemy;
    [SerializeField] GameObject player;
    [SerializeField] GameObject wolf;
    public NavMeshAgent enemyAgent;
    [SerializeField] float attackRadius;

    [SerializeField] ImpalerMovement impaler;
    // Start is called before the first frame update
    void Start()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
        enemyAgent.updateRotation = false;
        enemyAgent.updateUpAxis = false;
    }


    // Update is called once per frame
    void Update()
    {
        
        if(enemy.name == "Impaler" || enemy.name == "Marauder")
        {
            enemyAgent.SetDestination(player.transform.position);
        } else if(enemy.name == "Grim")
        {
            enemyAgent.SetDestination(wolf.transform.position);
        }
        TriggerAttack();


    }

    private void TriggerAttack()
    {
        if(enemy.name == "Impaler")
        {
            if (Vector3.Distance(enemyAgent.transform.position, player.transform.position) <= attackRadius)
            {
                enemyAgent.isStopped = true;
                impaler.animator.SetBool("isInAttackRange", true);
            }
            else
            {
                enemyAgent.isStopped = false;
                impaler.animator.SetBool("isInAttackRange", false);
            }
        }
        
    }

    

}
