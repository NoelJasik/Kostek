using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class killCount : MonoBehaviour
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
        if (counter != null)
        {
            counter.text = weaponHandler.totalKills.ToString() + "/" + goal.ToString();
        }

        if (weaponHandler.totalKills >= goal)
        {
            dr.beatLevel(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
