using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringCollider : MonoBehaviour
{
    LevelManager LevelManager;
    Ball Ball;
    StrokeManager StrokeManager;
    //ScoreWindow ScoreWindow;

    void Start()
    {
 
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("BALL IN HOLE! NICE DONE!!!");
       
        Ball = GameObject.FindObjectOfType<Ball>();
        Ball.gameObject.layer = LayerMask.NameToLayer("Default");

        Rigidbody BallRB = Ball.GetComponent<Rigidbody>();
        //zet angularVelocity en velocity to 0
        BallRB.angularVelocity = Vector3.zero;
        BallRB.velocity = Vector3.zero;

        LevelManager = GameObject.FindObjectOfType<LevelManager>();
        LevelManager.LevelComplete();

        StrokeManager = GameObject.FindObjectOfType<StrokeManager>();
        StrokeManager.ResetScore();

        //ScoreWindow = GameObject.FindObjectOfType<ScoreWindow>();
        //ScoreWindow.activeScoreboard();
    }
}