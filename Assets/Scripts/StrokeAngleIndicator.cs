using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrokeAngleIndicator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StrokeManager = GameObject.FindObjectOfType<StrokeManager>();
        PlayerBallTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    StrokeManager StrokeManager;
    Transform PlayerBallTransform;


    // Update is called once per frame
    void Update()
    {
        this.transform.position = PlayerBallTransform.position;
        this.transform.rotation = Quaternion.Euler(StrokeManager.XA, StrokeManager.StrokeAngle, StrokeManager.YA);
    }
}
