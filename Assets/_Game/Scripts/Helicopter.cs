using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour
{
    private Rigidbody2D _rb;
    public float heliSpeed;
    public bool playerClose = false;
    public Collider2D moveTriger;
    public GameObject boom;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (playerClose == true) {
            _rb.velocity = new Vector2(-heliSpeed, 0);
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collider2D) {
        
        

        if (collider2D.gameObject.layer == 6 || collider2D.gameObject.layer == 7) {
            playerClose = true;
            moveTriger.enabled = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.layer == 10) {
            Instantiate(boom, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
