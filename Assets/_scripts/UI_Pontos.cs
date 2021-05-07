using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Pontos : MonoBehaviour {

    GameManager gm;
    Text textComp;
    void Start() {
        gm = GameManager.GetInstance();
        textComp = GetComponent<Text>();
    }

    void Update() {
        if (gm.gameState != GameManager.GameState.PAUSE || gm.gameState != GameManager.GameState.GAME) textComp.enabled = false;
        if (gm.gameState != GameManager.GameState.GAME) return;

        textComp.enabled = true;
        
        textComp.text = $"Saved balls: {gm.pontos}";
    }
}
