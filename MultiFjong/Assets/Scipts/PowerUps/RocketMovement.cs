using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    public Rigidbody2D rocketRB;
    public float rocketspeed = 5;
    public GameObject projectileExplotion;
    private float currTime;

    void Update()
    {
        rocketRB.AddRelativeForce(Vector2.right * rocketspeed);
        currTime += Time.deltaTime;
        if (currTime >= 5)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.SetActive(false);
        }
        Instantiate(projectileExplotion, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}
