using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_FimDeJogo : MonoBehaviour
{
  GameManager gm;
  private Text textComp;
  [SerializeField]
  private AudioSource victoryMusic, lossMusic;

  private void OnEnable()
  {
    gm = GameManager.GetInstance();
    textComp = GetComponent<Text>();
    textComp.text = $"O mundo acabou! mas você salvou {gm.pontos} bolas!";
    if (gm.pontos <= 2) {
      if (!gm.firstPlay)
        lossMusic.Play();
    } else {
        victoryMusic.Play();
    }
  
  }
 
  public void TryAgain()
  {
      gm.ChangeState(GameManager.GameState.MENU);
  }
}