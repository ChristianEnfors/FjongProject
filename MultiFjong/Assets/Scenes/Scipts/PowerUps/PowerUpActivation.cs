using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpActivation : MonoBehaviour
{
    public GameBrainStorage gameBrainStorage;
    public GameObject redPlayer;
    public GameObject bluePlayer;
    public GameObject ball;
    public CollisionProxy collisionProxy;

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

                if (gameBrainStorage.blueReadyPowerup == "SuperAim")
                {
                    StartCoroutine(collisionProxy.CollisionChecker(bluePlayer));                    
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

                if (gameBrainStorage.redReadyPowerup == "SuperAim")
                {
                    StartCoroutine(collisionProxy.CollisionChecker(redPlayer));
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

    public IEnumerator PowerupSuperAim(GameObject player)
    {
        print("SuperAim is ready now!");

       if(Input.GetAxis(player.name.TrimStart('P','l','a','y','e','r') + " PowerUp Activation") > 0.5f)
        {
            print("test");
        }


         yield return new WaitForSeconds(3f);
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
