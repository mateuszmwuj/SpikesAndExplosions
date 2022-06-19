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
    public int right = 1;
    public Animator Animator;

    private string ENEMY_MOVE_BOOL = "move";
    private string ENEMY_IDLE_TRIGGER = "idle";
    private string ENEMY_JUMP_TRIGGER = "jump";


    void Start()
    {

        _rb = GetComponent<Rigidbody2D>();
        Animator.SetTrigger(ENEMY_IDLE_TRIGGER);
    }

    void Update()
    {
        if (playerClose == true) {
            _rb.velocity = new Vector2(-enemySpeed * right, _rb.velocity.y);
            Animator.SetBool(ENEMY_MOVE_BOOL, true);
        }
       
    }

    private void OnTriggerEnter2D(Collider2D collider2D) {
        if(collider2D.gameObject.layer == 6 || collider2D.gameObject.layer == 7) {
            playerClose = true;
            moveTriger.enabled = false;
        }
    }

    public void Jump() {
        _rb.velocity = new Vector2(_rb.velocity.x * right, jumpForce);
        Animator.SetTrigger(ENEMY_JUMP_TRIGGER);
    }

}
