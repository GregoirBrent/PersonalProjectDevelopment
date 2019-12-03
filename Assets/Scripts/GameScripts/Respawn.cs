using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{

    [SerializeField]private Transform Ball;
    [SerializeField] private Transform RespawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        Ball.transform.position = RespawnPoint.transform.position;

        //Get player rigidbody component
        Rigidbody BallRB = Ball.GetComponent<Rigidbody>();

        //zet angularVelocity en velocity to 0
        BallRB.angularVelocity = Vector3.zero;
        BallRB.velocity = Vector3.zero;

        //Debug.Log(ballRB.angularVelocity = Vector3.zero);
        //Debug.Log(ballRB.velocity = Vector3.zero);
    }
}
