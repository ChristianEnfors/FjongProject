using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PowerUpActivation : MonoBehaviour
{
    public GameBrainStorage gameBrainStorage;
    public GameObject redPlayer;
    public GameObject bluePlayer;
    public GameObject ball;
    public Rigidbody2D ballRB;
    public CollisionProxy collisionProxy;
    public GameObject lastHit;
    public Image bluePowerup;
    public Image redPowerup;
    public PowerUpInstantiate powerupInstantiate;
    public TrailRenderer ballTrail;
    public GameObject redSuckEffect;
    public GameObject blueSuckEffect;

    GameObject playerWithPowerup;
    int superAimPhase;

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
                    gameBrainStorage.blueHasPowerup = false;
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
                    gameBrainStorage.redHasPowerup = false;

                }
            }

            else return;
        }


    }

    public void PowerupEnlarge(GameObject player)
    {
        StartCoroutine(PowerupTimer(6f, player));
        playerWithPowerup = player;
        player.transform.localScale = new Vector3(2, 2, 1);
        PlayerMovement playermovement = player.GetComponent<PlayerMovement>();
        playermovement.yMovementCap = 0.7f;
    }

    public IEnumerator PowerupSuperAim(GameObject player)
    {
        superAimPhase = 1;
        ball.transform.SetParent(player.transform, false);
        ball.transform.localRotation = Quaternion.Euler(Vector3.zero);
        ball.transform.localPosition = new Vector2(1, -0.5f);
        SpriteRenderer superAimAim = player.transform.Find("SuperAimAim").GetComponent<SpriteRenderer>();
        GameObject suckEffect = player.transform.Find("SuckEffect").gameObject;
        suckEffect.SetActive(false);
        superAimAim.enabled = true;

        bool done = false;

        while (done == false)
        {
            if (Input.GetAxisRaw(player.name.Remove(0, 7) + " PowerUp Activation") > 0.5f)
            {
                superAimPhase = 2;
                done = true;
                PowerupReset(player);
            }

            yield return null;
        }
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

    public void PowerupReset(GameObject player)
    {
        player.transform.localScale = new Vector3(1, 1, 1);
        PlayerMovement playermovement = player.GetComponent<PlayerMovement>();
        playermovement.yMovementCap = 2.2f;
        ball.transform.parent = null;
        SpriteRenderer superAimAim = player.transform.Find("SuperAimAim").GetComponent<SpriteRenderer>();
        superAimAim.enabled = false;
        powerupInstantiate.powerupOnfield = false;
        ballTrail.startColor = Color.green;
        ballTrail.endColor = new Color(1, 1, 1, 1);

        if (player == bluePlayer)
        {
            gameBrainStorage.blueHasPowerup = false;
            gameBrainStorage.blueReadyPowerup = null;
            bluePowerup.color = Color.white;
        }

        if (player == redPlayer)
        {
            gameBrainStorage.redHasPowerup = false;
            gameBrainStorage.redReadyPowerup = null;
            redPowerup.color = Color.white;
        }
    }

    public void OnPowerupPickup(string powerup)
    {
        if (lastHit == bluePlayer)
        {
            gameBrainStorage.blueHasPowerup = true;
            gameBrainStorage.blueReadyPowerup = powerup;

            if (powerup == "Enlarge")
            {
                bluePowerup.color = Color.yellow;
            }

            if (powerup == "SuperAim")
            {
                bluePowerup.color = Color.red;
            }

        }

        if (lastHit == redPlayer)
        {
            gameBrainStorage.redHasPowerup = true;
            gameBrainStorage.redReadyPowerup = powerup;

            if (powerup == "Enlarge")
            {
                redPowerup.color = Color.yellow;
            }

            if (powerup == "SuperAim")
            {
                redPowerup.color = Color.red;
            }
        }

    }

    public void FixedUpdate()
    {
        if (superAimPhase == 1)
        {
            ballRB.velocity = Vector2.zero;
            ballRB.simulated = false;
        }

        if (superAimPhase == 2)
        {
            ballRB.simulated = true;
            ballRB.AddRelativeForce(new Vector2(8, 0), ForceMode2D.Impulse);
            ballTrail.startColor = Color.red;
            ballTrail.endColor = new Color(1, 0.6f, 0);
            superAimPhase = 0;
        }
    }

}
