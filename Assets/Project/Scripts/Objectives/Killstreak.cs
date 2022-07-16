using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Killstreak : MonoBehaviour
{
    WeaponHandler weaponHandler;
    [SerializeField]
    int goal;
    DiceRolling dr;
    void Start()
    {
        dr = FindObjectOfType<DiceRolling>();
        weaponHandler = FindObjectOfType<WeaponHandler>();
    }
    void Update()
    {
        if (weaponHandler.killStreak >= goal)
        {
            dr.beatLevel(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
