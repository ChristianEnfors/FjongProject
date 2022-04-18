using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpActivation : MonoBehaviour
{
    public GameBrainStorage gameBrainStorage;
    public GameObject redPlayer;
    public GameObject bluePlayer;
    
    GameObject playerWithPowerup;

    void Update()
    {
        if (Input.GetAxis("Blue PowerUp Activation") > 0.5)
        {
            if (gameBrainStorage.blueHasPowerup)
            {
                if (gameBrainStorage.blueReadyPowerup == "Enlarge")
                {
                    PowerupEnlarge(bluePlayer);
                }
            }

            else return;
        }

        if (Input.GetAxis("Red PowerUp Activation") > 0.5)
        {
            if (gameBrainStorage.redHasPowerup)
            {
                if (gameBrainStorage.redReadyPowerup == "Enlarge")
                {
                    PowerupEnlarge(redPlayer);
                }
            }

            else return;
        }


    }

    public void PowerupEnlarge(GameObject player)
    {
        StartCoroutine(PowerupTimer(3f, player));
        playerWithPowerup = player;
        player.transform.localScale = new Vector3(0.3f, 4, 1);
        PlayerMovement playermovement = player.GetComponent<PlayerMovement>();
        playermovement.yMovementCap = 0.7f;

        if (player == bluePlayer)
        {
            gameBrainStorage.blueHasPowerup = false;
            gameBrainStorage.blueReadyPowerup = "None";
        }

        if (player == redPlayer)
        {
            gameBrainStorage.redHasPowerup = false;
            gameBrainStorage.redReadyPowerup = "None";
        }

    }

    public void PowerupReset(GameObject player)
    {
        player.transform.localScale = new Vector3(0.3f, 2, 1);
        PlayerMovement playermovement = player.GetComponent<PlayerMovement>();
        playermovement.yMovementCap = 2.2f;
    }

    IEnumerator PowerupTimer(float timer, GameObject player)
    {
        while (timer > 0)
        {
            timer -= Time.deltaTime;            
            yield return null;
        }

        PowerupReset(player);    
       
    }
}
