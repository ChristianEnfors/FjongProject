using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 7;
    public float smoothMoveTime = 0.1f;
    public float turnSpeed = 8;

    float smoothInputMagnitude;
    float smoothMoveVelocity;
    float angle;
    Rigidbody myRigidbody;
    Vector3 velocity;
    float inputMagnitude;

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {

        Vector3 inputDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        inputMagnitude = Vector3.Magnitude(inputDirection);
        smoothInputMagnitude = Mathf.SmoothDamp(smoothInputMagnitude, inputMagnitude, ref smoothMoveVelocity, smoothMoveTime);
        velocity = transform.forward * speed * smoothInputMagnitude;

        if (inputMagnitude > 0)
        {
            float targetAngle = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg;
            angle = Mathf.LerpAngle(angle, targetAngle, Time.deltaTime * turnSpeed);
        }

    }

    private void FixedUpdate()
    {
        if (inputMagnitude > 0)
        {
            myRigidbody.MoveRotation(Quaternion.Euler(Vector3.up * angle));
        }

        myRigidbody.MovePosition(myRigidbody.position + velocity * Time.deltaTime);
    }


}
