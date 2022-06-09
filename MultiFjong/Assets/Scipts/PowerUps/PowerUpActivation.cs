using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PowerUpActivation : MonoBehaviour
{
    public Player redPlayer;
    public Player bluePlayer;
    public GameObject ball;
    public Rigidbody2D ballRB;
    public CollisionProxy collisionProxy;
    public Player lastHit;
    public PowerUpInstantiate powerupInstantiate;
    public TrailRenderer ballTrail;
    public GameObject redSuckEffect;
    public GameObject blueSuckEffect;

    Player playerWithPowerup;
    int superAimPhase;

    void Update()
    {
        if (Input.GetAxisRaw("Blue PowerUp Activation") > 0.5)
        {
            ActivatePowerup(bluePlayer);
        }

        if (Input.GetAxisRaw("Red PowerUp Activation") > 0.5)
        {
            ActivatePowerup(redPlayer);
        }
    }

    void ActivatePowerup(Player player)
    {
        if (player.state.HasPowerup)
        {
            if (player.state.ReadyPowerup == "Enlarge")
            {
                player.powerUpEnlarge.Enlarge(player);
            }

            if (player.state.ReadyPowerup == "SuperAim")
            {
                StartCoroutine(player.powerUpSuperaim.Superaim(player));

            }
        }
    }


    IEnumerator PowerupTimer(float timer, Player player)
    {

        while (timer > 0)
        {
            timer -= Time.deltaTime;
            yield return null;
        }

        PowerupReset(player);

    }

    public void PowerupReset(Player player)
    {
        player.transform.localScale = new Vector3(1, 1, 1);
        player.movement.yMovementCap = 2.2f;
        ball.transform.parent = null;
        player.superAimSpriteRenderer.enabled = false;
        powerupInstantiate.powerupOnfield = false;
        ballTrail.startColor = Color.green;
        ballTrail.endColor = new Color(1, 1, 1, 1);

        player.state.PowerupReset();

    }

    public void OnPowerupPickup(string powerup)
    {
        lastHit.state.PowerupPickup(powerup);
    }


}
