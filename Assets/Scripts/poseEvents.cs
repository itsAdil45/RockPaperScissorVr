using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poseEvents : MonoBehaviour
{ 
    public GameObject rockPose;
    public GameObject ScissorPose;
    public GameObject PaperPose;
    public GameObject errorMsg;
    public Animator m_Animator;

    void Start(){
    }
    void Update()
    { 
        if(poseManager.instance.isPlayerSelectPose ){
            print("playerSelectedPose");
         gameObject.SetActive(false);
         poseManager.instance.isPlayerSelectPose=false;
        }
        if(gameObject.activeSelf){
            TimerScript.instance.turntimer -= Time.deltaTime;
            if (TimerScript.instance.turntimer <= 0)
            {    print("timeEnded");
                m_Animator.SetBool("handMovement", false);
                m_Animator.SetBool("paper", false);
                m_Animator.SetBool("rock", false);
                m_Animator.SetBool("scissor", false);
                gameObject.SetActive(false);
                errorMsg.SetActive(true);
            }
        }
   
    }

    public void OnTriggerStay(Collider other){
        if(other.gameObject.tag=="RightHand" ){
               rockPose.SetActive(true);
               ScissorPose.SetActive(true);
               PaperPose.SetActive(true);
              
        }

    }

    public void OnTriggerExit(Collider other){
        if(other.gameObject.tag=="RightHand" ){
               rockPose.SetActive(false);
               ScissorPose.SetActive(false);
               PaperPose.SetActive(false);

              
        }

    }



}
