using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public GameObject Ball;

	private Vector3 CamereOffset;

    void Start()
    {
        CamereOffset = transform.position - Ball.transform.position; 
    }

    void LateUpdate()
    {
        transform.position = Ball.transform.position + CamereOffset; 
    }

}
