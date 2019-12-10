using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARStrokeAngleIndicator : MonoBehaviour
{
    ARStrokeManager ARStrokeManager;
    Transform PlayerBallTransform;

    void Start()
    {
        ARStrokeManager = GameObject.FindObjectOfType<ARStrokeManager>();
        PlayerBallTransform = GameObject.FindGameObjectWithTag("Player").transform;

    }

    void Update()
    {
        this.transform.position = PlayerBallTransform.position;
        this.transform.rotation = Quaternion.Euler(0, ARStrokeManager.StrokeAngle, 0);
    }
}
