using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Pause : MonoBehaviour
{

  GameManager gm;

  private void OnEnable()
  {
      gm = GameManager.GetInstance();
  }
 
  public void Retornar()
  {
      gm.ChangeState(GameManager.GameState.GAME);
  }

  public void Inicio()
  {
      gm.ChangeState(GameManager.GameState.MENU);
  }

  public void GoToConfigs() {
      gm.cameFromPause = true;
      gm.ChangeState(GameManager.GameState.CONFIGS);

  }

}