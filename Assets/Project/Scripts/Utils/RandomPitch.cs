using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPitch : MonoBehaviour
{
    //młody jeżyk

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().pitch = Random.Range(0.9f, 1.1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
