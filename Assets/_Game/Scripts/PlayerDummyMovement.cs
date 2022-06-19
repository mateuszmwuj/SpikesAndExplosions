using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDummyMovement : MonoBehaviour
{
    [SerializeField] private Animator _Animator;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _speed;
    public int right = 1;
    public float distance;
    public bool moveNotJump = true;
    [SerializeField] private float _maxDistanceMovement = 2f ;
    private Vector3 _startPos;


    void Start()
    {
        _startPos = transform.position;
        if (moveNotJump)
            _Animator.SetBool("move", true);
        // _rb.velocity = new Vector2(-_speed * right, _rb.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        if(!moveNotJump)
            _Animator.SetTrigger("jump");

        _rb.velocity = new Vector2(_speed * right, _rb.velocity.y);
        distance = Vector3.Distance(_startPos, transform.position);
        if (transform.position.x - _startPos.x > _maxDistanceMovement)
        {
            right = -1;
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * -1, transform.localScale.y, transform.localScale.z);
        }
        else if (transform.position.x - _startPos.x < -2)
        {
            transform.localScale = new Vector3( Mathf.Abs(transform.localScale.x) , transform.localScale.y, transform.localScale.z);
            right = 1;
        }
    }
}
