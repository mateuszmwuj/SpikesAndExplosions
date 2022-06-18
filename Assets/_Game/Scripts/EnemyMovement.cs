using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    public float enemySpeed = 2f;
    public bool playerClose = false;
    public float jumpForce = 2f;
    public Collider2D moveTriger;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        if (playerClose == true) {
            _rb.velocity = new Vector2(-enemySpeed, _rb.velocity.y);
        }
       
    }

    private void OnTriggerEnter2D(Collider2D collider2D) {
        if(collider2D.gameObject.layer == 6 || collider2D.gameObject.layer == 7) {
            playerClose = true;
            moveTriger.enabled = false;
        }
    }

    public void Jump() {
        _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
    }

}
