using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyProjectile : MonoBehaviour
{
    public SpriteRenderer spriteRend;
    public string lastSpriteName = "Explotion_63";
        
    void Update()
    {
        if(spriteRend.sprite.name == lastSpriteName)
        {
            Destroy(this.gameObject);
        }
    }
}
