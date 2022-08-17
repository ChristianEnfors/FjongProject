using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{   
    public TextMeshProUGUI scoreUI;

    public PlayerState state;
    public PlayerMovement movement;
    public SpriteRenderer superAimSpriteRenderer;
    public PowerUpEnlarge powerUpEnlarge;
    public PowerUpSuperaim powerUpSuperaim;       
}

