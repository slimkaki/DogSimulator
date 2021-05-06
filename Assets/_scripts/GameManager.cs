using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager 
{
   private static GameManager _instance;
   public enum GameState { MENU, GAME, PAUSE, CONFIGS, ENDGAME };

   public GameState gameState { get; private set; }
   public int pontos;

   public static GameManager GetInstance()
   {
       if(_instance == null)
       {
           _instance = new GameManager();
       }

       return _instance;
   }
   private GameManager()
   {
        pontos = 0;
        gameState = GameState.MENU; 
   }
    public delegate void ChangeStateDelegate();

    public static ChangeStateDelegate changeStateDelegate;

    public void ChangeState(GameState nextState)
    {

       if (nextState == GameState.MENU) Reset();
        
        if(gameState == GameState.PAUSE && nextState == GameState.MENU){
            GameObject.FindWithTag("Player").transform.position = new Vector3(0f, 0f, 0f);;
            
        }
        if(gameState == GameState.ENDGAME && nextState == GameState.MENU){
            GameObject.FindWithTag("Player").transform.position = new Vector3(0f, 0f, 0f);
            
        }
        
        gameState = nextState;
        
        changeStateDelegate();
        
    }

    private void Reset() {
        pontos = 0;
    }
}