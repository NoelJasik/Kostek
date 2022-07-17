using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiceRolling : MonoBehaviour
{
    public List<int> levelList;
    LevelManager levelManager;
    bool beated = false;
    [SerializeField]
    Animator dice;
    int roll;

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
          roll = levelList[Random.Range(0, levelList.Count)];
            dice.SetInteger("result", roll);
            Invoke("rollLevel", 8f);
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

        Debug.Log(roll);
        levelManager.LoadSpecificLevel(roll);

    }
}
