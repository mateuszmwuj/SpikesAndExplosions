using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _DestroyTimer = 0.1f;
    [SerializeField] private float _TimeForDestroy = 2f;
    [SerializeField] private float _Speed;
    private float timerCounter = 0.0f;
    private float timeStart = 0.0f;
    private void OnCollisionEnter2D(Collision2D other)
    {
        //explosion
        DestroyAfterTime(_DestroyTimer);
    }

    private void Update()
    {
        if (timeStart == 0.0f)
        {
            timeStart = Time.time;
        }

        timerCounter += Time.deltaTime;
        CheckIfShouldBeDestroyed();
        
        Movement();
    }
    private void Movement()
    {
        transform.position += Vector3.forward * Time.deltaTime * _Speed;
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
        if (timerCounter - timeStart > _TimeForDestroy);
            DestroyAfterTime(_DestroyTimer);
    }
}
