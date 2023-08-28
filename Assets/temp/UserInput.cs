using UnityEngine;
using UnityEngine.UI;

public class UserInput : MonoBehaviour
{
    public int PlayerChoice;
    public bool isPlayerReady =false;
    public bool isPlayerMadeChoice = false;
    public static UserInput instance;

    private void Start()
    {
        instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            isPlayerReady = true;
            
        }

        if (Input.GetKeyDown("a"))
        {
            PlayerChoice=0;
            isPlayerMadeChoice = true;
            // Debug.Log("a key was pressed");
        }
        
        if (Input.GetKeyDown("s"))
        {
            PlayerChoice=1;
            isPlayerMadeChoice = true;
            // Debug.Log("S key was pressed");
        }       
        
        if (Input.GetKeyDown("d"))
        {
            PlayerChoice=2;
            isPlayerMadeChoice = true;
            // Debug.Log("D key was pressed");
        }
    }
    

}
