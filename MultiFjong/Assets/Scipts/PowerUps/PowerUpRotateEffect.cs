using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpRotateEffect : MonoBehaviour
{
    float rotationSpeed = 100;
    float rotation;

    void Update()
    {
        rotation += rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, rotation, 0);
    }
}
