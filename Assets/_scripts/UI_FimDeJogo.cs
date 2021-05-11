using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_FimDeJogo : MonoBehaviour
{
  GameManager gm;
  [SerializeField]
  private Text textComp;
  [SerializeField]
  private AudioSource victoryMusic, lossMusic;

  void Start() {
    gm = GameManager.GetInstance();
    
  }

  private void OnEnable()
  {
    if (textComp != null) {
      textComp.text = $"O mundo acabou! mas você salvou {gm.pontos} bolas!";
      if (gm.pontos <= 2) {
        lossMusic.Play();
      } else {
        victoryMusic.Play();
      }
    }
    
  }
 
  public void TryAgain()
  {
      gm.ChangeState(GameManager.GameState.MENU);
  }
}