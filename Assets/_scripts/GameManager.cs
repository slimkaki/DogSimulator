using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager 
{
   private static GameManager _instance;
   public enum GameState { MENU, GAME, PAUSE, CONFIGS, ENDGAME };

   public GameState gameState { get; private set; }
   public int pontos;

   public float totalTime = 120f;
   public float beginTime, time, pauseInitialTime, pauseTime;
   public bool cameFromPause;

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

       if(gameState == GameState.MENU && nextState == GameState.GAME) { beginTime = Time.time ; }

        if(gameState == GameState.PAUSE && nextState == GameState.MENU) {
            GameObject.FindWithTag("Player").transform.position = new Vector3(200f, 20f, 200f);   
        }

        if (gameState == GameState.GAME && nextState == GameState.PAUSE) {
            pauseInitialTime = Time.time;
        }

        if (gameState == GameState.PAUSE && nextState == GameState.GAME) {
            pauseTime = Time.time - pauseInitialTime;  
        }


        if (gameState == GameState.ENDGAME && nextState == GameState.MENU) {
            GameObject.FindWithTag("Player").transform.position = new Vector3(200f, 20f, 200f);
            
        }
        
        gameState = nextState;
        
        changeStateDelegate();
        
    }

    private void Reset() {
        pontos = 0;
    }

}