using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
[SerializeField]
Animator transition;
[SerializeField]
float transitionTime = 1f;

public void Awake()
{
    transition.gameObject.SetActive(true);
    if(SceneManager.GetActiveScene().buildIndex != 0)
    {
Time.timeScale = 0f;
    }
}

    public void LoadSpecificLevel(int levelToLoad)
    {
        StartCoroutine(LoadLevel(levelToLoad, 0));
    }
      public void Reload(float startDelay  = 0)
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex, startDelay));
    }
      public void NextLevel(float startDelay  = 0)
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1, startDelay));
    }

    public void quit()
    {
      Application.Quit();
    }

    IEnumerator LoadLevel(int levelIndexToLoad, float startWaitTime)
    {
        yield return new WaitForSeconds(startWaitTime);
        transition.SetTrigger("End");

        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndexToLoad);
    }
}