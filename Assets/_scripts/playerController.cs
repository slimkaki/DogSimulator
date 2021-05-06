using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerController : MonoBehaviour {

    public CharacterController controller;
    private float speed = 15f;
    private float gravity =-9.81f;

    public Transform groundCheck;
    private float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    private Vector3 velocity;

    private float jumpHeight = 3f;
    GameManager gm;

    void Start(){
        gm = GameManager.GetInstance();
    }

    void Update(){
        
        if(gm.gameState != GameManager.GameState.GAME) return;
            if(Input.GetKeyDown(KeyCode.Escape) && gm.gameState == GameManager.GameState.GAME) {
                gm.ChangeState(GameManager.GameState.PAUSE);
            }

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y <0){
            velocity.y = 0f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 direction = transform.right * x + transform.forward * z;
        controller.Move(direction * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            Debug.Log("pular");
            velocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}

