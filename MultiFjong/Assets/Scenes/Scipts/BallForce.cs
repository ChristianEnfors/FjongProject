using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallForce : MonoBehaviour
{
    Rigidbody2D myRb;
    public float maxVelocity = 10f;

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
        myRb = GetComponent<Rigidbody2D>();

        Vector2 randomForce = Random.insideUnitCircle.normalized * 4;
        Debug.DrawLine(transform.position, randomForce, Color.red, 3);
        myRb.AddForce(randomForce, ForceMode2D.Impulse);
    }

}


