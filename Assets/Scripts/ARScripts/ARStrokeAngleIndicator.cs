using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARStrokeAngleIndicator : MonoBehaviour
{
    private PhotonView PV;

    ARStrokeManager ARStrokeManager;
    Transform PlayerBallTransform;

    void Start()
    {
        PV = GetComponent<PhotonView>();
        ARStrokeManager = GameObject.FindObjectOfType<ARStrokeManager>();
        PlayerBallTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if(PV.IsMine)
        {
            this.transform.position = PlayerBallTransform.position;
            this.transform.rotation = Quaternion.Euler(0, ARStrokeManager.StrokeAngle, 0);
        }
    }
}
