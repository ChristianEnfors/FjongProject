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


    private void Awake()
    {
        playerBlue.OnScored += OnScored;
        playerRed.OnScored += OnScored;
    }

    private void OnScored(Player player)
    {
        if (player.state.Score < 10)
        {
            RestartRound();
        }

        else GameOver(player);
    }

    public void RestartRound()
    {
        ball.position = new Vector3(0, 0, 0);
        ballforce.roundRestarted = true;
    }


    public void GameOver(Player player)
    {
        player.GameOver();


        if (Input.GetKeyDown(KeyCode.Space))
        {
            RestartGame();
        }
    }

    public void RestartGame()
    {
        playerBlue.OnReset();
        playerRed.OnReset();

        RestartRound();
    }    
}
