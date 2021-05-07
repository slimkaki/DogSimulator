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
        tempoRestante = gm.totalTime;
    }
    void Update() {
        if (gm.gameState == GameManager.GameState.MENU || gm.gameState == GameManager.GameState.ENDGAME) {
            // No caso de o player sair do jogo e ir para menu ou endgame
            tempoRestante = gm.totalTime;
            textComp.enabled = false;
        }
        if (gm.gameState != GameManager.GameState.GAME) return;

        if (tempoRestante <= 0.01f) {
            // Caso o tempo restante seja menor ou igual a zero, jogo acaba
            gm.ChangeState(GameManager.GameState.ENDGAME);
            return;
        }
        
        textComp.enabled = true;

        if (Time.time - gm.time >= 0.1f) {
            // é um delta T
            // Tempo que passou = Tempo atual - tempo de inicio 
            gm.time = Time.time - gm.beginTime; // Calcula o tempo que se passou
        }

        // Tempo Restante = Tempo Total - tempo que se passou + tempo fora da tela jogo
        tempoRestante = gm.totalTime - gm.time + gm.pauseTime;

        // Escreve o tempo restante na tela
        textComp.text = $"Time Left: {tempoRestante.ToString("F1")} s";
    } 
}
