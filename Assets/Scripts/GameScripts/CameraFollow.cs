using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform Ball;

    public float turnSpeed = 4.0f;

	private Vector3 CamereOffset;

    void Start()
    {
        //CamereOffset = transform.position - Ball.transform.position;

        CamereOffset = new Vector3(Ball.position.x, Ball.position.y + 8.0f, Ball.position.z + 7.0f);
    }

    void LateUpdate()
    {
        //transform.position = Ball.transform.position + CamereOffset;

        CamereOffset = Quaternion.AngleAxis(Input.GetAxis("RoteerX") * turnSpeed, Vector3.up) * CamereOffset;
        CamereOffset = Quaternion.AngleAxis(Input.GetAxis("RoteerY") * turnSpeed, Vector3.up) * CamereOffset;
        transform.position = Ball.transform.position + CamereOffset;
        transform.LookAt(Ball.position);

    }

}
