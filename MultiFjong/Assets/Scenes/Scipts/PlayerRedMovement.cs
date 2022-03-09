using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRedMovement : MonoBehaviour
{
    public float speed = 7f;
    float screenHalfHeightInWorldUnits;

    
    void Start()
    {
        
        float halfPlayerHeight = transform.localScale.y / 2f;
        screenHalfHeightInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize - halfPlayerHeight;
        print(screenHalfHeightInWorldUnits);
        
       
    }

    void Update()
    {        
        float inputY = Input.GetAxisRaw("Vertical");
        float velocity = inputY * speed;
        transform.Translate(Vector2.up * velocity * Time.deltaTime);

        if(transform.position.y < -screenHalfHeightInWorldUnits)
        {
            transform.position = new Vector2(transform.position.x, -screenHalfHeightInWorldUnits);
            
        }
        if (transform.position.y > screenHalfHeightInWorldUnits)
        {
            transform.position = new Vector2(transform.position.x, screenHalfHeightInWorldUnits);
        }

        
    }
}
