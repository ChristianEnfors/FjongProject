using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour
{
    public float speed = 7f;

      void Update()
    {
        Vector3 direction = new Vector3(0, 0, -1);
        Vector3 velocity = direction * speed * Time.deltaTime;
        transform.Translate(velocity);
    }
}
