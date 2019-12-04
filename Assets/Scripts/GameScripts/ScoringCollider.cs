using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringCollider : MonoBehaviour
{
    LevelManager LevelManager;
    Ball Ball;
  

    void Start()
    {
 
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("BALL IN HOLE! NICE DONE!!!");
        LevelManager = GameObject.FindObjectOfType<LevelManager>();
        LevelManager.LevelComplete();

        Ball = GameObject.FindObjectOfType<Ball>();
        Ball.gameObject.layer = LayerMask.NameToLayer("Default");
        Ball.GetComponent<SetPosition>().RespawnBall();

        //Rigidbody BallRB = Ball.GetComponent<Rigidbody>();
        ////zet angularVelocity en velocity to 0
        //BallRB.angularVelocity = Vector3.zero;
        //BallRB.velocity = Vector3.zero;

    }
}