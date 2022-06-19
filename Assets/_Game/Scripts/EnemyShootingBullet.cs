using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class EnemyShootingBullet : ShootingBullet
{
    [SerializeField] private Animator _Animator;
    private string ENEMY_SHOT_TRIGGER = "shot";
    private string ENEMY_IDLE_TRIGGER = "idle";
    private Transform _Target;
    public float distanceToShoot = 4f;
    protected override void Update()
    {
        FindPlayersAndInit();
        if (_Target != null)
        {
            if (Vector3.Distance(transform.position, _Target.position) <= distanceToShoot)
            {
                _timerCounter += Time.deltaTime;
                if (_timerCounter > _ShootDelay)
                {
                    _canShoot = true;
                }

                if(_canShoot)
                {
                    ShootBullet();
                    _Animator.SetTrigger(ENEMY_IDLE_TRIGGER);
                    _Animator.SetTrigger(ENEMY_SHOT_TRIGGER);
                    _canShoot = false;
                    _timerCounter = 0;
                }
            }
        }
    }

    [Button]
    private void FindPlayersAndInit()
    {
        if (_Target != null)
            return;
        
        var playerHealth = FindObjectOfType<PlayerHealthManagement>();

        if (playerHealth != null)
        {
            _Target = playerHealth.transform;
        }
    }
    private void LookAtTarget()
    {
        if (_Target!=null)
        {
            if (_Target.transform.position.x < transform.position.x)
                transform.eulerAngles = new Vector3(0,0,0);
            else
                transform.eulerAngles = new Vector3(0,180,0);
        }
    }
}
