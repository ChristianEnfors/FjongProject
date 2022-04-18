using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPowerUpPickUp : MonoBehaviour
{
    GameBrain gamebrain;
    public string powerupName;

    private void Start()
    {
        gamebrain = GameObject.FindGameObjectWithTag("GameBrain").GetComponent<GameBrain>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ball")
        {
            gamebrain.OnPowerupPickup(powerupName);
            Destroy(gameObject);
        }
    }
}
