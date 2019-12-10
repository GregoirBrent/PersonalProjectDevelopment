using UnityEngine;
using System.Collections;

public class ARScoringCollider : MonoBehaviour
{
    //LevelManager LevelManager;
    Ball Ball;
    //ARStrokeManager ARStrokeManager;
    //ScoreWindow ScoreWindow;

    void Start()
    {
        //ScoreWindow = GameObject.FindObjectOfType<ScoreWindow>();
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("BALL IN HOLE! NICE DONE!!!");

        //ScoreWindow.ActiveScoreboard();

        Ball = GameObject.FindObjectOfType<Ball>();
        Ball.gameObject.layer = LayerMask.NameToLayer("Default");

        Rigidbody BallRB = Ball.GetComponent<Rigidbody>();
        BallRB.angularVelocity = Vector3.zero;
        BallRB.velocity = Vector3.zero;

        //LevelManager = GameObject.FindObjectOfType<LevelManager>();
        //LevelManager.LevelComplete();

        //ARStrokeManager = GameObject.FindObjectOfType<ARStrokeManager>();
        //ARStrokeManager.ResetScore();

    }
}
