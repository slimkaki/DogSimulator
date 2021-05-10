using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_FimDeJogo : MonoBehaviour
{
  GameManager gm;
  Text textComp;
  [SerializeField]
  private AudioSource victoryMusic, lossMusic;

  void Start() {
    gm = GameManager.GetInstance();
    textComp = GetComponent<Text>();
  }

  private void OnEnable()
  {
     
    if (textComp != null) {
      textComp.text = $"The world ended, but you managed to save, at least, {gm.pontos} balls!";
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