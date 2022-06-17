using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSide : MonoBehaviour
{
    [SerializeField] private Rigidbody _Rigidbody;
    [SerializeField] private float _speed = 10;
    [SerializeField] private Vector3 _jumpVector = new Vector3(0,1,0);
    [SerializeField] private float _force = 10;

    [SerializeField] private float buttonTime = 0.3f;
    [SerializeField] private float jumpAmount = 20;
    private float jumpTime;
    private bool jumping;

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");

        gameObject.transform.position = new Vector3(transform.position.x + (h * _speed * Time.deltaTime),
            transform.position.y, transform.position.z);

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            jumping = true;
            jumpTime = 0;
        }
        if(jumping)
        {
            _Rigidbody.velocity = new Vector2(_Rigidbody.velocity.x, jumpAmount);
            jumpTime += Time.deltaTime;
        }
        if(Input.GetKeyUp(KeyCode.Space) | jumpTime > buttonTime)
        {
            jumping = false;
        }
    }
}
