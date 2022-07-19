using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSprite : MonoBehaviour
{
    [SerializeField]
    List<Sprite> spritesToChooseFrom;
    SpriteRenderer sr;
    //I know there's a better way
    [SerializeField]
    SpriteRenderer[] outline;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        Sprite spriteToAssign = spritesToChooseFrom[Random.Range(0, spritesToChooseFrom.Count)];
        sr.sprite = spriteToAssign;
        if(outline != null)
        {
            for (int i = 0; i < outline.Length; i++)
            {
                 outline[i].sprite = spriteToAssign;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
