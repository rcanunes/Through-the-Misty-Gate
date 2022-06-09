using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRb;

    private float speed;

    private float horizontalInput;
    private float verticalInput;

    //Ladder related variables
    private float climbingSpeed;
    public bool isLadder;
    public bool isClimbing;

   
    //Jump Related variables
    public bool isGrounded;
    public Transform feetPos;
    private float checkRadius = 0.2f;
    public LayerMask whatIsGround;


    public bool canHold; //If it can hold for a longer jump
    private float jumpTimeCounter; //Current Jump Time
    private float jumpTime; //Max jump Time
    private float jumpForce; // Jump Strength
    private float gravityScale;

    private float maxFallingSpped;
    
    // Spell Casting Variables
    private bool enterChargedCast = false;
    private float chargeDuration;
    private float elapsedCharge;
    private float knockbackAmount;
    private bool ignoreInput = false;


    // Animation Variables
    private bool idle;
    private Animator animator;
    private SpriteRenderer sr;

    //Player Sounds Variables
    private AudioSource audioSource;
    public AudioClip jumpSound;





    // Start is called before the first frame update
    void Start()
    {
        speed = 10;
        climbingSpeed = 10;
        gravityScale = 5;
        jumpTime = 0.4f;
        jumpForce = 11;
        maxFallingSpped = -10f;

        playerRb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        AnimationSetup();
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        
        if (enterChargedCast)
            ChargedCastingMovement();
        
        if (ignoreInput)
            return;

        Jump();
        Climbing();
        MoveCharacter();
    }


    private void Jump()
    {

        playerRb.gravityScale = gravityScale;

        if (isGrounded)
        {
            canHold = true;
        }

        //Jump if keys are pressed down in this frame and is on the ground
        if (GetJumpKeysDown() && isGrounded)
        {
            canHold = true;
            jumpTimeCounter = jumpTime;
            playerRb.velocity = Vector2.up * jumpForce;
            audioSource.PlayOneShot(jumpSound, 1);

        }

        //If the keys are being hold down, and can still hold
        else if (GetJumpKeys() && canHold)
        {

            if (jumpTimeCounter > 0 && playerRb.velocity.y > 0)
            { 
                playerRb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
        }

        else if (GetJumpKeysUp())
        {
            canHold = false;
        }

        ModifyPhysics();

    }

    private void ModifyPhysics()
    {
        if (playerRb.velocity.y < 0 && playerRb.velocity.y > maxFallingSpped)
            playerRb.AddForce(Vector2.down);
    }

    private void ChargedCastingMovement()
    {
        // Freeze position when casting a charged spell, enabled in EnterChargedCast()
        if (enterChargedCast)
        {
            ignoreInput = true;
            playerRb.constraints = RigidbodyConstraints2D.FreezeAll;
            
            if (elapsedCharge < chargeDuration) elapsedCharge += Time.deltaTime;
            else
            {
                playerRb.constraints = RigidbodyConstraints2D.FreezeRotation;
                enterChargedCast = false;
                StartCoroutine(Knockback());
            }
        }
    }

    private void Climbing()
    {
        verticalInput = Input.GetAxis("Vertical");
        if (isLadder && verticalInput != 0)
        {
            isClimbing = true;
        }
        else if (GetJumpKeysDown() || !isLadder)
        {
            isClimbing = false;
        }

        if (isClimbing)
        {
            playerRb.gravityScale = 0f;
            playerRb.velocity = new Vector2(playerRb.velocity.x, verticalInput * climbingSpeed);
        }
    }
    private void MoveCharacter()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        playerRb.velocity = new Vector2(horizontalInput * speed, playerRb.velocity.y);
    }

    private void AnimationSetup()
    {
        idle = true;
        horizontalInput = Input.GetAxis("Horizontal");

        // Moving
        if (horizontalInput != 0)
        {
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

    private IEnumerator Knockback()
    {
        float elapsed = 0;
        float duration = Mathf.Abs(knockbackAmount / 20.0f);

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            transform.position += new Vector3(knockbackAmount * Time.deltaTime, 0, 0);

            yield return new WaitForEndOfFrame();
        }
        
        ignoreInput = false;
    }

    public void EnterChargedCast(float chargeTime)
    {
        chargeDuration = chargeTime;
        elapsedCharge = 0;
        enterChargedCast = true;
    }

    public void SetKnockback(float knockback)
    {
        knockbackAmount = knockback;
    }


    private static bool GetJumpKeysDown()
    {
        return Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Z);
    }

    private static bool GetJumpKeys()
    {
        return Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Z);
    }
    private static bool GetJumpKeysUp()
    {
        return Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.Z);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = false;
        }
    }

}
