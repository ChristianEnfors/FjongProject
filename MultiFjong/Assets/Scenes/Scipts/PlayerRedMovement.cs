using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRedMovement : MonoBehaviour
{
    public float speed = 7f;
    float screenHalfHeightInWorldUnits;

    Rigidbody2D playerRb;
    float velocity;
    



    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();

        float halfPlayerHeight = transform.localScale.y / 2f;
        screenHalfHeightInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize - halfPlayerHeight;
        // print(screenHalfHeightInWorldUnits);
        
       
    }

    private void FixedUpdate()
    {
        playerRb.position += Vector2.up * speed * Time.deltaTime;
    }

    void Update()
    {        
        float inputY = Input.GetAxisRaw("Vertical");
        velocity = inputY * speed;

       // transform.Translate(Vector2.up * velocity * Time.deltaTime);
        

       /* if(transform.position.y < -screenHalfHeightInWorldUnits)
        {
            transform.position = new Vector2(transform.position.x, -screenHalfHeightInWorldUnits);
            
        }
        if (transform.position.y > screenHalfHeightInWorldUnits)
        {
            transform.position = new Vector2(transform.position.x, screenHalfHeightInWorldUnits);
        }
        */

        
    }
}
