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

    public IEnumerator CollisionChecker(Player player)
    {   
        if(player == redPlayer)
        {
            while (redCollisionHit == false)
            {
                print("waiting to hit RED player");
                GameObject suckEffect = player.transform.Find("SuckEffect").gameObject;
                suckEffect.SetActive(true);
                yield return null;
            }            
        }

        if (player == bluePlayer)
        {
            while (blueCollisionHit == false)
            {
                print("waiting to hit BLUE player");
                GameObject suckEffect = player.transform.Find("SuckEffect").gameObject;
                suckEffect.SetActive(true);
                yield return null;
            }

        }

        //StartCoroutine(powerupActivation.PowerupSuperAim(player));

    }


    private void OnCollisionEnter2D(Collision2D collision)
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
