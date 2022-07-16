using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aimer : MonoBehaviour
{
    [SerializeField]
    bool ShouldFlip;
    Rigidbody2D RB;
    Vector2 MousePos;
    float angle;
    [SerializeField]
    Transform playerPos;
    [SerializeField]
    SpriteRenderer playerSr;
    [SerializeField]
    SpriteRenderer gunSr;

    void Start()
    {
         Camera.main.ScreenToWorldPoint(Input.mousePosition);
         RB = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = MousePos - RB.position;
        angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        RB.rotation = angle;
        transform.position = playerPos.position;
        if(angle < 90 && angle > -90)
        {
            ShouldFlip = false;
        }
         else
         {
            ShouldFlip = true;
         }
         playerSr.flipX = ShouldFlip;
         gunSr.flipY = ShouldFlip;
    }

}
