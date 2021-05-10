using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaController : MonoBehaviour
{
    GameManager gm;
    void Start(){
        gm = GameManager.GetInstance();
    }

    void Update() {
        if (gm.gameState != GameManager.GameState.GAME) return;
        if (this.transform.position.y < -5f) Destroy(gameObject);


    }

    private void OnTriggerEnter(Collider col) {
        if (col.tag == "Objective" && gm.playerIsGrabbing) {
            gm.pontos++;
            GameObject.FindWithTag("Player").GetComponent<playerController>().canGrab = false;
            Destroy(gameObject);
        }
    }
}
