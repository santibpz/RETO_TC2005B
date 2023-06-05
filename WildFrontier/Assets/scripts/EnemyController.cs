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
    [SerializeField] public NavMeshAgent enemyAgent;
    [SerializeField] float attackRadius;

    Vector3 direction;

    [SerializeField] EnemyMovement impaler;
   // [SerializeField] EnemyMovement impaler;
    // Start is called before the first frame update
    void Start()
    {
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

        direction = enemyAgent.desiredVelocity;

        EndAttack();
    }

    private void TriggerAttack()
    {
        if(enemy.name == "Impaler")
        {
            if (Vector3.Distance(enemyAgent.transform.position, player.transform.position) <= attackRadius)
            {
                enemyAgent.isStopped = true;
                if (direction.x > 0.7)
                {
                    impaler.animator.SetBool("CanAttackRight", true);
                }
                else if (direction.x < -0.7)
                {
                    impaler.animator.SetBool("CanAttackLeft", true);

                }
                else if (direction.y > 0.7)
                {
                    impaler.animator.SetBool("CanAttackUp", true);

                }
                else if (direction.y < -0.7)
                {
                    impaler.animator.SetBool("CanAttackDown", true);

                }
            }
            else
            {

                enemyAgent.isStopped = false;
                impaler.animator.SetBool("CanAttackRight", false);
                impaler.animator.SetBool("CanAttackLeft", false);
                impaler.animator.SetBool("CanAttackUp", false);
                impaler.animator.SetBool("CanAttackDown", false);

            }
        }
            
    }


    private void EndAttack()
    {
        if (player.GetComponent<PlayerController>().health == 0 || wolf.GetComponent<WolfAgentMovement>().health == 0)
        {
            enemyAgent.isStopped = true;
            player.GetComponent<PlayerController>().isDead = true;
            impaler.animator.SetBool("CanAttackRight", false);
            impaler.animator.SetBool("CanAttackLeft", false);
            impaler.animator.SetBool("CanAttackUp", false);
            impaler.animator.SetBool("CanAttackDown", false);
        }
    }


}
