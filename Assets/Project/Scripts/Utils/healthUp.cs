using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthUp : MonoBehaviour
{
    // [SerializeField]
    // GameObject hpUpEffect;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (other.GetComponent<Health>().currentHealth < other.GetComponent<Health>().MaxHealth)
            {
                other.GetComponent<Health>().Heal();;
                Destroy(gameObject);
            }
        }
    }
}
