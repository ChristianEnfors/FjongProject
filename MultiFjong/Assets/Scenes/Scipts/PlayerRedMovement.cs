using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRedMovement : MonoBehaviour
{
    public float speed = 7f;
    public float rotationSpeed;
    float screenHalfHeightInWorldUnits;
    float borderHalfHeight = 0.7f;

    Rigidbody2D playerRb;
    Vector2 direction;
    float inputX;


    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();

        float halfPlayerHeight = transform.localScale.y / 2f;
        screenHalfHeightInWorldUnits = Camera.main.orthographicSize - halfPlayerHeight - borderHalfHeight;

    }

    private void FixedUpdate()
    {
        playerRb.position += direction * speed * Time.deltaTime;
        playerRb.rotation += inputX * rotationSpeed * Time.deltaTime;

    }

    void Update()
    {
        Vector2 inputY = new Vector2(0, Input.GetAxisRaw("Vertical"));
        inputX = Input.GetAxisRaw("Horizontal");
        direction = inputY.normalized;

        if (transform.position.y < -screenHalfHeightInWorldUnits)
        {
            transform.position = new Vector2(transform.position.x, -screenHalfHeightInWorldUnits);

        }
        if (transform.position.y > screenHalfHeightInWorldUnits)
        {
            transform.position = new Vector2(transform.position.x, screenHalfHeightInWorldUnits);
        }



    }
}
