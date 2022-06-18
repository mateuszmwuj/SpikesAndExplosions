using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public CharacterController2D controller;
    public float runSpeed = 40f;
    public float horizontalMove = 0f;

    public bool jump = false;
    public bool isPlatform;

    public float turnOffColliderIgnoreTimer = 0.2f;
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump")){
            jump = true;
            Physics2D.IgnoreLayerCollision(7, 9, true);

            StartCoroutine(DontIgnorePlatformCollider(turnOffColliderIgnoreTimer));
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && isPlatform == true) {
            Debug.Log("pip");
            Physics2D.IgnoreLayerCollision(7, 9, true);

            StartCoroutine(DontIgnorePlatformCollider(turnOffColliderIgnoreTimer));
        }
     

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
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9 && isPlatform) {
            isPlatform = false;
        }
    }
    
    private IEnumerator DontIgnorePlatformCollider(float timer) {
        yield return new WaitForSeconds(timer);
        Physics2D.IgnoreLayerCollision(7, 9, false);
    }
}
