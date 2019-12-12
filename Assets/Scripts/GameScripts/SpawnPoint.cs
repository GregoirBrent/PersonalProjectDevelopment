using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPoint : MonoBehaviour
{

    public Transform spawnPoint;
    Ball Ball;

    //private PhotonView PV;

    //void Awake()
    //{
   
    //    this.transform.position = new Vector3(spawnPoint.position.x, spawnPoint.position.y, spawnPoint.position.y);
    //}



    void Start()
    {
        //PV = GetComponent<PhotonView>();
        Spawn();

    }

    public void Spawn()
    {
        
        Ball = GameObject.FindObjectOfType<Ball>();
        Ball.transform.position = spawnPoint.transform.position;
        
    }

}
