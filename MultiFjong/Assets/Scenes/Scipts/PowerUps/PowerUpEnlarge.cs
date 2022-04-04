using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpEnlarge : MonoBehaviour
{
    GameBrain gamebrain;

    private void Start()
    {
        gamebrain = FindObjectOfType<GameBrain>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ball")
        {
            gamebrain.PowerUpEnlarge();
            Destroy(gameObject);
        }
    }
}
