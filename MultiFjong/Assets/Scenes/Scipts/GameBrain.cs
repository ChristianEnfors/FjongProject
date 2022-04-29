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
    public GameObject playerBlue;
    public GameObject playerRed;
    public GameBrainStorage gameBrainStorage;
    public GameObject lastHit;

    [Header("UI")]    
    public GameObject redWonUI;
    public GameObject blueWonUI;
    public GameObject endgamePanel;
    public TextMeshProUGUI redScoreUI;
    public TextMeshProUGUI blueScoreUI;



    public void RestartRound()
    {
        ball.position = new Vector3(0, 0, 0);
        ballforce.roundRestarted = true;
    }


    public void PlayerScored(string player)
    {
        if (player == "Red") //Player Red
        {
            gameBrainStorage.redScore++;
            redScoreUI.text = gameBrainStorage.redScore.ToString();

            if (gameBrainStorage.redScore < 10)
            {
                RestartRound();
            }

            else GameOver("Red");

        }

        if (player == "Blue") //Player Blue
        {
            gameBrainStorage.blueScore++;
            blueScoreUI.text = gameBrainStorage.blueScore.ToString();

            if (gameBrainStorage.blueScore < 10)
            {
                RestartRound();
            }

            else GameOver("Blue");

        }
    }

    public void GameOver(string player)
    {
        if (player == "Red")
        {
            endgamePanel.SetActive(true);
            redWonUI.SetActive(true);
        }

        if (player == "Blue")
        {
            endgamePanel.SetActive(true);
            blueWonUI.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            RestartGame();
        }
    }

    public void RestartGame()
    {
        gameBrainStorage.blueScore = 0;
        gameBrainStorage.redScore = 0;
        blueScoreUI.text = gameBrainStorage.blueScore.ToString();
        redScoreUI.text = gameBrainStorage.redScore.ToString();
        endgamePanel.SetActive(false);
        blueWonUI.SetActive(false);
        redWonUI.SetActive(false);

        RestartRound();
    }    
}
