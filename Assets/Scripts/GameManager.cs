using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager GameManagerInstance;
    public GameObject ScoreCanvas;
    public GameObject TurnSpheres;
    public GameObject ResetBtn;
    public TMPro.TextMeshPro status;
    public bool isGameOver = true;
    void Awake(){
        GameManagerInstance = this;
    }
    void Update()
    {
        if(RockPaperScissorsAgent.rockPaperScissorsAgentInstance.aiscore==3 && isGameOver ){
            //AI Wins Restart Game
        status.text="AI Wins";
        TurnSpheres.SetActive(false);
        ResetBtn.SetActive(true);
        isGameOver = false;
            
        }
        
        if(RockPaperScissorsAgent.rockPaperScissorsAgentInstance.playerscore==3 && isGameOver ){
            //AI Wins Restart Game
        status.text="You Win";
        TurnSpheres.SetActive(false);
        ResetBtn.SetActive(true);
        isGameOver = false;

        }   
        
    }


    public void RestartGame(){
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
