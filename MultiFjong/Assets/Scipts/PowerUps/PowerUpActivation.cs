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

    void ActivatePowerup(Player player)
    {
        if (player.state.HasPowerup)
        {
            if (player.state.ReadyPowerup == "Enlarge")
            {
                PowerupEnlarge(player);
            }

            if (player.state.ReadyPowerup == "SuperAim")
            {
                StartCoroutine(collisionProxy.CollisionChecker(player));
                player.state.HasPowerup = false;
            }
        }
    }

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

    public void PowerupEnlarge(Player player)
    {
        StartCoroutine(PowerupTimer(6f, player));
        playerWithPowerup = player;
        player.transform.localScale = new Vector3(2, 2, 1);
        PlayerMovement playermovement = player.GetComponent<PlayerMovement>();
        playermovement.yMovementCap = 0.7f;
    }

    public IEnumerator PowerupSuperAim(Player player)
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
        player.superAimSpriterenderer.enabled = false;
        powerupInstantiate.powerupOnfield = false;
        ballTrail.startColor = Color.green;
        ballTrail.endColor = new Color(1, 1, 1, 1);

        player.state.PowerupReset();
        
    }

    public void OnPowerupPickup(string powerup)
    {
        lastHit.state.PowerupPickup(powerup);
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
