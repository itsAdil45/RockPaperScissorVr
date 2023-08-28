using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;
using TMPro;

public class RockPaperScissorsAgent : Agent
{
    public static RockPaperScissorsAgent rockPaperScissorsAgentInstance;
    public TMPro.TextMeshPro playerScore;
    public TMPro.TextMeshPro AI_Score;
    public TMPro.TextMeshPro AI_Choice_text;
    public TMPro.TextMeshPro Player_Choice_text;
    public TMPro.TextMeshPro Tie;
    public Animator m_Animator;
   public int playerscore;
   public int aiscore;
    public enum Choice { Rock, Paper, Scissors }
    public Choice playerChoice; // Updated by player input

    private Choice opponentChoice;

    public int AI_Choice;
    
    void Start(){
        rockPaperScissorsAgentInstance = this;
    }
    public override void OnEpisodeBegin()
    {
        AI_Choice =-1;
        poseManager.instance.PlayerChoice=-1;
        TimerScript.instance.isPlayerReady= false; 
        poseManager.instance.isPlayerMadeChoice = false;
        AI_Choice = Random.Range(0, 3);




    }

    public override void CollectObservations(VectorSensor sensor)
    {

        
        sensor.AddObservation(AI_Choice); // One-hot encode opponent choice
        sensor.AddObservation(poseManager.instance.PlayerChoice);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {

    if(TimerScript.instance.isPlayerReady && poseManager.instance.isPlayerMadeChoice){

        Tie.text="";

        if(poseManager.instance.PlayerChoice==actions.DiscreteActions[0] ){
        print("Both Selected Same");

        AI_Choice_text.text="";
        Player_Choice_text.text = "";
        if(actions.DiscreteActions[0] ==0){
        m_Animator.SetBool("handMovement", false);
        m_Animator.SetBool("rock", true);
        }
        if(actions.DiscreteActions[0] ==1){
                m_Animator.SetBool("handMovement", false);

        m_Animator.SetBool("paper", true);
        }
        if(actions.DiscreteActions[0] ==2){
        m_Animator.SetBool("handMovement", false);

        m_Animator.SetBool("scissor", true);
        }

        Tie.text="Tie";
        AddReward(0.1f);
        EndEpisode();
        }
// ++++++++++++++++++++++++++++++ Win Cases++++++++++++++++++++++++++++++
                                        //rock     //paper                      
        if(poseManager.instance.PlayerChoice==0 &&actions.DiscreteActions[0]==1 ){
        print("Player selected rock you selected paper, paper wraps rock you win");
        AI_Choice_text.text="paper";
        Player_Choice_text.text = "Rock";
        m_Animator.SetBool("handMovement", false);
        m_Animator.SetBool("paper", true);
        aiscore =aiscore+1;
        AI_Score.text = aiscore.ToString();
        AddReward(1f);
        EndEpisode();
        }
                                        //paper    //scissor
        else if(poseManager.instance.PlayerChoice==1 &&actions.DiscreteActions[0]==2 ){
        print("Player selected paper you selected Scissor Scissor cuts paper You Win");
        AI_Choice_text.text="scissor";
        Player_Choice_text.text = "paper";
        m_Animator.SetBool("handMovement", false);
        aiscore =aiscore+1;
        m_Animator.SetBool("scissor", true);
        AI_Score.text = aiscore.ToString();
        AddReward(1f);
        EndEpisode();
        }
  
                                     //scissor     //rock 
        else if(poseManager.instance.PlayerChoice==2 &&actions.DiscreteActions[0]==0 ){
        print("Player selected scissor you selected rock rock break scissor You Win");
        AI_Choice_text.text="rock";
        Player_Choice_text.text = "scissor";
        m_Animator.SetBool("handMovement", false);
        aiscore =aiscore+1;
        m_Animator.SetBool("rock", true);
        AI_Score.text = aiscore.ToString();
        AddReward(1f);
        EndEpisode();
        }
        
//+++++++++++++++++++++++++++++++++++Lose Cases+++++++++++++++++++++++++++++++++++++++++++++++
                                     //paper     // rock
        else if(poseManager.instance.PlayerChoice==1 &&actions.DiscreteActions[0]==0 ){
        print("Player selected paper you selected rock paper wraps rock you lose");
        AI_Choice_text.text="rock";
        m_Animator.SetBool("handMovement", false);
        m_Animator.SetBool("rock", true);
        Player_Choice_text.text = "paper";
        playerscore =playerscore+1;
        playerScore.text = playerscore.ToString();
        AddReward(-1f);
        EndEpisode();
        }
                                        //scissor    //paper
        else if(poseManager.instance.PlayerChoice==2 &&actions.DiscreteActions[0]==1 ){
        print("Player selected scissor you selected paper Scissor cuts paper You lose");
        AI_Choice_text.text="paper";
        Player_Choice_text.text = "scissor";
        m_Animator.SetBool("handMovement", false);

        m_Animator.SetBool("paper", true);

        playerscore =playerscore+1;
        playerScore.text = playerscore.ToString();
        AddReward(-1f);
        EndEpisode();
        }

                                             //rock     //scissor 
        else if(poseManager.instance.PlayerChoice==0 &&actions.DiscreteActions[0]==2 ){

        print("Player selected rock you selected scissor rock break scissor You lose");
        AI_Choice_text.text="scissor";
        Player_Choice_text.text = "rock";
        m_Animator.SetBool("handMovement", false);
        m_Animator.SetBool("scissor", true);
        playerscore =playerscore+1;
        playerScore.text = playerscore.ToString();
        AddReward(-1f);
        EndEpisode();
        }


    }

    }


}
