using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rbPlayer : MonoBehaviour
{
    public float speed = 7f;
    Rigidbody myRigidbody;
    Vector3 velocity;
    int CoinCount;
    
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 direction = input.normalized;
        velocity = direction * speed;   
    }

    private void FixedUpdate()
    {
        myRigidbody.position += velocity * Time.deltaTime;
    }

    void OnTriggerEnter(Collider theCoinCollider)
    {
        if (theCoinCollider.tag == "Coin")
        {
            Destroy(theCoinCollider.gameObject);
            CoinCount = CoinCount + 1;
            print(CoinCount);
        }           
            
    }
        
}
