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
    float borderHalfHeight = 0.7f;

    Rigidbody2D playerRb;
    Vector2 direction;
    float inputX;
    Vector2 inputY;


    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();

        float halfPlayerHeight = transform.localScale.y / 2f;
        //screenHalfHeightInWorldUnits = Camera.main.orthographicSize - halfPlayerHeight - borderHalfHeight;
    }
        
    void Update()
    {
        inputY = new Vector2(0, Input.GetAxisRaw(verticalStickName));
        inputX = Input.GetAxisRaw(horizontalStickName);
        direction = inputY.normalized;

        if (transform.position.y < -yMovementCap)
        {
            transform.position = new Vector2(transform.position.x, -yMovementCap);

        }
        if (transform.position.y > yMovementCap)
        {
            transform.position = new Vector2(transform.position.x, yMovementCap);
        }

    }

    private void FixedUpdate()
    {
        playerRb.position += direction * speed * Time.deltaTime;
        playerRb.rotation += inputX * rotationSpeed * Time.deltaTime;

    }


}
