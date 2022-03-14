using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallForce : MonoBehaviour
{
    Rigidbody2D myRb;
    public float maxVelocity = 10f;

    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();

        myRb.AddForce(new Vector2(Random.Range(-30, 30), Random.Range(-50, 50)));
    }

    private void FixedUpdate()
    {
        myRb.velocity = Vector2.ClampMagnitude(myRb.velocity, maxVelocity);
    }
}


