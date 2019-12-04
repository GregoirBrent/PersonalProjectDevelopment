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
        //Ball.GetComponent<LayerMask>();
        Ball.gameObject.layer = LayerMask.NameToLayer("Default");
        Ball.GetComponent<SetPosition>().RespawnBall();

    }
}