using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpActivation : MonoBehaviour
{
    public GameBrainStorage gameBrainStorage;
    public GameObject redPlayer;
    public GameObject bluePlayer;
    public GameObject ball;
    public Rigidbody2D ballRB;
    public CollisionProxy collisionProxy;

    GameObject playerWithPowerup;
    bool superAimActive;

    void Update()
    {
        if (Input.GetAxisRaw("Blue PowerUp Activation") > 0.5)
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
                    PowerupReset(bluePlayer);
                }
            }

            else return;
        }

        if (Input.GetAxisRaw("Red PowerUp Activation") > 0.5)
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
                    PowerupReset(redPlayer);
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
        superAimActive = true;
        ball.transform.SetParent(player.transform, true);      
        ball.transform.localPosition= new Vector2(1, -0.5f);

        bool done = false;

        while (done == false)
        {
            if (Input.GetAxisRaw(player.name.Remove(0, 7) + " PowerUp Activation") > 0.5f)
            {
                print("SHOOT BALL!");                
                done = true;
                superAimActive = false;
            }
            
            yield return null;
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

    public void FixedUpdate()
    {
        if (superAimActive == true)
        {
            ballRB.velocity = Vector2.zero;
            ballRB.simulated = false;
        }
    }

}
