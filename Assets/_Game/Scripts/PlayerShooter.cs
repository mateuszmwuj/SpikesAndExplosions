using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private ShootingBullet _ShootingBulletPlayer1;
    [SerializeField] private ShootingBullet _ShootingBulletPlayer2;
    [SerializeField] private Animator _Fire1Anim;
    [SerializeField] private Animator _Fire2Anim;
    [SerializeField] private AudioSource _AudioSource;
    [SerializeField] private AudioClip _ShootClip;

    private Coroutine _fireCoroutine;
    private bool _canShoot = true;



    public void ShootBullet()
    {
        if (_Fire1Anim.gameObject.activeInHierarchy)
            _Fire1Anim.SetTrigger("shoot");
        if (_Fire2Anim.gameObject.activeInHierarchy)
            _Fire2Anim.SetTrigger("shoot");

        if (_ShootingBulletPlayer1.gameObject.activeInHierarchy) _ShootingBulletPlayer1.ShootBullet();
        if (_ShootingBulletPlayer2.gameObject.activeInHierarchy) _ShootingBulletPlayer2.ShootBullet();

        if(_AudioSource && _ShootClip)
            _AudioSource.PlayOneShot(_ShootClip);
    }

    public void Fire(InputAction.CallbackContext context)
    {

        if (GetComponent<PlayerInput>().actions["Fire"].IsPressed())
        {
            // Debug.Log("FIREEEEEEE");
            ShootBullet();
        }
        else
        {

        }
    }

}
