using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreChecker : MonoBehaviour
{
    public GameBrain gameBrain;
        
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "BlueScoreZone")
        {
            gameBrain.playerBlue.Scored();
        }

        if(collision.name == "RedScoreZone")
        {
            gameBrain.playerRed.Scored();
        }
    }

}
