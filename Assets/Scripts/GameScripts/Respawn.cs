using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{

    [SerializeField]private Transform Ball;

    SpawnPoint SpawnPoint;

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
