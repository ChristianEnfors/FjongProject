using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public event System.Action OnPlayerDeath;
            
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {            
            
            if (OnPlayerDeath != null)

            {
                OnPlayerDeath();
            }

            Destroy(gameObject);
        }
    }
}
