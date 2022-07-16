using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnpauseForAnim : MonoBehaviour
{
    public void unfreeze()
    {
        Time.timeScale = 1f;
    }
}
