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
    }

    void Update()
    {
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

        // Old rotation:
        //playerRb.rotation += inputX * rotationSpeed * Time.deltaTime;

        Vector2 rotation = new Vector2(inputX, inputY).normalized;
        float padRotation = 90 - Mathf.Atan2(inputY, inputX) * Mathf.Rad2Deg * -1;
        print(padRotation);
        playerRb.rotation = padRotation;
    }


}
