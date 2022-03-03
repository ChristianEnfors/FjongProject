using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementFallingBlocks : MonoBehaviour
{
    public float speed = 7f;
    float groundWidth = 8f;

    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
        Vector3 direction = movement.normalized;
        Vector3 velocity = direction * speed;
        transform.Translate(velocity * Time.deltaTime);

        if (transform.position.x < -groundWidth)
        {
            transform.position = new Vector3(-groundWidth, transform.position.y, transform.position.z);
        }

        if (transform.position.x > groundWidth)
        {
            transform.position = new Vector3(groundWidth, transform.position.y, transform.position.z);
        }

    }





}
