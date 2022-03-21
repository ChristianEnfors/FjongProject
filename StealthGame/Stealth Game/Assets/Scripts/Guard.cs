using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
    public Transform pathHolder;
    public float speed;
    public float distanceToWaypoint = 1f;
    public float waitTime = 1;
    public float turnSpeed = 90;


    private void Start()
    {
        StartCoroutine(Patrol());
    }
    

    IEnumerator Patrol()
    {
        while (true)
        {

            foreach (Transform waypoint in pathHolder)
            {
                yield return StartCoroutine(Move(waypoint.position, speed));
                yield return new WaitForSeconds (waitTime);
                yield return StartCoroutine(TurnToFace(waypoint.position));
            }
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

    IEnumerator TurnToFace(Vector3 destination)
    {
        Vector3 dirToLookTarget = (destination - transform.position).normalized;
        float targetAngle = 90 - Mathf.Atan2(dirToLookTarget.z, dirToLookTarget.x) * Mathf.Rad2Deg;
       
        while(Mathf.DeltaAngle(transform.eulerAngles.y, targetAngle) > 0.05f)
        {
            float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetAngle, turnSpeed * Time.deltaTime);
            transform.eulerAngles = Vector3.up * angle;
            yield return null;
            
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
