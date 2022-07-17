using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    int maxAmount = 4;

    [SerializeField]
    float timeBetweenSpawns = 20f;

    [SerializeField]
    LayerMask playerLayer;

    [SerializeField]
    float noSpawnRadius;
       [SerializeField]

    float actualTimer;

    [SerializeField]
    float delay;
    [SerializeField]
    GameObject[] enemiesToSpawn;
    [SerializeField]
    GameObject spawnEffect;

    // Start is called before the first frame update

    float getTime()
    {
        float value = timeBetweenSpawns + Random.Range(-timeBetweenSpawns / 8, timeBetweenSpawns / 8);
        Debug.Log(value);
        return value;
    }
    void Start()
    {
        int amountOfBeatenLevels = 0;
        for (int i = 1; i <= 6; i++)
        {
            if (PlayerPrefs.GetString(i + " has been beaten") == "true")
            {
                amountOfBeatenLevels++;
                Debug.Log("level " + i + " was Beaten");
            }
        }
        timeBetweenSpawns = timeBetweenSpawns - (timeBetweenSpawns / (8 - amountOfBeatenLevels));
        maxAmount = maxAmount + (amountOfBeatenLevels);
        actualTimer = getTime() / Random.Range(2f, 10f);
    }
    void Update()
    {
        actualTimer -= Time.deltaTime;
        if (actualTimer <= 0 && !Physics2D.OverlapCircle(transform.position, noSpawnRadius, playerLayer))
        {
            SpawnEnemy();
        }
    }
    void SpawnEnemy()
    {
        if (FindObjectsOfType<EnemyHeart>().Length < maxAmount)
        {
            Debug.Log(FindObjectsOfType<EnemyHeart>().Length);
            Instantiate(enemiesToSpawn[Random.Range(0, enemiesToSpawn.Length)], transform.position, transform.rotation);
            Instantiate(spawnEffect, transform.position, transform.rotation);
        }

        actualTimer = getTime();
    }
}
