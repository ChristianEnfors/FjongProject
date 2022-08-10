using UnityEngine;
using System.Collections;

public class PowerUpSuperaim : MonoBehaviour
{
    private bool ballLocked;    
    private Coroutine coroutine;    
    public SpriteRenderer aimArrow;
    public string shootButton;
    public GameObject ball;
    public Rigidbody2D ballRB;
    public GameObject suckEffect;
    
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
        ballLocked = false;              

        // step 1: wait for ball collision in order to glue it to the paddle
        while(true)
        {
            if(ballLocked)
            {
                break;
            }
            print("Waiting for ball to hit pad");
            suckEffect.SetActive(true);
            yield return null;
        }

        // TODO: show arrow
        aimArrow.enabled = true;



        // step 2: hold the ball
        while (true)
        {
            yield return new WaitForFixedUpdate();  // wait for end of fixed update (basically converting this loop to a physics loop)

            // TODO: hold the ball in this simulated physics update
            suckEffect.SetActive(false);
            ball.transform.SetParent(this.transform);            
            ballRB.velocity = new Vector2(0, 0);
            ballRB.isKinematic = true;



            print("Ball shoud be locked now");

            // wait until player presses shoot button
            if (Input.GetAxisRaw(shootButton) > 0.5f)
            {
                print("Shoot!");
                break;
            }
        }

        // step 3: shoot ball
        // TODO: shoot ball


        // clear reference to coroutine instead of waiting for memory to be cleared
        coroutine = null;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {                      
        // we collide with ball
        if (ballLocked == false && collision.gameObject.CompareTag("Ball"))
        {
            ballLocked = true;
                       
        }
    }      
}
