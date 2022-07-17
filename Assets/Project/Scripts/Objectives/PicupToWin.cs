using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PicupToWin : MonoBehaviour
{
    public int amountOfCoins;
    [SerializeField]
    int goal;
    DiceRolling diceRolling;
    [SerializeField]
    TextMeshProUGUI counter;

    void Start()
    {
        diceRolling = FindObjectOfType<DiceRolling>();
    }
    void Update()
    {
        counter.text = amountOfCoins.ToString() + "/" + goal.ToString();
        if(amountOfCoins >= goal)
        {
            diceRolling.beatLevel(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
