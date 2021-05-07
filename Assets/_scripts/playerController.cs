﻿// Utilizamos o tutorial 'How to make Terrain in Unity!': https://www.youtube.com/watch?v=MWQv2Bagwgk
// Utilizamos o tutorial 'FIRST PERSON MOVEMENT in Unity - FPS Controller': https://youtu.be/_QajrabyTJc
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

    public CharacterController controller;
    private float speed = 15f;
    private float gravity =-9.81f*2;
    
    
    private Vector3 velocity;
    private float jumpHeight = 3f;
    public bool canGrab;

    private GameObject bola, mouth;

    [SerializeField]
    public AudioSource walkSound, barkSound;

    GameManager gm;
    private float ultimaVezQueTocouOAudio;

    void Start(){
        gm = GameManager.GetInstance();
        mouth = GameObject.FindWithTag("DogMouth");
        GameObject.FindWithTag("Objective").GetComponent<MeshRenderer>().enabled = false;
        ultimaVezQueTocouOAudio = Time.time;
        // walkSound.GetComponent<AudioSource>
    }

    void Update(){
        bool grounded = controller.isGrounded;
        if(gm.gameState != GameManager.GameState.GAME) return;
            if(Input.GetKeyDown(KeyCode.Escape) && gm.gameState == GameManager.GameState.GAME) {
                bola.GetComponent<Rigidbody>().useGravity = false;
                gm.ChangeState(GameManager.GameState.PAUSE);
            }

        if (grounded && velocity.y < 0) {
            velocity.y = 0f;
        }


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if ((x != 0 || z != 0) && (Time.time - ultimaVezQueTocouOAudio) > 0.5f)  {
            // Debug.Log("Som de andar");
            walkSound.Play();
            ultimaVezQueTocouOAudio = Time.time;
        }

        Vector3 direction = transform.right * x + transform.forward * z;

        if (Input.GetButton("Fire3")) {
            speed = 30f;
        } else {
            speed = 15f;
        }

        controller.Move(direction * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && grounded) { 
            velocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravity);
        }
        
        velocity.y += gravity * Time.deltaTime;
      
        controller.Move(velocity * Time.deltaTime);

        bola = GameObject.FindWithTag("BallBody");

        if (Input.GetButton("Fire1") && canGrab) {
            bola.GetComponent<Rigidbody>().useGravity = false;
            bola.transform.position = mouth.transform.position;
            
            GameObject.FindWithTag("Objective").GetComponent<MeshRenderer>().enabled = true;
        } else if (bola != null) {
            bola.GetComponent<Rigidbody>().useGravity = true;
            GameObject.FindWithTag("Objective").GetComponent<MeshRenderer>().enabled = false;
            
        }

        if (Input.GetKey(KeyCode.Mouse1)) {
            barkSound.Play();
        }
    }
} 

