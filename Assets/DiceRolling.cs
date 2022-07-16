using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRolling : MonoBehaviour
{
    public List<int> levelList;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i <= 6; i++)
        {
            if(PlayerPrefs.GetString(i + " has been beaten") != "true")
            {
              levelList.Add(i);
            }
            
        }
    }

    public void beatLevel(int _levelToBeat)
    {
      PlayerPrefs.SetString(_levelToBeat + " has been beaten", "true");
      levelList.Clear();
       for (int i = 1; i <= 6; i++)
        {
            if(PlayerPrefs.GetString(i + " has been beaten") != "true")
            {
              levelList.Add(i);
            }
            
        }
    }

    public void rollLevel()
    {
       Debug.Log(levelList[Random.Range(0, levelList.Count)]);
    }
}
