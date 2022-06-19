using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour
{
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _clip;
    private Rigidbody2D _rb;
    public float heliSpeed;
    public bool playerClose = false;
    public Collider2D moveTriger;
    public GameObject boom;
    [SerializeField] private SpriteRenderer _renderer;

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
            if(_source && _clip)
                _source.PlayOneShot(_clip);
            _renderer.enabled = false;
            Instantiate(boom, transform.position, transform.rotation);
            Destroy(gameObject,1f);
        }
    }
}
