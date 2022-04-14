using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameBrain : MonoBehaviour
{
    public TextMeshProUGUI redScoreUI;
    public TextMeshProUGUI blueScoreUI;
    public Transform ball;
    public BallForce ballforce;
    public GameObject redWonUI;
    public GameObject blueWonUI;
    public GameObject endgamePanel;
    public GameObject playerBlue;
    public GameObject playerRed;
    public Image bluePowerUP;
    public Image redPowerUP;

    public GameBrainStorage gameBrainStorage;

    [HideInInspector] public GameObject lastHit;

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

    public void PowerUpEnlarge()
    {
        if (lastHit == playerBlue)
        {
            gameBrainStorage.blueHasPowerUp = true;
            gameBrainStorage.blueReadyPowerUp = "Enlarge";
            bluePowerUP.color = Color.yellow;
        }

        if (lastHit == playerRed)
        {
            gameBrainStorage.redHasPowerUp = true;
            gameBrainStorage.redReadyPowerUp = "Enlarge";
            bluePowerUP.color = Color.yellow;
        }
    }

}
