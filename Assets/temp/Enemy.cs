using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class Enemy : Agent
{
//  public override void OnActionReceived(ActionBuffers actions){
//     print(actions.DiscreteActions[0]);
//  }

 public override void CollectObservations (VectorSensor sensor) {
sensor. AddObservation(PlayerScript.instance.playerTurn);
}

public override void OnActionReceived(ActionBuffers actions) {
Debug. Log (actions.ContinuousActions [0]);}

    // Update is called once per frame
    void Update()
    {
        
    }
}
