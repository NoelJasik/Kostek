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
AudioSource ass;
[SerializeField]
AudioClip endSound;

public void Awake()
{
    transition.gameObject.SetActive(true);
    if(SceneManager.GetActiveScene().buildIndex != 0 && SceneManager.GetActiveScene().buildIndex != 7)
    {
Time.timeScale = 0f;
    }
    ass = GetComponent<AudioSource>();
    
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
      ass.PlayOneShot(endSound);
        yield return new WaitForSeconds(startWaitTime);
        transition.SetTrigger("End");

        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndexToLoad);
    }
    public void loadQuick(int _levelIndexToLoad)
    {
      SceneManager.LoadScene(_levelIndexToLoad);
    }
}