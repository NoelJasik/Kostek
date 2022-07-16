using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHeart : MonoBehaviour
{
    public float health;
    void Update()
    {
        if(health <= 0)
        {
            FindObjectOfType<WeaponHandler>().killStreak++;
            Destroy(gameObject);
        }
    }
    public void Damage(int _amount)
    {
          health -= _amount;
    }
}
