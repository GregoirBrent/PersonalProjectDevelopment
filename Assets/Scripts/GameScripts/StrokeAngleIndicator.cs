using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrokeAngleIndicator : MonoBehaviour
{
    StrokeManager StrokeManager;
    Transform PlayerBallTransform;

    void Start()
    {
        StrokeManager = GameObject.FindObjectOfType<StrokeManager>();
        PlayerBallTransform = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    void Update()
    {
        this.transform.position = PlayerBallTransform.position;
        this.transform.rotation = Quaternion.Euler(0, StrokeManager.StrokeAngle, 0);
    }
}
