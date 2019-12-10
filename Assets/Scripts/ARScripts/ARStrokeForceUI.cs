using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ARStrokeForceUI : MonoBehaviour
{
    void Start()
    {
        ARStrokeManager = GameObject.FindObjectOfType<ARStrokeManager>();
        image = GetComponent<Image>();
    }

    ARStrokeManager ARStrokeManager;
    Image image;

    // Update is called once per frame
    void Update()
    {
        image.fillAmount = ARStrokeManager.StrokeForcePerc;
    }
}
