using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponHandler : MonoBehaviour
{
// Palę dziesięć jointów dziennie a nie umiem skręcać
// Pozdrawiam moich przyjaciół bo nie wiem co bez was
// Trzy dwa jeden zero kurwo skute bobo wjeżdża
// Skute bobo
// Palę dziesięć jointów dziennie a nie umiem skręcać
// Pozdrawiam moich przyjaciół bo nie wiem co bez was
// Stylówa jeden zero kurwo skute bobo wjeżdża
// Skute bobo
// W sumie to prawie nie jaram nie potrafię sam nawet skręcić pacana
// Raz zajebałem się w akcji spytałem ziomów czy nie chcą iść na pawiana
// Kiedyś ogoliłem się na Pazdana no i byłem nie do poznania chociaż w sumie Michał i 2 na plecach bo wziąłem se plecak no i poszedłem zajarać
// Marihuana cała Polska jest w niej zakochana i nie tylko młodzież bo spaliłem z moim dziadkiem grama
// Każdy kogo znam zjarał chociaż gram zioła
// Więc nie palę sam no bo po to mam zioma
// Znowu cały skład wpada na gibona
// Znowu cali blunt zamiast poldona
// Na co komu crack ja chcę z bongosa
// Zjarać cały stuff poco mi feta koda koka
// Palę dziesięć jointów dziennie a nie umiem skręcać
// Pozdrawiam moich przyjaciół bo nie wiem co bez was
// Trzy dwa jeden zero kurwo skute bobo wjeżdża
// Skute bobo
// Palę dziesięć jointów dziennie a nie umiem skręcać
// Pozdrawiam moich przyjaciół bo nie wiem co bez was
// Trzy dwa jeden zero kurwo skute bobo wjeżdża
// Skute bobo
// Raz jak z Orlenka wracałem na schodki
// Bo chciałem se kupić browara
// Choć nie miałem nic zjarałem 3 lolki
// Bo kurwa mogę polegać na fanach
// Nie odmawiam wiadra no chyba że z rana
// Ona jest ładna ale najebała się
// A jak kot i pies czasem jest wódka i marihuana
// Nie potrafimy się dogadać ej
// Moja lufka nabita a twoja polana
// Mała chciałabyś nadawać na tych samych falach
// No to dawaj zamiana
// Ty mordo zajeb wodospad jakby zdenerwowała cię Niagara
// Chciałbym żeby tutaj była Kanada albo Nevada
// Anglia Holandia Czechy Hiszpania Peru Portugalia
// Jamajka wiadomo Trynidad Tobago i Malta Paragwaj
// Floryda Ekwador Szwajcaria
// Waszyngton Chorwacja i Kanzas i Chile
// Ile jeszcze mam wymieniać
// Ekwador Słowenia Australia Urugwaj
// Od dawna no kurwa nawet jakaś Gruzja pozwala
// Bermudy wyspy Bergamuty Boliwia
// A u nas cię czeka sromotna kara
// Nie kończę jarać
// Ijo ijo szkoda że muszę spierdalać
// Za skuna mandat a nie krata
// Hakuna Matata
// Nara
// Palę dziesięć jointów dziennie a nie umiem skręcać
// Pozdrawiam moich przyjaciół bo nie wiem co bez was
// Trzy dwa jeden zero kurwo skute bobo wjeżdża
// Skute bobo
// Palę dziesięć jointów dziennie a nie umiem skręcać
// Pozdrawiam moich przyjaciół bo nie wiem co bez was
// Trzy dwa jeden zero kurwo skute bobo wjeżdża
// Skute bobo

    [SerializeField]
    TextMeshProUGUI ammoCounter;
    [SerializeField]
    Weapon[] weapons;

    [SerializeField]
    SpriteRenderer weaponSpriteRenderer;
    [SerializeField]
    Transform barrel;

    public bool canShoot;

    public Weapon currentWeapon;


    public int currentAmmo;

    public float currentReloadCooldown;

    public float currentShootCooldown;

    bool reloading = false;

    [SerializeField]
    Slider reloadCounter;
    [SerializeField]
    Player player;
    public int killStreak;

    // Start is called before the first frame update
    void Awake()
    {
        RollGun();
        reloadCounter.gameObject.SetActive(false);
        player = FindObjectOfType<Player>();
    }
    void ApplyWeapon(Weapon _weaponToApply)
    {
        currentWeapon = _weaponToApply;
        weaponSpriteRenderer.sprite = currentWeapon.weaponSprite;
        currentAmmo = currentWeapon.maxAmmo;
        currentReloadCooldown = currentWeapon.reloadCooldown;
        currentShootCooldown = currentWeapon.shootCoolDown;
        barrel.localPosition = currentWeapon.barrelPos;
        reloadCounter.maxValue = currentWeapon.reloadCooldown;
        reloadCounter.gameObject.SetActive(false);
        reloading = false;
        player.currentPlayerModel = currentWeapon.playerModelToSelect;
        currentReloadCooldown = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (reloading)
        {
            currentReloadCooldown += Time.deltaTime;
            reloadCounter.value = currentReloadCooldown;
            reloadCounter.gameObject.SetActive(true);
        }
        if (currentReloadCooldown >= currentWeapon.reloadCooldown && reloading)
        {
            currentAmmo = currentWeapon.maxAmmo;
            reloadCounter.gameObject.SetActive(false);
             weaponSpriteRenderer.sprite = currentWeapon.weaponSprite;
            currentReloadCooldown = 0;
            reloading = false;
        }
        currentShootCooldown -= Time.deltaTime;
        if (canShoot)
        {
            weaponSpriteRenderer.enabled = true;
            ammoCounter.text = currentAmmo.ToString() + "/" + currentWeapon.maxAmmo.ToString();
            if (Input.GetButton("Fire1") && currentShootCooldown <= 0 && currentAmmo > 0)
            {
                Shoot();
            }
            else
        if ((Input.GetButton("Fire1") && currentAmmo <= 0 && !reloading) || (Input.GetButton("Reload") && !reloading))
            {
                Reload();
            }
        }
        else
        {
            weaponSpriteRenderer.enabled = false;
        }


    }
    public void RollGun()
    {
        Weapon gunToApply = weapons[Random.Range(0, weapons.Length)];
        while(gunToApply == currentWeapon)
        {
            gunToApply = weapons[Random.Range(0, weapons.Length)];
        }
        ApplyWeapon(gunToApply);
    }
    public void ShootFrame()
    {
       weaponSpriteRenderer.sprite = currentWeapon.shootSprite;
       float delay = currentWeapon.bulletCooldown - currentWeapon.bulletCooldown / 5;
       if(delay <= 0)
       {
        delay = 0.1f;
       }
       Invoke("NormalFrame", delay);
    }

    void NormalFrame()
    {
       if(reloading)
       {
        weaponSpriteRenderer.sprite = currentWeapon.reloadSprite;
       } else
       {
        weaponSpriteRenderer.sprite = currentWeapon.weaponSprite;
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
        if (!currentWeapon.countMultipleShoots)
        {
            currentAmmo--;
        }

    }
    void Fire()
    {
        if (canShoot && ((currentAmmo > 0 && currentWeapon.countMultipleShoots) || !currentWeapon.countMultipleShoots))
        {
            ShootFrame();
            barrel.localRotation = Quaternion.Euler(barrel.rotation.x, barrel.rotation.z, Random.Range(-currentWeapon.bulletSpread, currentWeapon.bulletSpread));
            GameObject bullet = Instantiate(currentWeapon.bullet, barrel.position, barrel.rotation);
            bullet.GetComponent<Rigidbody2D>().AddForce(currentWeapon.bulletSpeed * barrel.right);
            
            
            Destroy(bullet, 6f);
            if (currentWeapon.countMultipleShoots)
            {
                currentAmmo--;
            }
        }
    }
    void Reload()
    {
        reloading = true;
        Debug.Log("Reloading");
    }
}
