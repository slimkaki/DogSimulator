using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_MenuPrincipal : MonoBehaviour {
    GameManager gm;

  private void OnEnable()
  {
      gm = GameManager.GetInstance();
      
  }
 
  public void Comecar()
  {
      if (gm.firstPlay) {
        gm.ChangeState(GameManager.GameState.TUTORIAL);
      } else {
        gm.ChangeState(GameManager.GameState.GAME);
      }
  }

  public void Configs() {
      gm.ChangeState(GameManager.GameState.CONFIGS);
  }
}