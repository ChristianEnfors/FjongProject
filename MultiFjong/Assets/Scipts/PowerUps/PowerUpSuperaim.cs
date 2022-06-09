using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSuperaim : MonoBehaviour
{

    public Player player;
    public Rigidbody2D ballRB;
    public GameObject ball;
    public TrailRenderer ballTrail;
    public PowerUpInstantiate powerupInstantiate;
    public SpriteRenderer superAimArrow;
    public GameObject suckEffect;

    public int phase;

    public IEnumerator Superaim(Player player)
    {
        player.state.PowerupReset();
        print("Phase 0");

        if (phase == 0)
        {
            phase = 1;
            print("Phase 1");
        }

        while (phase == 3)
        {
            ball.transform.SetParent(player.transform, false);
            ball.transform.localRotation = Quaternion.Euler(Vector3.zero);
            ball.transform.localPosition = new Vector2(1, -0.5f);
            suckEffect.SetActive(false);
            superAimArrow.enabled = true;

            print("Phase 3");

            while (phase == 3)
            {
                if (Input.GetAxisRaw(player.name.Remove(0, 7) + " PowerUp Activation") > 0.5f)
                {
                    phase = 4;
                    print("Phase 4");
                    ResetPowerup();
                }

                yield return null;
            }

            yield return null;
        }

        yield return null;


    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (phase == 1 && collision.gameObject.tag == "Ball")
        {
            phase = 2;
            print("Phase 2");
        }
    }

    public void ResetPowerup()
    {
        ball.transform.parent = null;
        player.superAimSpriteRenderer.enabled = false;
        powerupInstantiate.powerupOnfield = false;
        ballTrail.startColor = Color.green;
        ballTrail.endColor = new Color(1, 1, 1, 1);

    }



    public void FixedUpdate()
    {
        if (phase == 2)
        {
            ballRB.velocity = Vector2.zero;
            ballRB.simulated = false;
            phase = 3;            
        }

        if (phase == 4)
        {
            ballRB.simulated = true;
            ballRB.AddRelativeForce(new Vector2(8, 0), ForceMode2D.Impulse);
            ballTrail.startColor = Color.red;
            ballTrail.endColor = new Color(1, 0.6f, 0);
            phase = 0;
        }
    }


}
