using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManagement : HealthManagement
{
    public Animator _Animator;
    public GameObject _Flag;
    private string ENEMY_DEATH_TRIGGER = "death";

    public float _destroyDelay = 1f;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 10)
        {
            LoseHealth();
        }
    }
    
    public override void Death()
    {
        gameObject.layer = 6;
        _Animator.SetTrigger(ENEMY_DEATH_TRIGGER);
        _Flag.SetActive(true);

        var EnemyMovement = GetComponent<EnemyMovement>();
        if (EnemyMovement)
            EnemyMovement.enabled = false;

        Destroy(gameObject, _destroyDelay);
    }
}
