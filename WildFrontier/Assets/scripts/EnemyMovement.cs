using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] EnemyController enemyController;
    [SerializeField] public Animator animator;
    [SerializeField] AnimationClip deathAnim;
    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        SetAnimation();

        if(enemyController.health==0)
        {
            animator.Play(deathAnim.name);
        }
    }

    void SetAnimation()
    {

        //animator.SetBool("isWalking", true);
        //direction = impaler.enemyAgent.desiredVelocity;
        direction = enemyController.enemyAgent.desiredVelocity;
        animator.SetFloat("x", direction.x);
        animator.SetFloat("y", direction.y);

    }
}

//generalize this script
