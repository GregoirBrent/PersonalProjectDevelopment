using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ARStrokeCountUI : MonoBehaviour
{
    void Start()
    {
        ARStrokeManager = GameObject.FindObjectOfType<ARStrokeManager>();

    }

    ARStrokeManager ARStrokeManager;

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = "STROKE: " + ARStrokeManager.StrokeCount;
    }
}
