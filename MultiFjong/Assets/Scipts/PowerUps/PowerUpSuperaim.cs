using UnityEngine;
using System.Collections;

public class PowerUpSuperaim : MonoBehaviour
{
    private bool ballCollided;
    private Coroutine coroutine;
    public SpriteRenderer aimArrow;
    public string shootButton;
    public GameObject ball;
    public Rigidbody2D ballRB;
    public GameObject suckEffect;
    public GameObject aimArrowGO;
    public Player player;
    public PowerUpActivation powerupActivation;

    public void Superaim()
    {
        // stop the currently running coroutine (if exists)
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }

        // kick off the coroutine (this MonoBehaviour will be running the coroutine)
        coroutine = StartCoroutine(SuperAimCoroutine());
    }

    private IEnumerator SuperAimCoroutine()
    {
        // clear has ball flag
        ballCollided = false;

        // step 1: wait for ball collision in order to glue it to the paddle
        while (!ballCollided)
        {            
            suckEffect.SetActive(true);
            yield return null;
        }

        // show arrow
        aimArrow.enabled = true;



        // step 2: hold the ball
        while (true)
        {
            yield return new WaitForFixedUpdate();  // wait for end of fixed update (basically converting this loop to a physics loop)

            //hold the ball in this simulated physics update
            suckEffect.SetActive(false);
            ball.transform.SetParent(aimArrowGO.transform);
            ballRB.velocity = new Vector2(0, 0);
            ballRB.simulated = false;
            ball.transform.localPosition = new Vector2(0.8f, 0f);
            ball.transform.localRotation = Quaternion.identity;

            break;
        }

        while (true)
        {
            // wait until player presses shoot button
            if (Input.GetAxisRaw(shootButton) > 0.5f)
            {
                yield return new WaitForFixedUpdate();
                ball.transform.SetParent(null);
                aimArrow.enabled = false;
                ballRB.simulated = true;
                ballRB.AddRelativeForce(new Vector2(5, 0), ForceMode2D.Impulse);
                break;
            }
            yield return null;
        }
        // clear reference to coroutine and reset powerup
        coroutine = null;
        player.state.PowerupReset();
        powerupActivation.PowerupResetEffects(player);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // we collide with ball
        if (ballCollided == false && collision.gameObject.CompareTag("Ball"))
        {
            ballCollided = true;
        }
    }
}
