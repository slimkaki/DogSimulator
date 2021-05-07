using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_FimDeJogo : MonoBehaviour
{
  GameManager gm;
  Text textComp;

  void Start() {
    gm = GameManager.GetInstance();
    textComp = GetComponent<Text>();
  }

  private void OnEnable()
  {
    if (textComp != null) {
      textComp.text = $"The world ended, but you managed to save, at least, {gm.pontos} balls!";
    }
  }
 
  public void TryAgain()
  {
      gm.ChangeState(GameManager.GameState.MENU);
  }
}