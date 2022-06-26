using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemies.EnemyTypes;

public class PlayerController : MonoBehaviour {
    private Rigidbody2D playerRb;

    private float baseSpeed;

    private float horizontalInput;
    private float verticalInput;

    //Ladder related variables
    private float climbingSpeed;
    public bool isLadder;
    public bool isClimbing;


    //Jump Related variables
    public Collider2D isGrounded;
    public Transform feetPos;
    private float checkRadius = 0.2f;
    public LayerMask whatIsGround;

    public bool jumpEnded;
    private float jumpTimeCounter; //Current Jump Time
    private float jumpTime; //Max jump Time
    private float baseJumpForce; // Jump Strength
    private float gravityScale;

    private float maxFallingSpped;

   

    // Spell Casting Variables
    private float knockbackAmount;
    private float knockbackBurst;
    private bool ignoreInput = false;


    // Animation Variables
    private bool idle;
    private Animator animator;
    private SpriteRenderer sr;

    //Player Sounds Variables
    private AudioSource audioSource;
    public AudioClip jumpSound;
    private bool groundIsIce;

    PlayerStats playerStats;
    SpellCaster spellCaster;

    private bool hasMoved;



    // Start is called before the first frame update
    void Start() {
        baseSpeed = 10;
        climbingSpeed = 10;
        gravityScale = 5;
        jumpTime = 0.4f;
        baseJumpForce = 11;
        maxFallingSpped = -10f;
        jumpEnded = true;

        playerRb        = GetComponent<Rigidbody2D>();
        audioSource     = GetComponent<AudioSource>();
        animator        = GetComponent<Animator>();
        sr              = GetComponent<SpriteRenderer>();
        playerStats     = gameObject.GetComponent<PlayerStats>();
        spellCaster     = gameObject.GetComponent<SpellCaster>();


    }


    // Update is called once per frame
    void Update() {
        AnimationSetup();
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        groundIsIce = CheckIfIce();
        hasMoved = false;
        playerRb.gravityScale = gravityScale;

        if (ignoreInput)
            return;

        Climbing();
        MoveCharacter();
        Jump();


        if (spellCaster.currentSpell != null)
        {
            if (hasMoved && spellCaster.currentSpell.cantMoveOnCharge)
                spellCaster.StopCasting();

            if (spellCaster.currentSpell.stopsMovementOnCharge && spellCaster.castingStatus == SpellCaster.CastingStatus.Casting)
            {
                playerRb.velocity *= 0;
                playerRb.gravityScale = 0;
            }

        }

        hasMoved = false;

    }


    private bool CheckIfIce() {
        if (isGrounded != null)
            return isGrounded.CompareTag("Ice");

        return false;
    }

    private void Jump() {

        float jumpForce = baseJumpForce * playerStats.jumpModifier.GetValue();

        if (isGrounded && GetJumpKeysDown() && jumpEnded) {
            jumpEnded = false;
            jumpTimeCounter = jumpTime;
            playerRb.velocity = new Vector2(playerRb.velocity.x, jumpForce);
            audioSource.PlayOneShot(jumpSound, 1);
            hasMoved = true;

        }

        else if (GetJumpKeys() && !jumpEnded) {
            if (jumpTimeCounter > 0 && playerRb.velocity.y > 0) {
                playerRb.velocity = new Vector2(playerRb.velocity.x ,jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
        }

        if (GetJumpKeysUp())
            jumpEnded = true;

        ModifyPhysics();

    }

    private void ModifyPhysics() {
        if (playerRb.velocity.y < 0 && playerRb.velocity.y > maxFallingSpped)
            playerRb.AddForce(Vector2.down);
    }

    private void Climbing() {
        verticalInput = Input.GetAxis("Vertical");
        if (isLadder && verticalInput != 0) {
            hasMoved = true;
            isClimbing = true;
        }
        else if (GetJumpKeysDown() || !isLadder) {
            isClimbing = false;
        }

        if (isClimbing) {
            playerRb.gravityScale = 0f;
            playerRb.velocity = new Vector2(playerRb.velocity.x, verticalInput * climbingSpeed);
        }
    }

    private void MoveCharacter()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        float speed = baseSpeed * playerStats.speedModifier.GetValue();

        if (groundIsIce || playerStats.iceBootsModifier.GetValue())
        {

            playerRb.velocity += new Vector2(horizontalInput * speed, 0);

            playerRb.velocity = new Vector2(Math.Clamp(playerRb.velocity.x, -speed, speed), playerRb.velocity.y);

            playerRb.velocity *= 0.99f;
            if (Mathf.Abs(playerRb.velocity.x) < 0.1)
            {
                playerRb.velocity = new Vector2(0, playerRb.velocity.y);
            }

        }
        else
        {
            playerRb.velocity = new Vector2(horizontalInput * speed, playerRb.velocity.y);

        }

        if (horizontalInput != 0)
            hasMoved = true;
    }


    private void AnimationSetup() {
        idle = true;
        horizontalInput = Input.GetAxis("Horizontal");

        // Moving
        if (horizontalInput != 0) {
            idle = false;
        }

        //
        if (horizontalInput < 0)
            sr.flipX = true;
        else if (horizontalInput > 0)
            sr.flipX = false;


        // Jumping
        if (!isGrounded)
            idle = false;

        if (idle)
            animator.SetTrigger("Idle");
        else
            animator.SetTrigger("Running");
    }

    public void KnockBack(Vector2 knockback)
    {
        StartCoroutine(KnockbackRoutine(knockback));
    }

    private IEnumerator KnockbackRoutine(Vector2 knockback) {

        if (knockback.magnitude == 0)
            yield break;

        ignoreInput = true;
        playerRb.velocity += knockback;
        yield return new WaitForSeconds(0.2f);
        ignoreInput = false;
    }


    public void SetKnockback(float amount, float burst) {
        knockbackAmount = amount;
        knockbackBurst = burst;
        Debug.Log("KnockbakAmount " + knockbackAmount.ToString() + " - KnockBackBurst" + knockbackBurst.ToString());
    }


    private static bool GetJumpKeysDown() {
        return Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Z);
    }

    private static bool GetJumpKeys() {
        return Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Z);
    }

    private static bool GetJumpKeysUp() {
        return Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.Z);
    }


    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Ladder")) {
            isLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Ladder")) {
            isLadder = false;
        }
    }

    // Ouchie Methods
    public void BeAttacked(Enemy enemy, int damage) {
        playerStats.TakeDamage(damage);
        Debug.Log("I was attacked by " + enemy.GetName() + " for " + damage);
    }
}
