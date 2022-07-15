using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
[Header("Movement")]
    [SerializeField]

    float MoveSpeed;
    [SerializeField]
    float MaxMoveSpeed;
    [SerializeField]
    float inputX;

    [Header("Jumping")]
    [SerializeField]
    float JumpForce;
    float jumpInputTimer;
    [SerializeField]
    float jumpInputDetectionTimer = 0.2f;
    [SerializeField]
    Transform GroundCheckPoint;
    [SerializeField]
    LayerMask WhatIsGround;
    [SerializeField]
    float GroundCheckRadius;
    public bool Grounded;

    [SerializeField]
    float KayottieTime;
    float kayottieTimer;

    [Range(0.0f, 1.0f)]
    [SerializeField]
    float jumpUnpressMultiply;

    [Range(0.0f, 1.0f)]
    [SerializeField]
    float damping;

    [Range(0.0f, 1.0f)]
    [SerializeField]
    float dampingWhenStop;

    [Range(0.0f, 1.0f)]
    [SerializeField]
    float dampingWhenMove;


    [Header("Physics")]
    Rigidbody2D Rb;

    // bool NoClip;
    // [SerializeField]
    // GameObject Spatula;
    BoxCollider2D bc;
    //  [SerializeField]
    // ParticleSystem ps;
    // [SerializeField]
    // GameObject jumpCloud;
    // [Header("AudioVisual")]
    // [SerializeField]
    // AudioSource DashSound;
    // [SerializeField]
    // Transform jumpEffectSpawnTransform;
   
    // [SerializeField]
    // AudioSource jumpSound;
    // float TimerWalk;
     [SerializeField]
     SpriteRenderer Sr;
    // [SerializeField]
    // GameObject footSteps;
//  [SerializeField]
//     ParticleSystem DashEffect;


    [Header("Dashing")]
    WeaponHandler weaponHandler;
   
    private Vector3 MoveDirection;
    [SerializeField]
    float Timer;
    public float DashTimer;
    [SerializeField]
    float DashSpeed;
    bool oneTime;
    public bool Recharged = true;
    bool blockAnim;
    bool CanMove = true;
    // [SerializeField]
    // GameObject DashBar;
    // [SerializeField]
    // Transform DashBarFill;
    public float regainDashTimer;
    [SerializeField]
    float AmountToMultplyRSToBeOne;

    void Start()
    {
        // if (jumpSound == null)
        // {
        //     jumpSound = GameObject.Find("_Jump_").GetComponent<AudioSource>();
        // }
        bc = GetComponent<BoxCollider2D>();
        Rb = GetComponent<Rigidbody2D>();
        weaponHandler = FindObjectOfType<WeaponHandler>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Time.timeScale == 1 && CanMove)
        {
            Walking();
        }

    }
    void Update()
    {
        if (Time.timeScale == 1)
        {
            Dash();
        }
        if (CanMove && Time.timeScale == 1)
        {
            Jumping();
        }


        // if (Input.GetKeyDown(KeyCode.V))
        // {
        //     NoClip = !NoClip;
        // }

        // Rb.isKinematic = NoClip;
        // bc.enabled = !NoClip;
        // Spatula.SetActive(NoClip);

    }


    void Dash()
    {
        Timer += Time.deltaTime;
        MoveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (Timer >= 0.20f)
        {
            Physics2D.IgnoreLayerCollision(18, 9, false);
            CanMove = true;
           // DashEffect.Stop();
        }
        if (Timer >= 0.22f && !oneTime)
        {
             weaponHandler.canShoot = true;
            Rb.velocity = new Vector2(Rb.velocity.x / 2, Rb.velocity.y / 2);
            Rb.gravityScale = 1f;
            regainDashTimer = 0f;
            // DashBarFill.localScale = new Vector3(0, 1, 1);
            // ph.CanBeDamaged = true;
            oneTime = true;
        }
        if (!Recharged && oneTime)
        {
            if (Grounded)
            {
                regainDashTimer += Time.deltaTime * 5;
            }
            else
            {
                regainDashTimer += Time.deltaTime;
            }

            // DashBar.SetActive(true);
            // DashBarFill.localScale = new Vector3(regainDashTimer * AmountToMultplyRSToBeOne, 1, 1);
        }
        else
        {
            // DashBar.SetActive(false);
        }
        if (regainDashTimer >= DashTimer && !Recharged)
        {
            regenDash();
        }


        if (Input.GetButtonDown("Fire2") && Recharged)
        {
            // DashSound.Play();
            if (MoveDirection.y != 0)
            {
                Physics2D.IgnoreLayerCollision(18, 9, true);
            }
            weaponHandler.canShoot = false;
            weaponHandler.RollGun();
            Rb.gravityScale = 0f;
            oneTime = false;
            blockAnim = false;
            // Sr.sprite = skin.DashSprite;
            // ph.CanBeDamaged = false;
           // DashEffect.Play();
            CanMove = false;
            Rb.velocity = new Vector2(0, 0);
            if (MoveDirection == new Vector3(0, 0))
            {
                if (Sr.flipX)
                {
                    Rb.AddForce(new Vector3(-1, 0) * DashSpeed, ForceMode2D.Impulse);
                }
                else
                {
                    Rb.AddForce(new Vector3(1, 0) * DashSpeed, ForceMode2D.Impulse);
                }

            }
            else
            {
                Rb.AddForce((MoveDirection.normalized) * DashSpeed, ForceMode2D.Impulse);
            }

            Timer = 0;
            Recharged = false;
        }
    }

    public void regenDash()
    {
        // Sr.sprite = skin.DashSprite;
        blockAnim = true;
        Invoke("unBlockAnim", 0.1f);
        regainDashTimer = 0f;

        Recharged = true;

        //       DashR.Play();
    }


    void Walking()
    {

        float inputX = Input.GetAxisRaw("Horizontal");
        // if (NoClip)
        // {
        //     Rb.velocity = new Vector2(inputX * MoveSpeed * 50f, Input.GetAxisRaw("Vertical") * MoveSpeed * 50f);
        // }
        {
            if (Grounded && inputX != 0)
            {
                // footSteps.SetActive(true);
            }
            else
            {
                // footSteps.SetActive(false);
            }
            float HorizontalVelocity = Rb.velocity.x;
            HorizontalVelocity += inputX * MoveSpeed;
            if (Mathf.Abs(inputX) < 0.1f)
            {
                HorizontalVelocity *= Mathf.Pow(1f - dampingWhenStop, Time.deltaTime * 10f);
            }
            else if (Mathf.Sign(inputX) != Mathf.Sign(HorizontalVelocity))
            {
                HorizontalVelocity *= Mathf.Pow(1f - dampingWhenMove, Time.deltaTime * 10f);
            }
            else
            {
                HorizontalVelocity *= Mathf.Pow(1f - damping, Time.deltaTime * 10f);
            }

            HorizontalVelocity = Mathf.Clamp(HorizontalVelocity, -MaxMoveSpeed, MaxMoveSpeed);
            Rb.velocity = new Vector2(HorizontalVelocity, Rb.velocity.y);
            if (inputX != 0 && !blockAnim)
            {

                //     if (ps.isPlaying == false)
                //    {
                //        ps.Play();
                //     }

            }
            else if (!blockAnim)
            {

                // TimerWalk = 0.12f;
                // Sr.sprite = skin.AfkSprite;
                //     ps.Stop();
            }


        }

    }

    void Jumping()
    {
        if (Time.timeScale == 1)
        {
            Grounded = Physics2D.OverlapCircle(GroundCheckPoint.position, GroundCheckRadius, WhatIsGround);
            jumpInputTimer -= Time.deltaTime;
            kayottieTimer -= Time.deltaTime;
            if (Input.GetButtonDown("Jump"))
            {
                jumpInputTimer = jumpInputDetectionTimer;
            }
            if (Input.GetButtonUp("Jump") && Rb.velocity.y > 0)
            {
                Rb.velocity = new Vector2(Rb.velocity.x, Rb.velocity.y * jumpUnpressMultiply);
            }
            if (Grounded && (Rb.velocity.y < 0.0005f && Rb.velocity.y > -0.0005f))
            {
                kayottieTimer = KayottieTime;
            }
            if (jumpInputTimer > 0 && kayottieTimer > 0)
            {
                // Instantiate(jumpCloud, jumpEffectSpawnTransform.position, jumpEffectSpawnTransform.rotation);
                // jumpSound.Play();
                Rb.velocity = new Vector2(Rb.velocity.x, JumpForce);
                jumpInputTimer = 0;
                kayottieTimer = 0;
            }
        }

    }
    void unBlockAnim()
    {
        blockAnim = false;
    }



}