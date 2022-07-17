using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer weaponSpriteRenderer;
    [SerializeField]
    Transform barrel;

    public Weapon currentWeapon;
   public RaycastHit2D hit;
      [SerializeField]
   EnemyAimer eA;
   [SerializeField]
   LayerMask whatHits;

    public float currentShootCooldown;

     AudioSource audioPlayer;



    // Start is called before the first frame update
    void Start()
    {
        weaponSpriteRenderer.sprite = currentWeapon.weaponSprite;
        currentShootCooldown = currentWeapon.shootCoolDown;
        barrel.localPosition = currentWeapon.barrelPos;
        audioPlayer = GetComponent<AudioSource>();
    }
     public void ShootFrame()
    {
       weaponSpriteRenderer.sprite = currentWeapon.shootSprite;
       float delay = currentWeapon.bulletCooldown - currentWeapon.bulletCooldown / 5;
       audioPlayer.PlayOneShot(currentWeapon.shootSoundEffect);
       if(delay <= 0)
       {
        delay = 0.1f;
       }
       Invoke("NormalFrame", delay);
    }
    void NormalFrame()
    {
        weaponSpriteRenderer.sprite = currentWeapon.weaponSprite;
    }


    // Update is called once per frame
    void Update()
    {
        currentShootCooldown -= Time.deltaTime;
        hit = Physics2D.Raycast(transform.position, eA.direction, 100, whatHits);
            if (currentShootCooldown <= 0 && hit.collider.gameObject.tag == "Player")
            {
                Shoot();
            }
    }


    void Shoot()
    {
        Debug.Log("Bam!");
        currentShootCooldown = currentWeapon.shootCoolDown;
        for (int i = 0; i < currentWeapon.bulletAmount; i++)
        {
            Invoke("Fire", i * currentWeapon.bulletCooldown);
        }

    }
    void Fire()
    {
        ShootFrame();
        barrel.localRotation = Quaternion.Euler(barrel.rotation.x, barrel.rotation.z, Random.Range(-currentWeapon.bulletSpread, currentWeapon.bulletSpread));
        GameObject bullet = Instantiate(currentWeapon.bullet, barrel.position, barrel.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(currentWeapon.bulletSpeed * barrel.right);
        Destroy(bullet, 3f);
    }
}
