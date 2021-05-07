using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Configs : MonoBehaviour
{
  GameManager gm;

  private void OnEnable()
  {
      gm = GameManager.GetInstance();
  }
 
  public void Back()
  {
    if (gm.cameFromPause) {
      gm.cameFromPause = false;
      gm.ChangeState(GameManager.GameState.PAUSE);
    } else {
      gm.ChangeState(GameManager.GameState.MENU);
    }
  }

}