using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playingArea : MonoBehaviour
{
    public GameObject hotSpot;
    public void OnTriggerEnter(Collider other){
        if(other.gameObject.tag=="Player" ){
            hotSpot.SetActive(false);

    }}

    public void OnTriggerExit(Collider other){
        if(other.gameObject.tag=="Player" ){
            hotSpot.SetActive(true);

    }}

    
}
