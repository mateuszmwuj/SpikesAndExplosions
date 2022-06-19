using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManagement : HealthManagement
{
    public Animator _Animator;
    private string ENEMY_DEATH_TRIGGER = "death";

    public float _destroyDelay = 0.5f;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 10)
        {
            LoseHealth();
        }
    }
    
    public override void Death()
    {
        _Animator.SetTrigger(ENEMY_DEATH_TRIGGER);

        var EnemyMovement = GetComponent<EnemyMovement>();
        if (EnemyMovement)
            EnemyMovement.enabled = false;

        Destroy(gameObject, _destroyDelay);
    }
}
