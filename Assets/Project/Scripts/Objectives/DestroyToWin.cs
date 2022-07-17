using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyToWin : MonoBehaviour
{
    DiceRolling dr;
    EnemyHeart eh;
    void Start()
    {
        dr = FindObjectOfType<DiceRolling>();
        eh = GetComponent<EnemyHeart>();
    }
     void Update() {
        if(eh.health <= 0 )
        {
dr.beatLevel(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
