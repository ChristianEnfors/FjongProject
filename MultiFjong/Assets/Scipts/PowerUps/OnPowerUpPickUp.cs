using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPowerUpPickUp : MonoBehaviour
{
    PowerUpActivation powerUpActivation;
    public string powerupName;

    private void Start()
    {
        powerUpActivation = GameObject.FindGameObjectWithTag("GameBrain").GetComponent<PowerUpActivation>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ball")
        {
            powerUpActivation.OnPowerupPickup(powerupName);
            Destroy(gameObject);
        }
    }
}
