using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounce : MonoBehaviour
{
    public Rigidbody2D ballRb;
    public float bounceEffect = 10f;
    public GameBrain gamebrain;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Vector2 contactNormal = -collision.GetContact(0).normal;
            Vector2 contactPoint = collision.GetContact(0).point;
            
            ballRb.AddForce(contactNormal * bounceEffect, ForceMode2D.Impulse);
            Debug.DrawLine(contactPoint, contactPoint + contactNormal * 2, Color.red, 2);
            gamebrain.lastHit = gameObject;
            
        }

    }

}
