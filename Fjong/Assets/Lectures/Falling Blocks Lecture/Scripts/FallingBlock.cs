using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour
{
    private float speed;
    public float minSpeed;
    public float maxSpeed;
  

    private void Start()
    {
        speed = Mathf.Lerp(minSpeed, maxSpeed, Difficulty.GetDifficultyPercent());
    }

    void Update()
    {
        Vector3 direction = new Vector3(0, 0, -1);
        Vector3 velocity = direction * speed * Time.deltaTime;
        transform.Translate(velocity);    
        
        if(transform.position.z <= -16)
        {
            Destroy(gameObject);
        }
                    
    }
}
