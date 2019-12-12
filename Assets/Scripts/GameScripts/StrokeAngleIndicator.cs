using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrokeAngleIndicator : MonoBehaviour
{
    //StrokeManager StrokeManager;
    StrokeBallManager StrokeBallManager;
    Transform PlayerBallTransform;

    void Start()
    {
        //StrokeManager = GameObject.FindObjectOfType<StrokeManager>();
        StrokeBallManager = GameObject.FindObjectOfType<StrokeBallManager>();
        PlayerBallTransform = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    void Update()
    {
        this.transform.position = PlayerBallTransform.position;
        //this.transform.rotation = Quaternion.Euler(0, StrokeManager.StrokeAngle, 0);
        this.transform.rotation = Quaternion.Euler(0, StrokeBallManager.StrokeAngle, 0);
    }
}
