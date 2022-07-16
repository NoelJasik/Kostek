using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSprite : MonoBehaviour
{
    [SerializeField]
    List<Sprite> spritesToChooseFrom;
    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = spritesToChooseFrom[Random.Range(0, spritesToChooseFrom.Count)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
