using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Killstreak : MonoBehaviour
{
    WeaponHandler weaponHandler;
    [SerializeField]
    int goal;
    DiceRolling dr;
    [SerializeField]
    TextMeshProUGUI counter;
    void Start()
    {
        dr = FindObjectOfType<DiceRolling>();
        weaponHandler = FindObjectOfType<WeaponHandler>();
    }
    void Update()
    {
        counter.text = weaponHandler.killStreak.ToString() + "/" + goal.ToString();
        if (weaponHandler.killStreak >= goal)
        {
            dr.beatLevel(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
