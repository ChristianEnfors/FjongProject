using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpInstantiate : MonoBehaviour
{
    public GameObject[] powerups;
    public float currTime;
    public bool powerupOnfield = false;

    void Update()
    {
        if (powerupOnfield == false)
        {
            currTime += Time.deltaTime;

            if (currTime >= (Random.Range(2, 5)))
            {
                Vector2 spawnPos = Random.insideUnitCircle * 5;
                Instantiate(powerups[Random.Range(0, powerups.Length)], spawnPos, Quaternion.identity);
                powerupOnfield = true;
                currTime = 0;
            }
        }

    }
}
