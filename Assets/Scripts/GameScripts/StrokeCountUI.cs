using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrokeCountUI : MonoBehaviour
{

	void Start()
	{
        StrokeManager = GameObject.FindObjectOfType<StrokeManager>();
        //strokeBallManager = GameObject.Find("Ball");
        //Count = strokeBallManager.GetComponent<StrokeBallManager>();

    }

    StrokeManager StrokeManager;
    //GameObject strokeBallManager;
    //StrokeBallManager Count;

    // Update is called once per frame
    void Update()
	{
        GetComponent<Text>().text = "STROKE: " + StrokeManager.StrokeCount;
        //GetComponent<Text>().text = "STROKE: " + Count.StrokeCount;
    }
}
