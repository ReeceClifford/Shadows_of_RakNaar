using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{  // Used for Player MoveMent and Knockback
    private float moveVelocity;
    public float defaultMoveSpeed = 5;
    public float moveSpeed;
    public float defaultJumpHeight = 15;
    public float jumpHeight;
    public float knockback;
    public float knockbackLength;
    public float knockbackCount;
    public bool knockFromRight;

    // Insanity Mechanic Varibles
    public float playerInsanity = 100;
    public bool checkInsanity = true;
    public int insanityEffect;
    public Transform insanityJumpHeight;
    public Transform insanityMoveSpeed;
    public Transform insanityRevert;
    public Transform insanityHealth;

    // Varibles to check is player is on the ground to jump
    public float groundCheckRadius;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    private bool grounded;
    private bool doubleJumped;

    // Player Animation
    private Animator anim;

    // Player Projectiles
    public Transform firePoint;
    public GameObject playerProjectile;
    public float fireDelay;
    public float fireDelayCount;
 
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        InvokeRepeating("InsanityMethod", 5.0f, 8.0f);
    }

    // Update is called once per frame
    void Update()
    {
        // Will make sure grounded before jump
        if (grounded)
            doubleJumped = false;
        anim.SetBool("Grounded", grounded);

        // Movement Keys
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.Space) && !doubleJumped && !grounded)
        {
            Jump();
            doubleJumped = true;
        }

        moveVelocity = 0f;

        if (Input.GetKey(KeyCode.D))
        {
            // GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            moveVelocity = moveSpeed;
        }

        if (Input.GetKey(KeyCode.A))
        {
           // GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            moveVelocity = -moveSpeed;
        }

        if (knockbackCount <= 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            if (knockFromRight)
                GetComponent<Rigidbody2D>().velocity = new Vector2(-knockback, knockback);
            if(!knockFromRight)
                GetComponent<Rigidbody2D>().velocity = new Vector2(knockback, knockback);
            knockbackCount -= Time.deltaTime;

        }

      
        anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
        // Animation for Turning
        if (GetComponent<Rigidbody2D>().velocity.x > 0)
            transform.localScale = new Vector3(1f, 1f, 1f);
                else if(GetComponent<Rigidbody2D>().velocity.x < 0)
                    transform.localScale = new Vector3(-1f, 1f, 1f);

        // Key for using projectiles
        if (Input.GetKeyDown(KeyCode.Q))
        {
          Instantiate(playerProjectile, firePoint.position, firePoint.rotation);
            fireDelayCount = fireDelay;
        }
     
        if (Input.GetKey(KeyCode.Q))
        {
            fireDelayCount -= Time.deltaTime;
            if(fireDelayCount <= 0)
            {
                fireDelayCount = fireDelay;
                Instantiate(playerProjectile, firePoint.position, firePoint.rotation);
            }
        }
        if (anim.GetBool("Sword"))
        {
            anim.SetBool("Sword", false);
        }
        if (Input.GetKey(KeyCode.E))
        {
            anim.SetBool("Sword", true);
        }
    }

    // Method for Jump
    public void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
    }
    // Method to check if Grounded
    private void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }
    

    // Isanity Mechanic Method
    void InsanityMethod()
    {
        if (checkInsanity == true)
        {
            var insanityCheck = Random.Range(0, 201);
            if (insanityCheck <= playerInsanity)
            {
                checkInsanity = false;
                insanityEffect = Random.Range(0,6);
                switch (insanityEffect)
                {
                    case 0:
                        {
                            jumpHeight = 20;
                            Debug.Log("Jump Increased");
                            StartCoroutine(InsanityEffectJumpHeight(insanityJumpHeight));
                            break;
                        }
                    case 1:
                        {
                            HealthManager.playerMaxHealth += 10;
                            Debug.Log("Health Increased");
                            HealthManager.playerHealth = HealthManager.playerMaxHealth;
                            StartCoroutine(InsanityEffectHealth(insanityHealth));
                            break;
                        }
                    case 2:
                        {
                            moveSpeed = 8; 
                            Debug.Log("Move Speed Increased");
                            StartCoroutine(InsanityEffectMoveSpeed(insanityMoveSpeed));
                            break;
                        }
                    case 3:
                        {
                            HealthManager.playerMaxHealth += 10;
                            Debug.Log("Health Increased");
                            HealthManager.playerHealth = HealthManager.playerMaxHealth;
                            StartCoroutine(InsanityEffectHealth(insanityHealth));
                            break;
                        }
                    case 4:
                        {
                            HealthManager.playerMaxHealth = 3;
                            Debug.Log("Health Decreased");
                            HealthManager.playerHealth = HealthManager.playerMaxHealth;
                            StartCoroutine(InsanityEffectHealth(insanityHealth));
                            break;
                        }
                    case 5:
                        {
                            moveSpeed = 3;
                            Debug.Log("Movespeed Decreased");
                            StartCoroutine(InsanityEffectMoveSpeed(insanityMoveSpeed));
                            break;
                        }
                }
            }

        }

    }
    IEnumerator InsanityEffectJumpHeight(Transform insanityJumpHeight)
    {
        yield return new WaitForSeconds(8.0f);
        jumpHeight = defaultJumpHeight;
        StartCoroutine(InsanityEffectResetCheck(insanityRevert));
    }
    IEnumerator InsanityEffectMoveSpeed(Transform insanityMoveSpeed)
    {
        yield return new WaitForSeconds(8.0f);
        moveSpeed = defaultMoveSpeed;
        StartCoroutine(InsanityEffectResetCheck(insanityRevert));
    }
    IEnumerator InsanityEffectHealth(Transform insanityHealth)
    {
        yield return new WaitForSeconds(8.0f);
        HealthManager.playerMaxHealth = HealthManager.defaultPlayerMaxHealth;
        HealthManager.playerHealth = HealthManager.playerMaxHealth;
        StartCoroutine(InsanityEffectResetCheck(insanityRevert));
    }
    IEnumerator InsanityEffectResetCheck(Transform insanityRevert)
    {
        yield return new WaitForSeconds(8.0f);
        checkInsanity = true;
    }
}









