using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontDestroy : MonoBehaviour
{
    public bool carryOver;
    public float priority;
    // Start is called before the first frame update
    void Start()
    {
        if (carryOver)
        {
            dontDestroy[] Objects = FindObjectsOfType<dontDestroy>();
            for (int i = 0; i < Objects.Length; i++)
            {

                if (Objects[i].name == gameObject.name && Objects[i] != this && Objects[i].priority >= priority)
                {
                    Destroy(gameObject);
                }
                if (Objects[i].name == gameObject.name && Objects[i] != this && Objects[i].priority < priority)
                {
                    Destroy(Objects[i].gameObject);
                }
            }

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            GameObject[] Objects = GameObject.FindGameObjectsWithTag("Music");
            for (int i = 0; i < Objects.Length; i++)
            {
                if (Objects[i] != this)
                {
                    Destroy(Objects[i]);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
