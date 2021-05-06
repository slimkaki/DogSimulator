// referencia de movimentacao: documentacao basica do unity, disponivel em:  https://docs.unity3d.com/ScriptReference/CharacterController.Move.html
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PULOFUNUNCIA : MonoBehaviour
{
    CharacterController characterController;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 200.0f;
    private float jumpHeight = 50.0f;
    private float gravityValue = -400f;
    //Referência usada para a câmera filha do jogador
    GameObject playerCamera;
    //Utilizada para poder travar a rotação no angulo que quisermos.
    float cameraRotation;
    GameManager gm;
    private void Start()
    {
       characterController = GetComponent<CharacterController>();
       playerCamera = GameObject.Find("Main Camera");
       cameraRotation = 0.0f;
       gm = GameManager.GetInstance();
    }

    void Update()
    {
        if(gm.gameState != GameManager.GameState.GAME) return;
        if(Input.GetKeyDown(KeyCode.Escape) && gm.gameState == GameManager.GameState.GAME) {
            gm.ChangeState(GameManager.GameState.PAUSE);
        }
        groundedPlayer = characterController.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        { 
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        characterController.Move(move * Time.deltaTime * playerSpeed);
        float mouse_dX = Input.GetAxis("Mouse X");
        float mouse_dY = Input.GetAxis("Mouse Y");
        //Tratando a rotação da câmera
        cameraRotation -= mouse_dY;
        Mathf.Clamp(cameraRotation, -75.0f, 75.0f);

        // if (move != Vector3.zero)
        // {
        //     gameObject.transform.forward = move;
        // }
        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        characterController.Move(playerVelocity * Time.deltaTime);
        
        transform.Rotate(Vector3.up, mouse_dX);
        playerCamera.transform.localRotation = Quaternion.Euler(cameraRotation, 0.0f, 0.0f);
    }

    void LateUpdate() {
        RaycastHit hit;
        Debug.DrawRay(playerCamera.transform.position, transform.forward*10.0f, Color.magenta);
        // if(Physics.Raycast(playerCamera.transform.position, transform.forward, out hit, 100.0f)) {
        //     // Debug.Log(hit.collider.name);
        // }
        if(Physics.Raycast(playerCamera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition), out hit, 100.0f)) {
            Debug.Log($"Achei o {hit.collider.name}");
        }
    }
}
//     float _baseSpeed = 500.0f;
    
//     private Vector3 velocity;

//     CharacterController characterController;
   
//     //Referência usada para a câmera filha do jogador
//     GameObject playerCamera;
//     //Utilizada para poder travar a rotação no angulo que quisermos.
//     float cameraRotation;
    
//     GameManager gm;
//     // private float playerSpeed = 200.0f;
//     private float jumpHeight = 50.0f;
//     float _gravidade =-9f;

//    void Start() {
//        characterController = GetComponent<CharacterController>();
//        playerCamera = GameObject.Find("Main Camera");
//        cameraRotation = 0.0f;
//        gm = GameManager.GetInstance();
//    }

//    void Update() {
//         if(gm.gameState != GameManager.GameState.GAME) return;
//         if(Input.GetKeyDown(KeyCode.Escape) && gm.gameState == GameManager.GameState.GAME) {
//             gm.ChangeState(GameManager.GameState.PAUSE);
//         }
//         float x = Input.GetAxis("Horizontal");
//         float z = Input.GetAxis("Vertical");
       
//         //Verificando se é preciso aplicar a gravidade
//         float y = 0;
//         if(!characterController.isGrounded){
//             y = _gravidade;
//         }

       
//         //Tratando movimentação do mouse
//         float mouse_dX = Input.GetAxis("Mouse X");
//         float mouse_dY = Input.GetAxis("Mouse Y");
//         //Tratando a rotação da câmera
//         cameraRotation -= mouse_dY;
//         Mathf.Clamp(cameraRotation, -75.0f, 75.0f);
       
//         Vector3 direction = transform.right * x + transform.up * y + transform.forward * z;
//         characterController.Move(direction * Time.deltaTime * _baseSpeed);

//         if (Input.GetKeyDown(KeyCode.Space) && characterController.isGrounded) {
//             Debug.Log("pular");
//             velocity.y += Mathf.Sqrt(jumpHeight * -3.0f * _gravidade);
//         }

//         velocity.y += _gravidade * Time.deltaTime;
        
//         characterController.Move(velocity  * Time.deltaTime);

//         transform.Rotate(Vector3.up, mouse_dX);

//         playerCamera.transform.localRotation = Quaternion.Euler(cameraRotation, 0.0f, 0.0f);
       
//     }


//     void LateUpdate() {
//         RaycastHit hit;
//         Debug.DrawRay(playerCamera.transform.position, transform.forward*10.0f, Color.magenta);
//         // if(Physics.Raycast(playerCamera.transform.position, transform.forward, out hit, 100.0f)) {
//         //     // Debug.Log(hit.collider.name);
//         // }
//         if(Physics.Raycast(playerCamera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition), out hit, 100.0f)) {
//             Debug.Log($"Achei o {hit.collider.name}");
//         }
//     }