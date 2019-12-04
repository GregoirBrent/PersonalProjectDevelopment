using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPosition : MonoBehaviour
{

    Vector3 StartPoint;


    // Start is called before the first frame update
    void Start()
    {
        StartPoint = transform.position;

    }

    public void RespawnBall()
    {
        Debug.Log("RESPAWN BALL");
        transform.position = StartPoint;
    }
}
