using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBullet : MonoBehaviour
{
    [SerializeField] protected float _ShootDelay;
    [SerializeField] protected Bullet _BulletPrefab;
    [SerializeField] protected Transform _PrefabSpawner;
    [SerializeField] protected Transform _Gun;
    protected bool _canShoot = true;
    protected float _timerCounter;
    protected float _timerLimit;

    protected virtual void Update()
    {
        _timerCounter += Time.deltaTime;
        if (_timerCounter > _timerLimit)
        {
            _canShoot = true;
        }
    }
    public void ShootBullet()
    {
        if (_canShoot)
        {
            Instantiate(_BulletPrefab, _PrefabSpawner.transform.position, _Gun.rotation);
            _canShoot = false;
        }
    }
}
