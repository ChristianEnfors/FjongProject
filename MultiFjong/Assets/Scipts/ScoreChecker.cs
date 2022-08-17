using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreChecker : MonoBehaviour
{    
    public Player bluePlayer;
    public Player redPlayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "BlueScoreZone")
        {
            bluePlayer.state.Scored();
        }

        if(collision.name == "RedScoreZone")
        {
            redPlayer.state.Scored();
        }
    }

}
