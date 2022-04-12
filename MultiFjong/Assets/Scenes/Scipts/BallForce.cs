using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallForce : MonoBehaviour
{
    public Rigidbody2D myRb;
    public float maxVelocity;
    
    void Start()
    {
        RandomBallForce();
    }

    private void FixedUpdate()
    {
        myRb.velocity = Vector2.ClampMagnitude(myRb.velocity, maxVelocity);
    }
       
    public void RandomBallForce()
    {
        myRb.velocity = new Vector2(0, 0);
        
        Vector2 randomForce = Random.insideUnitCircle.normalized * 4;
        Debug.DrawLine(transform.position, randomForce, Color.red, 3);
        myRb.AddForce(randomForce, ForceMode2D.Impulse);
    }

}


