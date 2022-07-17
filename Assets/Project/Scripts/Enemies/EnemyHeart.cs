using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHeart : MonoBehaviour
{
    public float health;
    WeaponHandler weaponHandler;
    Animator anim;

    private void Start() {
        weaponHandler = FindObjectOfType<WeaponHandler>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if(health <= 0)
        {
            weaponHandler.killStreak++;
            weaponHandler.totalKills++;
            Destroy(gameObject, 0.0001f);
        }
    }
    public void Damage(int _amount)
    {
        anim.SetTrigger("Hit");
          health -= _amount;
    }
}
