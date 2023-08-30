using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject playingAssets;
    public GameObject player;

    void Start()
    {
        print("start");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayBtn(){
        // playingAssets.SetActive(true);
        player.GetComponent<SimpleCapsuleWithStickMovement>().enabled = false;

    }

    public void MoveBtn(){
    // playingAssets.SetActive(false);
    player.GetComponent<SimpleCapsuleWithStickMovement>().enabled = true;

    }
}
