using System.Collections;
using Oculus.Interaction;
using System.Collections.Generic;
using UnityEngine;

public class poseManager : MonoBehaviour
{
   
    public static poseManager instance;
    public List<ActiveStateSelector> poses;
    public TMPro.TextMeshPro poseName;
    public TMPro.TextMeshPro timerText;
    private float timer = 5.0f;
    public GameObject rockPose;
    public GameObject ScissorPose;
    public GameObject PaperPose;
    public GameObject thumbsUp;
    public GameObject poseEvents;
    public GameObject turnStartArea;
    public bool allowTimerToStart =true;
    private bool isTiming = false;
    public bool isPlayerinField = false;
    public bool isPlayerThumbsUpInField = false;
    public bool isPlayerSelectPose= false;
    public bool isPlayerSelectWrongPose = false;
    public int PlayerChoice;
    public bool isPlayerMadeChoice = false;


    void Awake(){
        instance = this;
    }


    void Start()
    {
        foreach(var item in poses)
        {
            item.WhenSelected +=()=>SetText(item.gameObject.name);

            item.WhenUnselected +=()=>SetText("");
        }
    }

    void Update()
    {
        if(!poseEvents.activeSelf)
        {

               rockPose.SetActive(false);
               ScissorPose.SetActive(false);
               PaperPose.SetActive(false);
        }

    }

    public void StartTimer()
    {
        timer = 5.0f; 
        isTiming = true;
    }


    public void SetText(string newtxt){
            if(newtxt!="ThumbsUpPose"){
                poseName.text = newtxt;
            }

            if(newtxt=="ThumbsUpPose" && allowTimerToStart){
                                  //Reseting Stats
                isPlayerThumbsUpInField = true;
                RockPaperScissorsAgent.rockPaperScissorsAgentInstance.playerScore.text="0";
                RockPaperScissorsAgent.rockPaperScissorsAgentInstance.Player_Choice_text.text="";
                RockPaperScissorsAgent.rockPaperScissorsAgentInstance.AI_Score.text="0";
                RockPaperScissorsAgent.rockPaperScissorsAgentInstance.AI_Choice_text.text="";
                RockPaperScissorsAgent.rockPaperScissorsAgentInstance.aiscore=0;
                RockPaperScissorsAgent.rockPaperScissorsAgentInstance.playerscore=0;
                RockPaperScissorsAgent.rockPaperScissorsAgentInstance.Tie.text="";
                ////////////////////////////////////////////////////////////////////
                isPlayerinField = true;
                timerText.text="";
                allowTimerToStart= false;
            }

      

            if(poseName.text=="RockRight"){
                PlayerChoice=0;
                isPlayerMadeChoice = true;
                isPlayerSelectPose = true;
                turnStartArea.SetActive(true);
                isPlayerinField = false;
            }

            else if(poseName.text=="PaperPose"){
                PlayerChoice=1;
                isPlayerMadeChoice = true;
                isPlayerSelectPose = true;
                turnStartArea.SetActive(true);
                isPlayerinField = false;
            }

           else if(poseName.text=="ScissorsPose"){
                PlayerChoice=2;
                isPlayerMadeChoice = true;
                isPlayerSelectPose = true;
                turnStartArea.SetActive(true);
                isPlayerinField = false;
            }
       
    }
}
