using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpEnlarge : MonoBehaviour
{
    public Player player;
    public PowerUpInstantiate powerupInstantiate;


    public void Enlarge(Player player)
    {
        StartCoroutine(PowerupTimer(6f, player));       
        player.transform.localScale = new Vector3(2, 2, 1);
        player.movement.yMovementCap = 0.7f;       
    }

    IEnumerator PowerupTimer(float timer, Player player)
    {

        while (timer > 0)
        {
            timer -= Time.deltaTime;
            yield return null;
        }
               
        // Reset Powerup when timer is 0
        player.transform.localScale = new Vector3(1, 1, 1);
        player.movement.yMovementCap = 2.2f;
        powerupInstantiate.powerupOnfield = false;

        player.state.PowerupReset();
    }
   
}
