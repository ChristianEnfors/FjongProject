using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionProxy : MonoBehaviour
{
    public GameObject redPlayer;
    public GameObject bluePlayer;

    public PowerUpActivation powerupActivation;

    bool blueCollisionHit;
    bool redCollisionHit;    

    public IEnumerator CollisionChecker(GameObject player)
    {   
        if(player == redPlayer)
        {
            while (redCollisionHit == false)
            {
                yield return null;
                print("waiting to hit RED player");
            }            
        }

        if (player == bluePlayer)
        {
            while (blueCollisionHit == false)
            {
                yield return null;
                print("waiting to hit BLUE player");
            }

        }

        StartCoroutine(powerupActivation.PowerupSuperAim(player));

    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject == redPlayer)
        {
            redCollisionHit = true;
            
        }

        if (collision.gameObject == bluePlayer)
        {
            blueCollisionHit = true;
            
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject == redPlayer)
        {
            redCollisionHit = false;            
        }

        if (collision.gameObject == bluePlayer)
        {
            blueCollisionHit = false;            
        }
    }
}
