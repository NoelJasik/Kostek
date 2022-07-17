using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/Weapon", order = 1)]
public class Weapon : ScriptableObject
{

    public GameObject bullet;

    public AudioClip shootSoundEffect;

    public Vector2 barrelPos;

    public float shootCoolDown;

    public float reloadCooldown;

    public Sprite weaponSprite;
    public Sprite shootSprite;
    public Sprite reloadSprite;

    public int maxAmmo;

    public float bulletSpeed;

    public float bulletSpread = 0;

    public int bulletAmount = 1;
    public float bulletCooldown = 0;

    public bool countMultipleShoots;

    public PlayerModel playerModelToSelect;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
