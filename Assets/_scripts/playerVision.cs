using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerVision : MonoBehaviour {

    public float mouseSense = 100f;
    public Transform playerBody;
    GameManager gm;

    float xRotation = 0f;
    void Start(){
        // Cursor.lockState = CursorLockMode.Locked;
        gm = GameManager.GetInstance();
    }
    void Update(){
        if(gm.gameState != GameManager.GameState.GAME) return;
            if(Input.GetKeyDown(KeyCode.Escape) && gm.gameState == GameManager.GameState.GAME) {
                gm.ChangeState(GameManager.GameState.PAUSE);
            }
    
        float mouseX = Input.GetAxis("Mouse X") * mouseSense * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSense * Time.deltaTime;

        xRotation -=mouseY;

        xRotation = Mathf.Clamp(xRotation, -90.0f, 90.0f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);
    }
}