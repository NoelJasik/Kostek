using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBrain : MonoBehaviour
{
    //old shit from mixed guns
    public bool isPlayerNear;
    public bool canShoot;
    bool shallStay;
    bool shallEscape;
    public float Radius;
    [SerializeField]
    float stayRadius;
    [SerializeField]
    float shootRadius;
    [SerializeField]
    float walkAwayRadius;
    [SerializeField]
    LayerMask Player;
    [SerializeField]
    LayerMask Avoid;
    [SerializeField]
    LayerMask ground;
    GameObject PlayerTransform;
    Rigidbody2D RB;
    [SerializeField]
    float MoveSpeed;
    [SerializeField]
    float EscapeMulti;
    [SerializeField]
    SpriteRenderer Sr;
    [SerializeField]
    bool ShouldRotate = true;
    [SerializeField]
    float jumpForce;
    bool shouldJump;
    bool isAbove;
    bool jumped;
    [SerializeField]
    float jumpCooldown;
    [SerializeField]
    bool walks = true;
    public bool aiOff;
    // public bool spawnWithParachute;
    // [SerializeField]
    // GameObject parachuteGamobject;
    EnemyAimer la;
  //  EMortalityModule emm;
    float MoveSpeedMulti = 1f;
    [SerializeField]
    float JumpCheckRadius = 0.3f;
    // [SerializeField]
    // GameObject jumpEffect;
   

    float TimerWalk = 0f;

    // Start is called before the first frame update
    void Start()
    {

        RB = GetComponent<Rigidbody2D>();
        PlayerTransform = GameObject.Find("<Player>").gameObject;
     la = gameObject.GetComponentInChildren<EnemyAimer>();
       // emm = GetComponent<EMortalityModule>();
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, Radius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, shootRadius);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, stayRadius);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, walkAwayRadius);
    }

    // Update is called once per frame
    void Update()
    {

        isPlayerNear = Physics2D.OverlapCircle(transform.position, Radius, Player);
        isAbove = transform.position.y > PlayerTransform.transform.position.y + 2;
        canShoot = Physics2D.OverlapCircle(transform.position, shootRadius, Player);
        // if (emm.IsBoosted == true)
        // {
        //     MoveSpeedMulti = 1.2f;
        // }
        // else
        // {
        //     MoveSpeedMulti = 1f;
        // }


            if (la.angle > 89 || la.angle < -89)
            {
                Sr.flipX = true;
            }
            else
            {
                Sr.flipX = false;
            }
      

        if (walks && !aiOff && RB.gravityScale != 0.06f)
        {
            shallStay = Physics2D.OverlapCircle(transform.position, stayRadius, Player);
            shallEscape = Physics2D.OverlapCircle(transform.position, walkAwayRadius, Player) || Physics2D.OverlapCircle(transform.position, walkAwayRadius + 0.30f, Avoid);
            shouldJump = (Physics2D.OverlapCircle(transform.position, JumpCheckRadius, ground) || PlayerTransform.transform.position.x > transform.position.x - 0.2f && PlayerTransform.transform.position.x < transform.position.x + 0.2f && isPlayerNear && PlayerTransform.transform.position.y > transform.position.y) && jumpCooldown != 0;

            if (isPlayerNear && !shallStay && !shallEscape)
            {
                if (isAbove && shootRadius == 0)
                {
                    if (PlayerTransform.transform.position.x > transform.position.x)
                    {
                        RB.velocity = new Vector2(-MoveSpeed * MoveSpeedMulti, RB.velocity.y);
                    }
                    else if (PlayerTransform.transform.position.x < transform.position.x)
                    {
                        RB.velocity = new Vector2(MoveSpeed * MoveSpeedMulti, RB.velocity.y);
                    }
                }
                else if (PlayerTransform.transform.position.x > transform.position.x - 0.2f && PlayerTransform.transform.position.x < transform.position.x + 0.2f)
                {


                    RB.velocity = new Vector2(0, RB.velocity.y);


                }
                else if (PlayerTransform.transform.position.x < transform.position.x)
                {
                    RB.velocity = new Vector2(-MoveSpeed * MoveSpeedMulti, RB.velocity.y);
                }
                else if (PlayerTransform.transform.position.x > transform.position.x)
                {
                    RB.velocity = new Vector2(MoveSpeed * MoveSpeedMulti, RB.velocity.y);
                }

                if (shouldJump && !jumped)
                {
                    RB.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
                    jumped = true;
                    // Instantiate(jumpEffect, new Vector3(transform.position.x, transform.position.y - 0.227f, transform.position.z), transform.rotation);
                    Invoke("jumpReset", jumpCooldown);


                }

                if (la.angle > 90 || la.angle < -90)
                {
                    Sr.flipX = true;
                }
                else
                {
                    Sr.flipX = false;
                }
                if ((shouldJump && !jumped) || RB.velocity.x == 0)
                {
                    // Sr.sprite = skin.AfkSprite;
                }
              

            }
            else if (shallEscape)
            {
                if (PlayerTransform.transform.position.x < transform.position.x)
                {
                    RB.velocity = new Vector2((MoveSpeed * EscapeMulti) * MoveSpeedMulti, RB.velocity.y);
                }
                else if (PlayerTransform.transform.position.x > transform.position.x)
                {
                    RB.velocity = new Vector2((-MoveSpeed * EscapeMulti) * MoveSpeedMulti, RB.velocity.y);
                }
                if (shouldJump && !jumped)
                {
                    RB.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
                    jumped = true;
                    // Instantiate(jumpEffect, new Vector3(transform.position.x, transform.position.y - 0.227f, transform.position.z), transform.rotation);
                    Invoke("jumpReset", jumpCooldown);

                }
                if (la.angle > 90 || la.angle < -90)
                {
                    Sr.flipX = true;
                }
                else
                {
                    Sr.flipX = false;
                }
                if ((shouldJump && !jumped) || RB.velocity.x == 0)
                {

                    // Sr.sprite = skin.AfkSprite;
                    Debug.Log("Stay");
                }
                else
                {
                           
                    Debug.Log("walk");
                }
            }

            else
            {
                // Sr.sprite = skin.AfkSprite;
                RB.velocity = new Vector2(0, RB.velocity.y);
                if (la.angle > 90 || la.angle < -90)
                {
                    Sr.flipX = true;
                }
                else
                {
                    Sr.flipX = false;
                }
            }
        }
        if (aiOff)
        {

            RB.velocity = new Vector2(0, RB.velocity.y);
            if (la.angle > 90 || la.angle < -90)
            {
                Sr.flipX = true;
            }
            else
            {
                Sr.flipX = false;
            }
        }
    }

    void jumpReset()
    {
        jumped = false;
    }


}
