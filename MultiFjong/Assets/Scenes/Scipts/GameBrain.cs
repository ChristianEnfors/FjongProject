using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameBrain : MonoBehaviour
{
    public TextMeshProUGUI redScoreUI;
    public TextMeshProUGUI blueScoreUI;

    int redScore = 0;
    int blueScore = 0;



    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown)
        {
            playerScored("Red");
        }
    }


    public void playerScored(string player)
    {
        if (player == "Red") //Player Red
        {
            redScore++;
            redScoreUI.text = redScore.ToString();

        }

        if (player == "Blue") //Player Blue
        {
            blueScore++;
            blueScoreUI.text = blueScoreUI.ToString();

        }
    }
}
