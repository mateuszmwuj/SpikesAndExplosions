using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManagement : HealthManagement
{
    public float timerForPlayerToHit = 1f;
    private float timerForHitCounter = 0f;
    private bool canBeHit = true;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (canBeHit)
        {
            if (other.gameObject.layer == 12 || other.gameObject.layer == 13)
            {
                canBeHit = false;
                if (_ParticlePrefab) 
                    Instantiate(_ParticlePrefab, transform.position, transform.rotation);

                LoseHealth();
            }
        }
    }

    private void Update()
    {
        if (!canBeHit)
            timerForHitCounter += Time.deltaTime;

        if (timerForHitCounter >= timerForPlayerToHit)
        {
            canBeHit = true;
            timerForHitCounter = 0f;
        }
    }
    public override void Death()
    {

    }
}
