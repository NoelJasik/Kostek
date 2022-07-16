using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitbox : MonoBehaviour
{
    Health hp;
    void Start()
    {
        hp = FindObjectOfType<Health>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Killer" || other.tag == "Enemy")
        {
            hp.Damage();
        }
    }
}
