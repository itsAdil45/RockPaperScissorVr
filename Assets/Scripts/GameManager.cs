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
    public GameObject player;
    public GameObject aiAgent;
    public GameObject greenShere;

    public GameObject yellowShere;


    void Awake(){
        GameManagerInstance = this;
    }
    void Update()
    {
        if(aiAgent.activeSelf){

       
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
    }


    public void RestartGame(){
        // int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        // SceneManager.LoadScene(currentSceneIndex);
        poseManager.instance.isPlayerSelectPose=false;
        poseManager.instance.isPlayerinField = false;
        poseManager.instance.allowTimerToStart=true;
        poseManager.instance.isPlayerThumbsUpInField =false;
        poseManager.instance.PlayerChoice=-1;
        ResetValues();
        ResetBtn.SetActive(false);
        TurnSpheres.SetActive(true);
        yellowShere.SetActive(true);
        greenShere.SetActive(false);

        

    }

    public void ResetValues(){
        status.text="Thumbs Up";
        RockPaperScissorsAgent.rockPaperScissorsAgentInstance.playerScore.text="0";
        RockPaperScissorsAgent.rockPaperScissorsAgentInstance.Player_Choice_text.text="";
        RockPaperScissorsAgent.rockPaperScissorsAgentInstance.AI_Score.text="0";
        RockPaperScissorsAgent.rockPaperScissorsAgentInstance.AI_Choice_text.text="";
        RockPaperScissorsAgent.rockPaperScissorsAgentInstance.aiscore=0;
        RockPaperScissorsAgent.rockPaperScissorsAgentInstance.playerscore=0;
        RockPaperScissorsAgent.rockPaperScissorsAgentInstance.Tie.text="";
    }
    public void PlayBtn(){
        // playingAssets.SetActive(true);
        RestartGame();
        aiAgent.SetActive(true);
        player.GetComponent<SimpleCapsuleWithStickMovement>().enabled = false;

    }

    public void MoveBtn(){
    // playingAssets.SetActive(false);
        TurnSpheres.SetActive(false);
        aiAgent.SetActive(false);
        ResetValues();
        player.GetComponent<SimpleCapsuleWithStickMovement>().enabled = true;

    }
}
