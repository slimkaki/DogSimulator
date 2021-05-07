using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerVision : MonoBehaviour {

    public float mouseSense = 100f;
    public Transform playerBody;
    [SerializeField]
    // public GameObject player;
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
    // void LateUpdate() {
    //     RaycastHit hit;
    //     Debug.DrawRay(playerBody.position, transform.forward*10.0f, Color.magenta);

    //     if(Physics.Raycast(GetComponent<Camera>().ScreenPointToRay(Input.mousePosition), out hit, 100.0f)) {
    //         Debug.Log($"Achei o {hit.collider.tag}");
    //         Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
    //         if (hit.collider.tag == "Ball") {
    //             Debug.Log("achei a bola");
    //         }
    //         if (hit.collider.tag == "Ball" && Input.GetKeyDown(KeyCode.E)) {
    //             Debug.Log("Tentando pegar a bola");
    //         }
    //     }
    // } 
}