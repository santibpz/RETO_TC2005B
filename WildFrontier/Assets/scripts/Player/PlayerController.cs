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

    [SerializeField] GameManager gameManager;

    [SerializeField] Attack attack;
    [SerializeField] public FloatingHealthBar healthBar;

    public Rigidbody2D rb;
    [SerializeField] float moveSpeed;

    [SerializeField] CharacterState Idle;

    [SerializeField] CharacterState Walk;

    [SerializeField] CharacterState UseTool;

    [SerializeField] CharacterState UseSword;

    [SerializeField] CharacterState UseSpear;

    [SerializeField] CharacterState UseKnife;

    public AnimationClip deathAnim;


    [SerializeField] StateAnimationsSetDictionary StateAnimations;

    private bool canAttack = true; // Variable to control if an attack can be performed
    public float attackCooldown = 1f; // Cooldown time between attacks

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
    private float attackCooldownTimer = 0f; // Timer for attack cooldown

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

        if(health <= 0)
        {
            gameManager.endgame = true;
            animator.Play(deathAnim.name);
        }

        // Update attack cooldown timer
        attackCooldownTimer -= Time.deltaTime;
        if (attackCooldownTimer <= 0)
        {
            canAttack = true; // Allow attack if cooldown has finished
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
        if (attack.weaponToUse != null)
        {
            if (attack.weaponToUse.name == "Sword")
            {
                CurrentState = UseSword;
            }
            else if (attack.weaponToUse.name == "Spear")
            {
                CurrentState = UseSpear;
            }
            else if (attack.weaponToUse.name == "Knife")
            {
                CurrentState = UseKnife;
            }
            else
            {
                return;
            }
        }

    }

    private void OnUse()
    {
        CurrentState = UseTool;
    }

    private void OnAttack()
    {
        if (canAttack)
        {
            Debug.Log("Attack action triggered");
            GetAttackState();

            // Start attack cooldown
            canAttack = false;
            attackCooldownTimer = attackCooldown;
        }
    }
}
