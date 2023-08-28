using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public static PlayerScript instance;
    public int playerTurn;
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
  
    void Update()
    {
        if (Input.GetKeyDown("a"))
        {
            playerTurn=0;
            // Debug.Log("a key was pressed");
        }
        
        if (Input.GetKeyDown("s"))
        {
            playerTurn=1;
            // Debug.Log("S key was pressed");
        }       
        
        if (Input.GetKeyDown("d"))
        {
            playerTurn=2;
            // Debug.Log("D key was pressed");
        }
    }
    
}
