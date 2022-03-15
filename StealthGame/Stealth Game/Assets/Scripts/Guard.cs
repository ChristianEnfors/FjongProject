using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
    public Transform pathHolder;
    public float speed = 7f;
    public float distanceToWaypoint =1f;

    public List<Transform> wpList = new List<Transform>();

    private void Start()
    {
        foreach (Transform waypoint in pathHolder)
        {
            wpList.Add(waypoint);

        }
    }


    private void Update()
    {
        while (distanceToWaypoint <= 1)
        {
            // move object to waypoint               

            float distanceToWaypoint = Vector3.Distance(waypoint.position, transform.position);

            Vector3 direction = (waypoint.position - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime);

            print(waypoint);
        }
    }




    void OnDrawGizmos()
    {
        Vector3 startPosition = pathHolder.GetChild(0).position;
        Vector3 previousPosition = startPosition;

        foreach (Transform waypoint in pathHolder)
        {
            Gizmos.DrawSphere(waypoint.position, 0.3f);
            Gizmos.DrawLine(previousPosition, waypoint.position);
            previousPosition = waypoint.position;
        }

        Gizmos.DrawLine(previousPosition, startPosition);
    }




}
