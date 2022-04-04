using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 7f;
    public float rotationSpeed;
    public string verticalStickName;
    public string horizontalStickName;

    float yMovementCap = 2.2f;    

    Rigidbody2D playerRb;
    Vector2 direction;
    float inputX;
    float inputY;


    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();

        float halfPlayerHeight = transform.localScale.y / 2f;
    }

    void Update()
    {
        //inputY = new Vector2(0, Input.GetAxis(verticalStickName));

        inputY = Input.GetAxis(verticalStickName);
        inputX = Input.GetAxis(horizontalStickName);
        
        {
            if (transform.position.y < -yMovementCap)
            {
                transform.position = new Vector2(transform.position.x, -yMovementCap);

            }
            if (transform.position.y > yMovementCap)
            {
                transform.position = new Vector2(transform.position.x, yMovementCap);
            }
        }
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(inputY) > 0.7)
        {
            playerRb.position += Vector2.up * inputY * speed * Time.deltaTime;
        }

        playerRb.rotation += inputX * rotationSpeed * Time.deltaTime;
    }


}
