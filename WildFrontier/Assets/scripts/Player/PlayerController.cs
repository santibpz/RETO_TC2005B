using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector2 movementInput;
    private Vector2 facingDirection;
    public int health = 100;
    public bool isDead = false;

    [SerializeField] Attack attack;
    [SerializeField] public FloatingHealthBar healthBar;

    public Rigidbody2D rb;
    [SerializeField] float moveSpeed;

    [SerializeField] CharacterState Idle;

    [SerializeField] CharacterState Walk;

    [SerializeField] CharacterState UseTool;

    [SerializeField] CharacterState UseSword;

    [SerializeField] CharacterState UseSpear;

    public AnimationClip deathAnim;


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

    public Animator animator;

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

        if(health == 0)
        {
            animator.Play(deathAnim.name);
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

    private void GetAttackState()
    {
        if(attack.weaponToUse.name == "sword")
        {
            CurrentState = UseSword;
        } else if(attack.weaponToUse.name == "spear")
        {
            CurrentState = UseSpear;
        } else
        {
            return;
        }
    }

    private void OnUse()
    {
        CurrentState = UseTool;
    }

    private void OnAttack()
    {
        Debug.Log("attack action trigggered");
        GetAttackState();
    }


}
