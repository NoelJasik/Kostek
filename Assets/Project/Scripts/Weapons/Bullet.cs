using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    List<string> destroyers;
    [SerializeField]
    string enemyTag;
    [SerializeField]
    bool bounce;
    [SerializeField]
    int bounceAmount;
    [SerializeField]
    int damageToDeal;
    Rigidbody2D rb;
    [SerializeField]
    bool penetrate;
    [SerializeField]
    GameObject hitEffect;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("hit");
        if(other.tag == enemyTag)
        {
           Instantiate(hitEffect, transform.position, transform.rotation);
            if((!bounce || bounceAmount <= 0) && !penetrate)
               {
                 Debug.Log("Destroy");
                 other.GetComponent<EnemyHeart>().Damage(damageToDeal);
                 Destroy(gameObject, 0.01f);
               } 
               if(bounce)
               {
                 Debug.Log("Bounce");
                 other.GetComponent<EnemyHeart>().Damage(damageToDeal);
                    rb.velocity = new Vector2(-rb.velocity.x, -rb.velocity.y);
                    bounceAmount--;
               } else if(penetrate)
               {
                      other.GetComponent<EnemyHeart>().Damage(damageToDeal);
               }
        }
        for (int i = 0; i < destroyers.Count; i++)
        {
            if(other.tag == destroyers[i])
            {
               Instantiate(hitEffect, transform.position, transform.rotation);
                Debug.Log("Registered a Hit");
               if((!bounce || bounceAmount <= 0))
               {
                 Debug.Log("Destroy");
                 Destroy(gameObject, 0.01f);
               } 
               if(bounce)
               {
                 Debug.Log("Bounce");
                    rb.velocity = new Vector2(-rb.velocity.x, -rb.velocity.y);
                    bounceAmount--;
               }
            }
        }
    }
}
