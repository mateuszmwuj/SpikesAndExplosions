using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour {

    [SerializeField] private GameObject _Slug1;
    [SerializeField] private GameObject _Slug2;
    public CharacterController2D controller;
    public float runSpeed = 40f;
    public float horizontalMove = 0f;

    public bool jump = false;
    public bool isPlatform;
    public bool isGround = true;
    public int player = 0;
    public int playerLayer = 6;
    private bool jumpState = false;
    private Rigidbody2D _rb;

    public GameObject pointer;

    public float turnOffColliderIgnoreTimer = 0.2f;
    public float JumpTimerPlatformStopTimer = 0.1f;

    // Start is called before the first frame update
    void Start() {
        player = GetComponent<PlayerInput>().user.index;
        playerLayer += player;
        gameObject.layer = playerLayer;
        _rb = GetComponent<Rigidbody2D>();

        var isFirstPlayer = player == 0? true : false; 
        if (_Slug1) 
            _Slug1.SetActive(isFirstPlayer);
        if (_Slug2) 
            _Slug2.SetActive(!isFirstPlayer);
    }

    // Update is called once per frame
    void Update() {
    
            
    }

    void FixedUpdate() {
        controller.Move(horizontalMove * Time.fixedDeltaTime * runSpeed, false, jump);
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

    private IEnumerator JumpTimerPlatformStop(float timer) {
        jumpState = true;
        yield return new WaitForSeconds(timer);
        jumpState = false;

    }

    public void Jump(InputAction.CallbackContext context) {
        if (jumpState == false) {
            if (isPlatform || isGround) {
                jump = true;
                StartCoroutine(JumpTimerPlatformStop(JumpTimerPlatformStopTimer));
                Physics2D.IgnoreLayerCollision(playerLayer, 9, true);
                StartCoroutine(DontIgnorePlatformCollider(turnOffColliderIgnoreTimer));
            }
        }
    }

    public void Move(InputAction.CallbackContext context) {
   
        if (GetComponent<PlayerInput>().actions["Move"].IsPressed()) {
            horizontalMove = context.ReadValue<Vector2>().x;
        }else {
            horizontalMove = 0;
        }
    }

    public void JumpDown(InputAction.CallbackContext context) {
        if (isPlatform || isGround) {
            StartCoroutine(JumpTimerPlatformStop(JumpTimerPlatformStopTimer));
            Physics2D.IgnoreLayerCollision(playerLayer, 9, true);
            StartCoroutine(DontIgnorePlatformCollider(turnOffColliderIgnoreTimer));
        }
    }

    public void PressDown(InputAction.CallbackContext context) {

        if (GetComponent<PlayerInput>().actions["PressDown"].IsPressed()) {
            jumpState = true;
        }
        else {
            jumpState = false;
        }
    }

    public void PointerMove(InputAction.CallbackContext context) {
        if (GetComponent<PlayerInput>().actions["PointerMove"].IsPressed()){
            pointer.transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * Mathf.Rad2Deg, -Vector3.forward);
            var newAngleZ = Mathf.Round((pointer.transform.eulerAngles.z) / 45) * 45;
            pointer.transform.eulerAngles = new Vector3(pointer.transform.eulerAngles.x, pointer.transform.eulerAngles.y, newAngleZ);
        }else {

            pointer.transform.eulerAngles = new Vector3(pointer.transform.eulerAngles.x, pointer.transform.eulerAngles.y, -90*transform.localScale.x);
        }
 
    }

}
