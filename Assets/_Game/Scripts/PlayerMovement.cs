using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour {

    public CharacterController2D controller;
    public float runSpeed = 40f;
    public float horizontalMove = 0f;

    public bool jump = false;
    public bool isPlatform;
    public bool isGround = true;
    public int player = 0;
    public int playerLayer = 6;

    public float turnOffColliderIgnoreTimer = 0.2f;
    // Start is called before the first frame update
    void Start() {
        player = GetComponent<PlayerInput>().user.index;
        playerLayer += player;
        gameObject.layer = playerLayer;
    }

    // Update is called once per frame
    void Update() {
        
    }

    void FixedUpdate() {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {       
        if (collision.gameObject.layer == 9 && !isPlatform) { //check the int value in layer manager(User Defined starts at 8) 

            isPlatform = true;
        }

        if (collision.gameObject.layer == 8 && !isGround) { //check the int value in layer manager(User Defined starts at 8) 

            isGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9 && isPlatform) {
            isPlatform = false;
        }

        if (collision.gameObject.layer == 8 && isGround) {
            isGround = false;
        }
    }
    
    private IEnumerator DontIgnorePlatformCollider(float timer) {
        yield return new WaitForSeconds(timer);
        Physics2D.IgnoreLayerCollision(playerLayer, 9, false);
    }

    public void Jump(InputAction.CallbackContext context) {
        if (isPlatform || isGround) {
           jump = true;
            Physics2D.IgnoreLayerCollision(playerLayer, 9, true);
            StartCoroutine(DontIgnorePlatformCollider(turnOffColliderIgnoreTimer));
        }   
    }

    public void Move(InputAction.CallbackContext context) {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
    }

}
