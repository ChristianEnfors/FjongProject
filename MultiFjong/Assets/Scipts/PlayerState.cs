using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerState : MonoBehaviour
{
    public int Score = 0;    
    public bool HasPowerup;
    public string readyPowerup;
    public Image powerupImage;
    public GameObject wonUI;
    public GameObject endgamePanel;
    public TextMeshProUGUI scoreUI;
    public GameBrain gamebrain;
    public Player player;
        

    public void Scored()
    {
        Score++;
        scoreUI.text = Score.ToString();

        if (Score < 5)
        {
            gamebrain.RestartRound();
        }

        else gamebrain.GameOver(player);

    }
    
    public void GameOver()
   {
       endgamePanel.SetActive(true);
       wonUI.SetActive(true);
   }

    public void PowerupReset()
    {
        HasPowerup = false;
        readyPowerup = null;
        powerupImage.color = Color.white;
    }

    public void PowerupPickup(string powerup)
    {
        HasPowerup = true;
        readyPowerup = powerup;

        if (powerup == "Enlarge")
        {
            powerupImage.color = Color.yellow;
        }

        if (powerup == "SuperAim")
        {
            powerupImage.color = Color.red;
        }
        if (powerup == "Rocket")
        {
            powerupImage.color = Color.blue;
        }
    }

    public void OnReset()
    {
        Score = 0;
        scoreUI.text = Score.ToString();

        endgamePanel.SetActive(false);
        wonUI.SetActive(false);
    }


}
