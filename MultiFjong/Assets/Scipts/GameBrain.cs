using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameBrain : MonoBehaviour
{
    [Header("Gameplay elements")]
    public Transform ball;
    public BallForce ballforce;
    public Player playerBlue;
    public Player playerRed;
    public GameObject lastHit;

    public void OnScored(Player player)
    {
        if (player.state.Score < 5)
        {
            RestartRound();
        }

        else GameOver(player);
    }

    public void RestartRound()
    {
        ball.position = new Vector3(0, 0, 0);
        ballforce.roundRestarted = true;

        if(playerBlue.gameObject.activeInHierarchy == false)
        {
            playerBlue.gameObject.SetActive(true);
        }

        if (playerRed.gameObject.activeInHierarchy == false)
        {
            playerRed.gameObject.SetActive(true);
        }
    }


    public void GameOver(Player player)
    {
        player.state.GameOver();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            RestartGame();
        }

    }

    public void RestartGame()
    {
        playerBlue.state.OnReset();
        playerRed.state.OnReset();

        RestartRound();
    }
}
