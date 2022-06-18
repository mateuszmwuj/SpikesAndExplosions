using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManagement : HealthManagement
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 10)
        {
            LoseHealth();
        }
    }
    
    public override void Death()
    {
        Destroy(gameObject);
    }
}
