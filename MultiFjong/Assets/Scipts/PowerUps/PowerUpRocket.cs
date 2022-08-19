using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpRocket : MonoBehaviour
{
    public GameObject rocketAim;
    private Coroutine coroutine;
    public LineRenderer linerenderer;
    public string shootButton;
    private bool triggerReleased;
    public GameObject rocketPrefab;
    public Transform rocketSpawnPos;
    public Player player;
    public PowerUpActivation powerupActivation;
        
    public void Rocket()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }

        coroutine = StartCoroutine(RocketCoroutine());
    }

    private IEnumerator RocketCoroutine()
    {
        // step 1: press trigger to show lasersight
        // step 1.5: Raycast to get the second point for the line renderer. And draw line renderar from origin to that point.
        while (true)
        {
            linerenderer.enabled = true;
            RaycastHit2D rcHit = Physics2D.Raycast(rocketAim.transform.position, rocketAim.transform.right);
            Vector2 rcHitPoint = rcHit.point;
            linerenderer.SetPosition(0, rocketAim.transform.position);
            linerenderer.SetPosition(1, rcHitPoint);
            
            // Wait for player to relase button to not instant-confirm.
            if (Input.GetAxisRaw(shootButton) == 0f)
            {
                triggerReleased = true;
            }

            if (triggerReleased)
            {
                if (Input.GetAxisRaw(shootButton) == 1f)
                {
                    linerenderer.enabled = false;
                    break;
                }

            }

            yield return null;
        }
        // step 3: insansiate the rocket. Speed, explotion etc are on rocket prefab
        Instantiate(rocketPrefab, rocketSpawnPos.position, rocketSpawnPos.transform.rotation);

        yield return new WaitForSeconds (2);

        powerupActivation.PowerupResetEffects(player);


    }
}
