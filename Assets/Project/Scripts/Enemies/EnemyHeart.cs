using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHeart : MonoBehaviour
{
    public float health;
    WeaponHandler weaponHandler;

    private void Start() {
        weaponHandler = FindObjectOfType<WeaponHandler>();
    }
    void Update()
    {
        if(health <= 0)
        {
            weaponHandler.killStreak++;
            weaponHandler.totalKills++;
            Destroy(gameObject);
        }
    }
    public void Damage(int _amount)
    {
          health -= _amount;
    }
}
