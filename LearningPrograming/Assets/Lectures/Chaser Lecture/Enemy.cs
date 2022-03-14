using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform targetTranform;
    public float speed = 7f;
  
    void Update()
    {
        Vector3 difToTarget = targetTranform.position - transform.position;
        Vector3 directionToTarget = difToTarget.normalized;
        Vector3 velocity = directionToTarget * speed;

        float stoppingDistance = 1.5f;
        float distanceToTarget = difToTarget.magnitude;


        if (distanceToTarget > stoppingDistance)
        {

            transform.Translate(velocity * Time.deltaTime);
                         
        }
          

 
    }
}
