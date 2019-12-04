using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{

    public Transform spawnPoint;
    Ball Ball;



    //void Awake()
    //{
   
    //    this.transform.position = new Vector3(spawnPoint.position.x, spawnPoint.position.y, spawnPoint.position.y);
    //}



    void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        Ball = GameObject.FindObjectOfType<Ball>();
        Ball.transform.position = spawnPoint.transform.position;
    }

}
