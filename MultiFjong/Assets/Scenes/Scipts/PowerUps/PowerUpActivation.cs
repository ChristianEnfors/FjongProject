using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpActivation : MonoBehaviour
{
    public GameBrainStorage gameBrainStorage;
    public GameObject redPlayer;
    public GameObject bluePlayer;

    void Update()
    {
        if (Input.GetAxis("Blue PowerUp Activation") > 0.5)
        {
            if (gameBrainStorage.blueHasPowerUp)
            {
                if (gameBrainStorage.blueReadyPowerUp == "Enlarge")
                {
                    bluePlayer.transform.localScale = new Vector3(0,4,0);
                }
            }

            else return;
        }

        if (Input.GetAxis("Red PowerUp Activation") > 0.5)
        {
            if (gameBrainStorage.redHasPowerUp)
            {
                if (gameBrainStorage.redReadyPowerUp == "Enlarge")
                {

                }
            }

            else return;
        }
    }
}
