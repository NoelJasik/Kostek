using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiceRolling : MonoBehaviour
{
    public List<int> levelList;
    LevelManager levelManager;
    bool beated = false;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        for (int i = 1; i <= 6; i++)
        {
            if (PlayerPrefs.GetString(i + " has been beaten") != "true")
            {
                levelList.Add(i);
            }

        }
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Invoke("rollLevel", 6f);
        }
    }

    public void beatLevel(int _levelToBeat)
    {
        PlayerPrefs.SetString(_levelToBeat + " has been beaten", "true");
        levelList.Clear();
        for (int i = 1; i <= 6; i++)
        {
            if (PlayerPrefs.GetString(i + " has been beaten") != "true")
            {
                levelList.Add(i);
            }
        }
        if (beated == false)
        {
            levelManager.LoadSpecificLevel(0);
            beated = true;
        }
    }
    public void resetLevelData()
    {
        for (int i = 1; i <= 6; i++)
        {
            PlayerPrefs.SetString(i + " has been beaten", "false");
        }
    }

    public void rollLevel()
    {
        int roll = levelList[Random.Range(0, levelList.Count)];
        Debug.Log(roll);
        levelManager.LoadSpecificLevel(roll);

    }
}
