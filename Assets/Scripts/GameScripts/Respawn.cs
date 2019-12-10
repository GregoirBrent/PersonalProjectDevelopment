using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{

    [SerializeField]private Transform Ball;

    SpawnPoint SpawnPoint;
    //float yOffset;

    // void Start()
    //{
        
    //    yOffset = Ball.transform.position.y - 50;
    //}

    //void Update()
    //{
    ////   if(yOffset < Ball.position.y)
    ////    {
    ////        Rigidbody BallRB = Ball.GetComponent<Rigidbody>();

    ////        //zet angularVelocity en velocity to 0
    ////        BallRB.angularVelocity = Vector3.zero;
    ////        BallRB.velocity = Vector3.zero;

    ////        SpawnPoint = GameObject.FindObjectOfType<SpawnPoint>();
    ////        SpawnPoint.Spawn();
    ////    } 
    ////}

    private void OnTriggerEnter(Collider other)
    {
        //Get player rigidbody component
        Rigidbody BallRB = Ball.GetComponent<Rigidbody>();

        //zet angularVelocity en velocity to 0
        BallRB.angularVelocity = Vector3.zero;
        BallRB.velocity = Vector3.zero;

        SpawnPoint = GameObject.FindObjectOfType<SpawnPoint>();
        SpawnPoint.Spawn();

    }
}
