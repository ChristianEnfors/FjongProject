using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallForce : MonoBehaviour
{
    public Rigidbody2D ballRb;
    public float maxVelocity;

    public GameBrain gamebrain;
    [Header ("Bounce Effect Enchancers")]
    public float swingEnchancer;
    public float leverageEnchancer;
    [HideInInspector] public bool roundRestarted;

    public Vector2[] startDirections;

    public float bounceEffect;
    bool ballCollided;
    Vector2 contactNormal;
    Vector2 contactPoint;
    GameObject contactObject;

    void Start()
    {
        roundRestarted = true;
    }


    private void FixedUpdate()
    {
        ballRb.velocity = Vector2.ClampMagnitude(ballRb.velocity, maxVelocity);

        if (roundRestarted == true)
        {
            ballRb.velocity = Vector2.zero;
            Vector2 randomStartDirection = startDirections[Random.Range(0, 6)];
            ballRb.AddForce(randomStartDirection, ForceMode2D.Impulse);
            roundRestarted = false;
        }

        if (ballCollided == true)
        {
            ballRb.AddForce(contactNormal * bounceEffect, ForceMode2D.Impulse);
            Debug.DrawLine(contactPoint, contactPoint + contactNormal * bounceEffect, Color.red, 1);

            ballCollided = false;
        }


    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ballCollided = true;
            contactNormal = collision.GetContact(0).normal.normalized;
            contactPoint = collision.GetContact(0).point;
            contactObject = collision.gameObject;

            float distancePointPivot = Vector2.Distance(contactPoint, contactObject.transform.position);

            PlayerMovement playerMovement = collision.gameObject.GetComponent<PlayerMovement>();
            bounceEffect = ((playerMovement.diffAngle / 90) * swingEnchancer) * (distancePointPivot * leverageEnchancer);
                        
            gamebrain.lastHit = gameObject;

        }

    }


}


