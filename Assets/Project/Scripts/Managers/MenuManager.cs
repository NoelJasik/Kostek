using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    GameObject resetProgressButton;
    [SerializeField]
    GameObject menu;
    [SerializeField]
    GameObject loop;
    [SerializeField]
    GameObject mainTheme;

    bool progress;
    // Start is called before the first frame update
    void Start()
    {
          resetProgressButton.SetActive(false);
        if (SceneManager.GetActiveScene().buildIndex == 0 && PlayerPrefs.GetString("Has Played") != "true")
        {
              menu.SetActive(true);
              loop.SetActive(true);
              mainTheme.SetActive(false);
              PlayerPrefs.SetString("Has Played", "true");
        } else if(SceneManager.GetActiveScene().buildIndex == 0)
        {
             for (int i = 1; i <= 6; i++)
        {
            if (PlayerPrefs.GetString(i + " has been beaten") == "true")
            {
                resetProgressButton.SetActive(true);
            }
        }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
             menu.SetActive(!menu.activeSelf);
             if(loop != null)
             {
                if(loop.activeSelf == true)
                {
                    mainTheme.SetActive(true);
                    loop.SetActive(false);
                }
             }
        }
    }
}
