using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector2 movementInput;
    private Vector2 facingDirection;

    private Rigidbody2D rb;
    [SerializeField] float moveSpeed;

    [SerializeField] CharacterState Idle;

    [SerializeField] CharacterState Walk;

    [SerializeField] CharacterState Use;


    [SerializeField] StateAnimationsSetDictionary StateAnimations;

    public CharacterState CurrentState {
        get
        {
            return currentState;
        }
        set
        {
            if (currentState != value)
            {

                currentState = value;
                ChangeClip();
                timeToEndAnimation = currentClip.length;
            }
        }
    }

    private CharacterState currentState;

    private Animator animator;

    private AnimationClip currentClip;

    private float timeToEndAnimation = 0f;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        CurrentState = Idle;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = movementInput * moveSpeed * Time.deltaTime;

    }

    void Update()
    {
        timeToEndAnimation = Mathf.Max(timeToEndAnimation - Time.deltaTime, 0);
        if (currentState.CanExitWhilePlaying || timeToEndAnimation <= 0)
        {
            if (movementInput != Vector2.zero && rb.velocity.magnitude > 0.05f)
            {
                CurrentState = Walk;
            }
            else
            {
                CurrentState = Idle;
            }
            ChangeClip();
        }


    }

    private void ChangeClip()
    {
        AnimationClip facingClip = StateAnimations.GetAnimationClipFromState(facingDirection, currentState);
        if (currentClip == null || currentClip != facingClip)
        {
            currentClip = facingClip;
            animator.Play(facingClip.name);
        }
    }

    private void OnMove(InputValue inputValue)
    {
        movementInput = inputValue.Get<Vector2>();
        if(movementInput != Vector2.zero)
        {
            facingDirection = movementInput;
        }
    }

    private void OnUse()
    {
        CurrentState = Use;
    }


}
