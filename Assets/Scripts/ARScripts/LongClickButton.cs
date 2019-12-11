using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LongClickButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool pointerDown = false;
    private float pointerDownTimer;

    [SerializeField]
    private float requireHoldTime; //hoelang voor longpress triger effect

    [SerializeField]
    private Image pressColor;

    public UnityEvent onLongClick;

    ARStrokeManager ARStrokeManager;

    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
        pressColor.color = Color.red;
        Debug.Log("OnPointerDown");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Reset();
        Debug.Log("OnPointerUp");
    }

    private void Update()
    {
        if(pointerDown)
        {
            pointerDownTimer += Time.deltaTime;
            if(pointerDownTimer >= requireHoldTime)
            {
                if (onLongClick != null)
                {
                    onLongClick.Invoke();
                    pressColor.color = Color.green;
                    Debug.Log("LONGPRESS");
                }
            }
        }
    }

    private void Reset()
    {
        pointerDown = false;
        pointerDownTimer = 0;
        pressColor.color = Color.yellow;

        ARStrokeManager = GameObject.FindObjectOfType<ARStrokeManager>();
        ARStrokeManager.arRightIsPressed = false;
        ARStrokeManager.arLeftIsPressed = false;


    }
}
