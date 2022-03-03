using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject blockPrefab;
    float secondsBetweenSpanws = 1f;
    float nextSpawnTime;
    public float spawnAngleMax;
    public float spawnSizeMax;
    public float spawnSizeMin;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            nextSpawnTime = Time.time + secondsBetweenSpanws;

            float spawnSize = Random.Range(spawnSizeMin, spawnSizeMax);
            float spawnAngle = Random.Range(-spawnAngleMax, spawnAngleMax);
            Vector3 spawnPosition = new Vector3(Random.Range(-5, 6), 2, 16);
            
            GameObject newBlock = (GameObject)Instantiate(blockPrefab, spawnPosition, Quaternion.Euler(0, spawnAngle, 0));
            newBlock.transform.localScale *= spawnSize;
        }

    }
}
