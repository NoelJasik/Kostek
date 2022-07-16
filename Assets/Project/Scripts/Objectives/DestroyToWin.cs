using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyToWin : MonoBehaviour
{
    DiceRolling dr;
    void Start()
    {
        dr = FindObjectOfType<DiceRolling>();
    }
     void OnDestroy() {
        dr.beatLevel(SceneManager.GetActiveScene().buildIndex);
    }
}
