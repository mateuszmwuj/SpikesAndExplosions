using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManagement : HealthManagement
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 12 || other.gameObject.layer == 13)
        {
            LoseHealth();
        }
    }
    
    public override void Death()
    {

    }
}
