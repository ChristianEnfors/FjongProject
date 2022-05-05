using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [Header("UI")]
    public GameObject wonUI;
    public GameObject endgamePanel;
    public TextMeshProUGUI scoreUI;

    public PlayerState state;
    public PlayerMovement movement;
    public SpriteRenderer superAimSpriterenderer;

    public System.Action<Player> OnScored;

    public void Scored()
    {
        state.Score++;
        scoreUI.text = state.Score.ToString();

        OnScored?.Invoke(this);

    }

    public void OnReset()
    {
        state.Score = 0;        
        scoreUI.text = state.Score.ToString();
        
        endgamePanel.SetActive(false);
        wonUI.SetActive(false);
        
    }

    public void GameOver()
    {
        endgamePanel.SetActive(true);
        wonUI.SetActive(true);
    }

}

