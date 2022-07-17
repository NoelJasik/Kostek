using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class WaitToWin : MonoBehaviour
{
    [SerializeField]
    float timer;
    [SerializeField]
    TextMeshProUGUI counter;
    Health hp;
    DiceRolling diceRoll;

    void Start()
    {
        hp = FindObjectOfType<Health>();
        diceRoll = FindObjectOfType<DiceRolling>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        counter.text = timer.ToString("N0");
        if(timer <= 0)
        {
            timer = 0;
            if(hp.currentHealth > 0)
            {
 diceRoll.beatLevel(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
