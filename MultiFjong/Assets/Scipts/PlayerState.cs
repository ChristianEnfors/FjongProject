using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerState : MonoBehaviour
{
    public int Score = 0;    
    public bool HasPowerup;
    public string ReadyPowerup;
    public Image powerupImage;


    public void PowerupReset()
    {
        HasPowerup = false;
        ReadyPowerup = null;
        powerupImage.color = Color.white;
    }

    public void PowerupPickup(string powerup)
    {
        HasPowerup = true;
        ReadyPowerup = powerup;

        if (powerup == "Enlarge")
        {
            powerupImage.color = Color.yellow;
        }

        if (powerup == "SuperAim")
        {
            powerupImage.color = Color.red;
        }
    } 
    

}
