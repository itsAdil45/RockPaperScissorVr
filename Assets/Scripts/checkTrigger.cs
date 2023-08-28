using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject thumbsUp;
    public GameObject turnPosePlace;
    public Animator m_Animator;


    public void OnTriggerStay(Collider other){
        if(other.gameObject.tag=="RightHand"){
            poseManager.instance.isPlayerinField = true;
            thumbsUp.SetActive(true);
            print("triggered");
        }

    }

    public void OnTriggerExit(Collider other){
        //if player has thumbs up in the yellow field
        if(other.gameObject.tag=="RightHand" && poseManager.instance.isPlayerinField && poseManager.instance.isPlayerThumbsUpInField){

                m_Animator.SetBool("handMovement", false);
                m_Animator.SetBool("paper", false);
                m_Animator.SetBool("rock", false);
                m_Animator.SetBool("scissor", false);
            turnPosePlace.SetActive(false);
             thumbsUp.SetActive(false);
            gameObject.SetActive(false);
        }
    }
    




}
