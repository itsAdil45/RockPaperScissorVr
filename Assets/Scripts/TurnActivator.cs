using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnActivator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject turnPlaceDetector;
    void Start()
    {
    }


    // Update is called once per frame
    void Update()
    {
        
    }

      public  IEnumerator ExampleCoroutine()
    {
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        yield return new WaitForSeconds(3);
        turnPlaceDetector.SetActive(true);
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
}
