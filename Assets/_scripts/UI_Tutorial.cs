using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Tutorial : MonoBehaviour {
    
    GameManager gm;
    void Start() {
        gm = GameManager.GetInstance();
    }

    public void ContinuarJogo() {
        gm.firstPlay = false;
        gm.ChangeState(GameManager.GameState.GAME);
    }
    
    void Update(){
    }
}
