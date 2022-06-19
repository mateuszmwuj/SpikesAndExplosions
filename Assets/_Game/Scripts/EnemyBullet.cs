using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet
{
    [SerializeField] protected int _LayerToHit1;
    [SerializeField] protected int _LayerToHit2;
    private void OnTriggerEnter2D(Collider2D other)
    {
        //explosion
        if (timeStart - timerCounter > delayForCheck)
        {
            Debug.Log($"[Bullet] other.gameObject.layer: {other.gameObject.layer}");

            if (other.gameObject.layer == _LayerToHit1 || other.gameObject.layer == _LayerToHit2)
            {
                DestroyAfterTime(_DestroyTimer);
            }
        }
    }

}
