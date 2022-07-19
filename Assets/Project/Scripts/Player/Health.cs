using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int MaxHealth;
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
    Player p;
        [SerializeField]
    AudioClip healSound;
    AudioSource playerOfAudio;
    // Start is called before the first frame update
    void Start()
    {
        weaponHandler = FindObjectOfType<WeaponHandler>();
       // currentHealth = MaxHealth;
        levelManager = FindObjectOfType<LevelManager>();
        playerOfAudio = GetComponent<AudioSource>();
        p = GetComponent<Player>();
         for (int i = 0; i < MaxHealth; i++)
        {
            if(i  < currentHealth)
            {
                hearts[i].SetActive(true);
                  Debug.Log(i + " is active");
            } else
            {
                hearts[i].SetActive(false);
                Debug.Log(i + " isn't active");
            }
        }
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
               deathP.GetComponentInChildren<SpriteRenderer>().sprite = p.currentPlayerModel.deathFrame;
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
            p.blockAnim = true;
            Invoke("UnblockAnim", 0.4f);
            playerSpriteRenderer.sprite = p.currentPlayerModel.hitFrame;
            flash();
          }
        } else if(currentHealth > 0)
        {
            canDamage = true;
            playerSpriteRenderer.enabled = true;
        }
    }

    void UnblockAnim()
    {
         p.blockAnim = false;
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
            if(i  < currentHealth)
            {
                hearts[i].SetActive(true);
                  Debug.Log(i + " is active");
            } else
            {
                hearts[i].SetActive(false);
                Debug.Log(i + " isn't active");
            }
        }
        
        natural = true;
        currentHealth--;
        noHitTimer = 3f;
        canDamage = false;
     }
    }
    public void Heal()
    {
        Debug.Log("healed");
        playerOfAudio.PlayOneShot(healSound);
        currentHealth++;
         for (int i = 0; i < MaxHealth; i++)
        {
            if(i  < currentHealth)
            {
                hearts[i].SetActive(true);
                  Debug.Log(i + " is active");
            } else
            {
                hearts[i].SetActive(false);
                Debug.Log(i + " isn't active");
            }
        }
    }
}
