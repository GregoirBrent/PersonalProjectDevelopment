using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringCollider : MonoBehaviour
{
    Ball Ball;
    //StrokeManager StrokeManager;
    ScoreWindow ScoreWindow;
    public GameObject UIElements;


    void Start()
    {
        ScoreWindow = GameObject.FindObjectOfType<ScoreWindow>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("BALL IN HOLE! NICE DONE!!!");


        if (other.gameObject.tag == "Player")
        {
            ScoreWindow.ActiveScoreboard();
            UIElements.SetActive(false);

            Ball = GameObject.FindObjectOfType<Ball>();
            Ball.gameObject.layer = LayerMask.NameToLayer("Default");

        }

        //Rigidbody BallRB = Ball.GetComponent<Rigidbody>();
        //BallRB.angularVelocity = Vector3.zero;
        //BallRB.velocity = Vector3.zero;

        //LevelManager = GameObject.FindObjectOfType<LevelManager>();
        //LevelManager.LevelComplete();

        //StrokeManager = GameObject.FindObjectOfType<StrokeManager>();
        //StrokeManager.ResetScore();

    }
}
