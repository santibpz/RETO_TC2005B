// script for controlling an enemy
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyController : MonoBehaviour
{
    [SerializeField] public Enemy enemy;
    GameObject player;
    GameObject wolf;
    [SerializeField] public NavMeshAgent enemyAgent;
    [SerializeField] float attackRadius;
    [SerializeField] public FloatingHealthBar healthBar;

    Vector3 direction;

    public int health;

    Vector3 target;

    [SerializeField] EnemyMovement enemyGraphic;
   // [SerializeField] EnemyMovement impaler;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        wolf = GameObject.FindGameObjectWithTag("Wolf");
        health = enemy.health;
        enemyAgent.updateRotation = false;
        enemyAgent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        direction = enemyAgent.desiredVelocity;

        float distanceFromPlayer = Vector3.Distance(enemyAgent.transform.position, player.transform.position);
        float distanceFromWolf = Vector3.Distance(enemyAgent.transform.position, wolf.transform.position);

        float closestDistance = Mathf.Min(distanceFromPlayer, distanceFromWolf);

        if (closestDistance == distanceFromPlayer)
        {
            enemyAgent.SetDestination(player.transform.position);
            target = player.transform.position;
        }
        else if (closestDistance == distanceFromWolf)
        {
            enemyAgent.SetDestination(wolf.transform.position);
            target = wolf.transform.position;

        }

        if (Vector3.Distance(enemyAgent.transform.position, target) < attackRadius)
        {
            enemyAgent.isStopped = true;
            if (direction.x > 0.6)
            {
                enemyGraphic.animator.SetBool("CanAttackRight", true);
            }
            else if (direction.x < -0.6)
            {
                enemyGraphic.animator.SetBool("CanAttackLeft", true);
            }
            else if (direction.y > 0.6)
            {
                enemyGraphic.animator.SetBool("CanAttackUp", true);

            }
            else if (direction.y < -0.6)
            {
                enemyGraphic.animator.SetBool("CanAttackDown", true);

            }
        }
        else
        {
            enemyAgent.isStopped = false;
            enemyGraphic.animator.SetBool("CanAttackRight", false);
            enemyGraphic.animator.SetBool("CanAttackLeft", false);
            enemyGraphic.animator.SetBool("CanAttackUp", false);
            enemyGraphic.animator.SetBool("CanAttackDown", false);
        }


        //if(enemy.name == "Grim" || enemy.name == "Marauder")
        //{
        //    enemyAgent.SetDestination(player.transform.position);
        //} else if(enemy.name == "Impaler")
        //{
        //    enemyAgent.SetDestination(wolf.transform.position);
        //}

        //TriggerAttack();

        

        EndAttack();

        if(health <= 0)
        {
            StartCoroutine(DestroyEnemy());
        }

        healthBar.UpdateHealthBar(health, enemy.health);
    }

    private void TriggerAttack()
    {
        //if(enemy.name == "Impaler")
        //{
            if (Vector3.Distance(enemyAgent.transform.position, player.transform.position) <= attackRadius 
            || Vector3.Distance(enemyAgent.transform.position, wolf.transform.position) <= attackRadius)
            {
                enemyAgent.isStopped = true;
                if (direction.x > 0.6)
                {
                   enemyGraphic.animator.SetBool("CanAttackRight", true);
                }
                else if (direction.x < -0.6)
                {
                   enemyGraphic.animator.SetBool("CanAttackLeft", true);
                }
                else if (direction.y > 0.6)
                {
                   enemyGraphic.animator.SetBool("CanAttackUp", true);

                }
                else if (direction.y < -0.6)
                {
                   enemyGraphic.animator.SetBool("CanAttackDown", true);

                }
            }
            else
            {

                enemyAgent.isStopped = false;
                enemyGraphic.animator.SetBool("CanAttackRight", false);
                enemyGraphic.animator.SetBool("CanAttackLeft", false);
                enemyGraphic.animator.SetBool("CanAttackUp", false);
                enemyGraphic.animator.SetBool("CanAttackDown", false);

            }
       // }
            
    }


    private void EndAttack()
    {
        if (player.GetComponent<PlayerController>().health <= 0 || wolf.GetComponent<WolfAgentMovement>().health <= 0)
        {
            enemyAgent.isStopped = true;
            //player.GetComponent<PlayerController>().isDead = true;
            enemyGraphic.animator.SetBool("CanAttackRight", false);
            enemyGraphic.animator.SetBool("CanAttackLeft", false);
            enemyGraphic.animator.SetBool("CanAttackUp", false);
            enemyGraphic.animator.SetBool("CanAttackDown", false);
        }
    }

    IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }


}
