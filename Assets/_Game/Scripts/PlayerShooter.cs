using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private ShootingBullet _ShootingBulletPlayer1;
    [SerializeField] private ShootingBullet _ShootingBulletPlayer2;
    private bool _canShoot = true;



    public void ShootBullet()
    {
        if (_ShootingBulletPlayer1.gameObject.activeInHierarchy) _ShootingBulletPlayer1.ShootBullet();
        if (_ShootingBulletPlayer2.gameObject.activeInHierarchy) _ShootingBulletPlayer2.ShootBullet();
        
    }

    public void Fire(InputAction.CallbackContext context) {

        if (GetComponent<PlayerInput>().actions["Fire"].IsPressed()) {
            Debug.Log("FIREEEEEEE");
            ShootBullet();
        }
        else {

        }
    }


    }
