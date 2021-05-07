using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Tempo : MonoBehaviour {

    GameManager gm;
    Text textComp;
    private float tempoRestante;
    void Start() {
        textComp = GetComponent<Text>();
        gm = GameManager.GetInstance();
    }
    void Update() {
        if (gm.gameState != GameManager.GameState.PAUSE || gm.gameState != GameManager.GameState.GAME) textComp.enabled = false;
        if (gm.gameState != GameManager.GameState.GAME) return;
        
        textComp.enabled = true;
        
        if (Time.time - gm.time >= 0.1f) {
            gm.time = Time.time - gm.beginTime;
        }
        tempoRestante = gm.totalTime - gm.time + gm.pauseTime;
        textComp.text = $"Time Left: {tempoRestante.ToString("F1")} s";
    }
}
