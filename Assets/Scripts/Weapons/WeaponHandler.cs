using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    [SerializeField]
    Weapon[] weapons;

    [SerializeField]
    SpriteRenderer weaponSpriteRenderer;
    [SerializeField]
    Transform barrel;

    public Weapon currentWeapon;


    public int currentAmmo;

    public float currentReloadCooldown;

    public float currentShootCooldown;

    bool reloading = false;


    // Start is called before the first frame update
    void Start()
    {
     ApplyWeapon(weapons[0]);
    }
    void ApplyWeapon(Weapon _weaponToApply)
    {
       currentWeapon = _weaponToApply;
       weaponSpriteRenderer.sprite = currentWeapon.weaponSprite;
       currentAmmo = currentWeapon.maxAmmo;
       currentReloadCooldown = currentWeapon.reloadCooldown;
       currentShootCooldown = currentWeapon.shootCoolDown;
       barrel.localPosition = currentWeapon.barrelPos;
    }

    // Update is called once per frame
    void Update()
    {
        if(reloading)
        {
             currentReloadCooldown -= Time.deltaTime;
        } if(currentReloadCooldown <= 0 && reloading)
        {
            currentAmmo = currentWeapon.maxAmmo;
            currentReloadCooldown = currentWeapon.reloadCooldown;
            reloading = false;
        }
        currentShootCooldown -= Time.deltaTime;
        if(Input.GetButton("Fire1") && currentShootCooldown <= 0 && currentAmmo > 0)
        {
            Shoot();
        } else 
        if((Input.GetButton("Fire1") && currentAmmo <= 0 && !reloading) || (Input.GetButton("Reload") && !reloading))
        {
            Reload();
        }
    }

    void Shoot()
    { 
       Debug.Log("Bam!");
       currentShootCooldown = currentWeapon.shootCoolDown;
       GameObject bullet = Instantiate(currentWeapon.bullet, barrel.position, barrel.rotation);
       bullet.GetComponent<Rigidbody2D>().AddForce(currentWeapon.bulletSpeed * transform.right);
       Destroy(bullet, 5f);
       currentAmmo--;
    }
    void Reload()
    { 
       reloading = true;
       Debug.Log("Reloading");
    }
}
