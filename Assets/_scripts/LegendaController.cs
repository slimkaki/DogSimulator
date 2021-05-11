using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LegendaController : MonoBehaviour {

    GameManager gm;
    private Text textComp;
    private float lastLegenda, legendaOnScreen;
    private bool legendaSet;

    private string[] frases = {"Doge: so sky... such blue", "Doge: amaze", "Doge: so real","Doge: where is ball" , "Doge: many mountains","Doge: me like ball", "Doge: me save ball","Doge: me rescue ball",};
    void Start() {
        gm = GameManager.GetInstance();
        textComp = GetComponent<Text>();
        textComp.enabled = false;
        lastLegenda = Time.time;
        legendaSet = false;
    }
    void Update() {
        if(gm.gameState != GameManager.GameState.GAME) return;
        if (gm.latido) {
            textComp.enabled = false;
            textComp.text = "Doge: woof!!";
            textComp.enabled = true;
            legendaOnScreen = Time.time;
            legendaOnScreen = Time.time;
            gm.latido = false;
            return;
        }
        if ((Random.Range(0f,1f) > 0.15f) && (Time.time - lastLegenda > 5f) && !legendaSet && !gm.latido) {
            // Ativar legenda
            textComp.text = frases[Random.Range(0, frases.Length)];
            textComp.enabled = true;
            legendaOnScreen = Time.time;
            legendaSet = true;
        }
        
        if ((Time.time - legendaOnScreen > 5f) && legendaSet && !gm.latido) {
            lastLegenda = Time.time;
            textComp.enabled = false;
            legendaSet = false;
        }
    }
}
