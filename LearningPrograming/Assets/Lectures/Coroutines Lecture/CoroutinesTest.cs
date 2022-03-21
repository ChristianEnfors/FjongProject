using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutinesTest : MonoBehaviour
{
    public Transform[] followPath;
    public Transform testDestination;
    public float speed = 7;


    void Start()
    {
        //string[] messages = { "Welcome", "to", "this", "amazing", "game" };
        //StartCoroutine(PrintOutMessages(messages, 0.5f));
        //StartCoroutine(FollowPath());
    }

    


    IEnumerator FollowPath()
    {
        foreach(Transform waypoint in followPath)
        {
            yield return StartCoroutine(Move(waypoint.position, 8));

        }
    }
        


    IEnumerator Move(Vector3 destination, float speed)
    {
        while (transform.position != destination)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
            yield return null;

        }
        
    }


    IEnumerator PrintOutMessages(string[] messages, float delay)
    {
        foreach (string msg in messages)
        {
            print(msg);
            yield return new WaitForSeconds(delay);
        }
    }


}
