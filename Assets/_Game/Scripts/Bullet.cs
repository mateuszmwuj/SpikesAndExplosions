using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _Rd;
    [SerializeField] private float _DestroyTimer = 0.1f;
    [SerializeField] private float _TimeForDestroy = 2f;
    [SerializeField] private float _Speed;
    private float timerCounter = 0.0f;
    private float timeStart = 0.0f;
    [SerializeField] private float delayForCheck = 0.1f;
    private void OnCollisionEnter2D(Collision2D other)
    {
        //explosion
        if (timerCounter - timeStart > delayForCheck)
        {
            if (other.gameObject.layer != 6 && other.gameObject.layer != 7)
            {
                DestroyAfterTime(_DestroyTimer);
            }
        }
    }

    private void Start()
    {
        Movement();
    }
    private void Update()
    {
        if (timeStart == 0.0f)
        {
            timeStart = Time.time;
        }

        timerCounter += Time.deltaTime;
        CheckIfShouldBeDestroyed();

    }
    private void Movement()
    {
        _Rd.velocity = transform.up * _Speed;
    }
    private void DestroyAfterTime(float timer)
    {
        Invoke("DestroyNow", timer);
    }
    private void DestroyNow()
    {
        Destroy(gameObject);
    }
    private void CheckIfShouldBeDestroyed()
    {
        if (timerCounter - timeStart > _TimeForDestroy)
            DestroyAfterTime(_DestroyTimer);
    }
}
