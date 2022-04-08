using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 7f;
    public string verticalStickName;
    public string horizontalStickName;
    public float rotationSpeed = 10;

    float yMovementCap = 2.2f;

    Rigidbody2D playerRb;
    float inputX;
    float inputY;
    Vector2 inputVector;
    float playerPadAngle;
    float stickDirectionDegrees;
    float angleDiff;


    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        inputY = Input.GetAxis(verticalStickName);
        inputX = Input.GetAxis(horizontalStickName);
        inputVector = new Vector2(inputX, inputY).normalized;

        if (inputVector.magnitude > 0)
        {
            stickDirectionDegrees = 90 - Mathf.Atan2(-inputY, inputX) * Mathf.Rad2Deg;
            playerPadAngle = Mathf.LerpAngle(playerPadAngle, stickDirectionDegrees, Time.deltaTime * rotationSpeed);
        }


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

        playerRb.rotation = playerPadAngle;
                
    }


}
