using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private ShootingBullet _ShootingBullet;
    private bool _canShoot = true;

    public void ShootBullet()
    {
        _ShootingBullet.ShootBullet();
    }

    
}
