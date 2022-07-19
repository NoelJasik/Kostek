using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    int maxAmount = 2;

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
    Transform[] spawnPoints;
    [SerializeField]
    GameObject spawnEffect;

    int amountOfBeatenLevels;

    // Start is called before the first frame update

    float getTime()
    {
        float value = timeBetweenSpawns + Random.Range(-timeBetweenSpawns / 5, timeBetweenSpawns / 5);
        Debug.Log(value);
        return value;
    }
    void Start()
    {
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
        actualTimer = getTime() / Random.Range(2f, 4f);
    }
    void Update()
    {
        actualTimer -= Time.deltaTime;
        if (actualTimer <= 0)
        {
            int amountAtOnce = Random.Range(0, amountOfBeatenLevels);
            if(amountAtOnce > 3)
            {
                amountAtOnce = 3;
            }
            for (int i = 0; i <= amountAtOnce; i++)
            {
                SpawnEnemy();
            }
        }
    }
    void SpawnEnemy()
    {
        if (FindObjectsOfType<EnemyHeart>().Length < maxAmount)
        {
            Debug.Log(FindObjectsOfType<EnemyHeart>().Length);
            Transform spotToCreateAt = spawnPoints[Random.Range(0, spawnPoints.Length)];
            if (!Physics2D.OverlapCircle(spotToCreateAt.position, noSpawnRadius, playerLayer))
            {
                Instantiate(enemiesToSpawn[Random.Range(0, enemiesToSpawn.Length)], spotToCreateAt.position, spotToCreateAt.rotation);
                Instantiate(spawnEffect, spotToCreateAt.position, spotToCreateAt.rotation);
            } else
            {
                SpawnEnemy();
            }
        }

        actualTimer = getTime();
    }
}
