// script for controlling wolf animation depending on the direction of the  movement
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfDirection : MonoBehaviour
{
    [SerializeField] WolfAgentMovement navmeshagent;
    [SerializeField] AnimationClip deathAnim;
    [SerializeField] Animator animator;
    private Vector3 direction;
    public bool isMoving = true;
    public int health = 100;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        SetAnimation();

        if(health == 0)
        {
            animator.Play(deathAnim.name);
        }
    }

    void SetAnimation()
    {
        if(isMoving)
        {
            animator.SetBool("isWalking", true);
            direction = navmeshagent.wolfAgent.desiredVelocity;
            animator.SetFloat("x", direction.x);
            animator.SetFloat("y", direction.y);
        } else
        {
            animator.SetBool("isWalking", false);
        }
    }


}
