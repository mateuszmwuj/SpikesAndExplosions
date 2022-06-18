using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBullet : MonoBehaviour
{
    [SerializeField] private float _ShootDelay;
    [SerializeField] private Bullet _BulletPrefab;
    [SerializeField] private Transform _PrefabSpawner;
    private bool _canShoot = true;
    private float _timerCounter;
    private float _timerLimit;

    private void Update()
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
            Instantiate(_BulletPrefab, _PrefabSpawner);
            _canShoot = false;
        }
    }
}
