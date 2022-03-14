using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallForce : MonoBehaviour
{
    Rigidbody2D myRb;
    float randomX;
    float randomY;
    public float maxVelocity = 10f;
    
    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
        randomX = Random.Range(10, 30);
        randomY = Random.Range(10, 30);
        Vector2 randomVector = new Vector2(randomX, randomY);
        myRb.AddForce(randomVector);        
    }

    private void FixedUpdate()
    {
        myRb.velocity = Vector2.ClampMagnitude(myRb.velocity, maxVelocity);
    }

       
    void Update()
    {
        
    }
}
