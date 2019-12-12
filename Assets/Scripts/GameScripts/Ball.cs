using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    Rigidbody rb;
    //PhotonView PV;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.sleepThreshold = 0.5f; //Default is 0.005

        //PV = GetComponent<PhotonView>();
        //StrokeManager.FindObjectOfType<StrokeManager>();
    }




    // Update is called once per frame
    void FixedUpdate()
    {

    }
}
