using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpActivation : MonoBehaviour
{
    public GameBrainStorage gameBrainStorage;
       
    void Update()
    {
        if(Input.GetButtonDown("Blue PowerUp Activation"))
        {
            print("BLUE PWOER UP!");
        }

        if (Input.GetButtonDown("Red PowerUp Activation"))
        {
            print("RED PWOER UP!");
        }


    }
}
