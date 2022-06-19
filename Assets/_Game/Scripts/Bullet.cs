using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D _Rd;
    [SerializeField] protected SpriteRenderer _SpriteRenderer;
    [SerializeField] protected float _DestroyTimer = 0.1f;
    [SerializeField] protected float _TimeForDestroy = 2f;
    [SerializeField] protected float _Speed;
    [SerializeField] protected int _LayerToIgnore1;
    [SerializeField] protected int _LayerToIgnore2;
    [SerializeField] protected GameObject _ParticlePrefab;
    protected float timerCounter = 0.0f;
    protected float timeStart = 0.0f;
    [SerializeField] protected float delayForCheck = 0.1f;
    protected void OnCollisionEnter2D(Collision2D other)
    {
        //explosion
        if (timeStart - timerCounter > delayForCheck)
        {
            Debug.Log($"[Bullet] other.gameObject.layer: {other.gameObject.layer}");

            if (other.gameObject.layer != _LayerToIgnore1 && other.gameObject.layer != _LayerToIgnore2)
            {
                if (_ParticlePrefab) 
                    Instantiate(_ParticlePrefab, transform.position, transform.rotation);
                    
                DestroyAfterTime(_DestroyTimer);
            }
        }
    }

    protected void Start()
    {
        Movement(); 
        
        timeStart = Time.time;
    }
    protected void FixedUpdate()
    {
        timerCounter += Time.deltaTime;
        CheckIfShouldBeDestroyed();
    }
    protected void Movement()
    {
        _Rd.velocity = transform.up * _Speed;
    }
    protected void DestroyAfterTime(float timer)
    {
        _SpriteRenderer.enabled = false;
        Invoke("DestroyNow", timer);
    }
    protected void DestroyNow()
    {
        Destroy(gameObject);
    }
    protected void CheckIfShouldBeDestroyed()
    {
        if (timerCounter - timeStart > _TimeForDestroy)
            DestroyAfterTime(_DestroyTimer);
    }
}
