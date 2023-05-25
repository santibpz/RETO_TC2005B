// script for controlling wolf animation depending on the direction of the  movement
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfDirection : MonoBehaviour
{
    [SerializeField] WolfAgentMovement navmeshagent;
    public Animator animator;
    private Vector3 direction;
    public bool isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        SetAnimation();
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
