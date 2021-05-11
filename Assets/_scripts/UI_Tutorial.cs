using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Tutorial : MonoBehaviour {
    
    GameManager gm;
    private int parteDoTutorial;
    [SerializeField]
    private Image controles, ui_doge;
    [SerializeField]
    private Text contexto, historia;

    void Start() {
        gm = GameManager.GetInstance();
        parteDoTutorial = 1;
        contexto.enabled = false;
        controles.enabled = false;
        ui_doge.enabled = false;
    }

    public void ContinuarJogo() {
        gm.firstPlay = false;
        if (parteDoTutorial == 1) {
            // Mudar para controles
            historia.enabled = false;
            contexto.enabled = true;
            controles.enabled = true;
            parteDoTutorial++;
            return;
        } else if (parteDoTutorial == 2) {
            // Mudar para UI
            contexto.enabled = false;
            controles.enabled = false;
            ui_doge.enabled = true;
            parteDoTutorial++;
            return;
        }
        gm.ChangeState(GameManager.GameState.GAME);
    }
    
    void Update(){
    }
}
