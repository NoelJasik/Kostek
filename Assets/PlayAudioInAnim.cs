using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioInAnim : MonoBehaviour
{
    [SerializeField]
    AudioSource ass;
    [SerializeField]
    float delay;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("playAfterY", delay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void playAfterY()
    {
        ass.Play();
    }
}
