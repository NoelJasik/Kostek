using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableRandomItem : MonoBehaviour
{
    //Motocykl Motocykl kiedy otwiera się butla
    [SerializeField]
    List<GameObject> objectsToEnable;
    [SerializeField]
    int amountToEnable;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < objectsToEnable.Count; i++)
        {
            objectsToEnable[i].SetActive(false);
        }
        for (int i = 0; i < amountToEnable; i++)
        {
            int roll = Random.Range(0, objectsToEnable.Count);
            objectsToEnable[roll].SetActive(true);
            objectsToEnable.RemoveAt(roll);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
