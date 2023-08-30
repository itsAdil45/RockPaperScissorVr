using UnityEngine;

public class TimerScript : MonoBehaviour
{
    private float timer = 5.0f; // The initial timer value
    private bool isTiming = false;
    public GameObject turnPlaceDetector;    
    public GameObject placeHolder;    
    public Animator m_Animator;
    public TMPro.TextMeshPro timerText;
    public AudioSource counter;
    bool isButtonPressed = true;
    public float turntimer = 0.9f;
    public GameObject errorMsg;


    //attach this with button
    public bool isPlayerReady =false;

    public static TimerScript instance;
    void Start(){
        instance = this;
    }

    void Update()
    {
        if (isTiming )
        {
            timer -= Time.deltaTime; // Decrease the timer by the time passed since the last frame
            timerText.text = Mathf.Ceil(timer).ToString(); 
            if (timer <= 0)
            {
                timerText.text="";
                Debug.Log("Timer finished!");
                isTiming = false;
                turnPlaceDetector.SetActive(true);
                isButtonPressed = true;
            }
        }
    }

    public void StartTimer()
    {
        if(isButtonPressed && !turnPlaceDetector.activeSelf && !placeHolder.activeSelf){
        poseManager.instance.PlayerChoice=-1;
        poseManager.instance.isPlayerSelectPose=false;
        turntimer = 0.9f;
        errorMsg.SetActive(false);
        isPlayerReady = true;
        RockPaperScissorsAgent.rockPaperScissorsAgentInstance.AI_Choice_text.text="";
        RockPaperScissorsAgent.rockPaperScissorsAgentInstance.Player_Choice_text.text="";
        RockPaperScissorsAgent.rockPaperScissorsAgentInstance.Tie.text="";
        m_Animator.SetBool("rock", false);
        m_Animator.SetBool("paper", false);
        m_Animator.SetBool("scissor", false);

        m_Animator.SetBool("handMovement", true);
        poseManager.instance.poseName.text ="";
        timer = 3.0f; // Reset the timer to 5 seconds
        counter.Play();
        isTiming = true;
        isButtonPressed = false;
        }
        
    }
}
