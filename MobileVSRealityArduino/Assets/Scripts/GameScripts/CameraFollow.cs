using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform Ball;

	public float turnSpeed = 4.0f;

	private Vector3 CamereOffsetX;
	private Vector3 CamereOffsetY;

	public float height = 1f;
	public float distance = 2f;

	StrokeManager StrokeManager;

	void Start()
	{
		CamereOffsetX = new Vector3(0, height, distance);
		CamereOffsetY = new Vector3(0, 0, distance);

		StrokeManager = GameObject.FindObjectOfType<StrokeManager>();

	}

	float rotateX = 0;
	float rotateY = 0;

	private void FixedUpdate()
	{

        //CamereOffsetX = Quaternion.AngleAxis(Input.GetAxis("RoteerX") * turnSpeed, Vector3.up) * CamereOffsetX;
        //CamereOffsetY = Quaternion.AngleAxis(Input.GetAxis("RoteerY") * turnSpeed, Vector3.right) * CamereOffsetY;


        //ARDUINO JOYSTICK
        if (StrokeManager.xDirection == 1)
        {
            Debug.Log("X up");
            rotateX += 1 * Time.deltaTime;
        }
        else if (StrokeManager.xDirection == -1)
        {
            Debug.Log("X down");
            rotateX -= 1 * Time.deltaTime;
        }
        else if (StrokeManager.xDirection == 0)
        {
            rotateX = 0;
        }

        if (StrokeManager.yDirection == 1)
        {
            Debug.Log("Y up");
            rotateY += 1 * Time.deltaTime;
        }
        else if (StrokeManager.yDirection == -1)
        {
            Debug.Log("Y down");
            rotateY -= 1 * Time.deltaTime;
        }
        else if (StrokeManager.yDirection == 0)
        {
            rotateY = 0;
        }

        CamereOffsetX = Quaternion.AngleAxis(rotateX * turnSpeed, Vector3.up) * CamereOffsetX;

        CamereOffsetY = Quaternion.AngleAxis(rotateY * turnSpeed, Vector3.right) * CamereOffsetY;



        if (Ball.rotation.eulerAngles.x > 45f && Ball.rotation.eulerAngles.x < 180f)
		{
			Ball.rotation = Quaternion.Euler(45f, 0, 0);
		}

		if (Ball.rotation.eulerAngles.x > 180f && Ball.rotation.eulerAngles.x < 300f)
		{
			Ball.rotation = Quaternion.Euler(300f, 0, 0);
		}

		float desiredXAngle = Ball.eulerAngles.x;
		float desiredYAngle = Ball.eulerAngles.y;
		Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);
		//transform.position = Ball.position - (rotation * CamereOffsetX);

		transform.position = Ball.transform.position + CamereOffsetX + CamereOffsetY;

		if (transform.position.y < Ball.position.y)
		{
			transform.position = new Vector3(transform.position.x, Ball.position.y, transform.position.z);
		}

		transform.LookAt(Ball.position);

	}
}
