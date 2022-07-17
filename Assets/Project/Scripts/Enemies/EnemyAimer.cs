using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAimer : MonoBehaviour
{
    Transform player;
    Rigidbody2D RB;
    public float angle;
    [SerializeField]
    float smoothSpeed;
    public Vector3 direction;
    [SerializeField]
    bool instant;
    [SerializeField]
    Transform enemyPos;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        player = GameObject.Find("<Player>").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            transform.position = enemyPos.position;
            direction = player.position - transform.position;
            angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            RB.MoveRotation(Mathf.LerpAngle(RB.rotation, angle, smoothSpeed * Time.deltaTime));
            if (instant)
            {
                RB.MoveRotation(angle);
            }
            else
            {
                RB.MoveRotation(Mathf.LerpAngle(RB.rotation, angle, smoothSpeed * Time.deltaTime));
            }

        }




    }
}
