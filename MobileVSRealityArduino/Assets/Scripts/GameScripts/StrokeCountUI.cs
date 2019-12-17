using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrokeCountUI : MonoBehaviour
{
    void Start()
    {
        StrokeManager = GameObject.FindObjectOfType<StrokeManager>();

    }

    StrokeManager StrokeManager;


    void Update()
    {
        GetComponent<Text>().text = "STROKE: " + StrokeManager.StrokeCount;
    }
}
