using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    int MaxHealth;
    [SerializeField]
    GameObject[] hearts;
    public int currentHealth;

    public bool canDamage;
    float noHitTimer;
    [SerializeField]
    SpriteRenderer playerSpriteRenderer;
    bool natural;
    [SerializeField]
    GameObject deathParticle;
    [SerializeField]
    LevelManager levelManager;
    bool createdDeathParticle = false;
    WeaponHandler weaponHandler;
    // Start is called before the first frame update
    void Start()
    {
        weaponHandler = FindObjectOfType<WeaponHandler>();
        currentHealth = MaxHealth;
        levelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth > MaxHealth)
        {
            currentHealth = MaxHealth;
        }
        if(currentHealth <= 0)
        {
            gameObject.SetActive(false);
            if(createdDeathParticle == false)
            {
               GameObject deathP = Instantiate(deathParticle, transform.position, transform.rotation);
               deathP.GetComponentInChildren<SpriteRenderer>().flipX = playerSpriteRenderer.flipX;
            levelManager.LoadSpecificLevel(0);
            createdDeathParticle = true;
            }

        }
        if(noHitTimer >= 0)
        {
          noHitTimer -= Time.deltaTime;
          canDamage = false;
          if(natural)
          {
            flash();
          }
        } else if(currentHealth > 0)
        {
            canDamage = true;
            playerSpriteRenderer.enabled = true;
        }
    }

void flash()
{
 if(!canDamage && currentHealth > 0)
 {
    natural = false;
    playerSpriteRenderer.enabled = !playerSpriteRenderer.enabled;
    Invoke("flash", 0.1f);
 }

}
    public void ToggleInvicibility(float _amount)
    {
        noHitTimer = _amount;
        natural = false;
    }
    public void Damage()
    {
     if(canDamage)
     {
        weaponHandler.killStreak = 0;
        for (int i = 0; i < MaxHealth; i++)
        {
            if(i + 1 < currentHealth)
            {
                hearts[i].SetActive(true);
            } else
            {
                hearts[i].SetActive(false);
            }
        }
        
        natural = true;
        currentHealth--;
        noHitTimer = 0.4f;
     }
    }
}
