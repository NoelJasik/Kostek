using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    float Amount;
    [SerializeField]
    float delay;
    [SerializeField]
    GameObject[] enemiesToSpawn;
    [SerializeField]
    GameObject spawnEffect;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Amount; i++)
        {
            Invoke("SpawnEnemy", delay * i);
        }
    }
    void SpawnEnemy()
    {
         Instantiate(enemiesToSpawn[Random.Range(0, enemiesToSpawn.Length)], transform.position, transform.rotation);
         Instantiate(spawnEffect, transform.position, transform.rotation);
    }
}
