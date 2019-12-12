using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrokeForceUI : MonoBehaviour
{
    void Start()
    {
        StrokeManager = GameObject.FindObjectOfType<StrokeManager>();
        //strokeBallManager = GameObject.Find("Ball");
        //Force = strokeBallManager.GetComponent<StrokeBallManager>();

        image = GetComponent<Image>();
    }

    StrokeManager StrokeManager;
    //GameObject strokeBallManager;
    //StrokeBallManager Force;

    Image image;

    // Update is called once per frame
    void Update()
    {
        //image.fillAmount = Force.StrokeForcePerc;
        image.fillAmount = StrokeManager.StrokeForcePerc;
    }
}
