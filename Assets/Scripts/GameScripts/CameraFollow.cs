using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform PlayerTransform;
	private Vector3 CamereOffset;

    [Range(0.01f, 1.0f)]
	public float SmoothFactor = 0.5f;

    void Start()
	{
        CamereOffset = transform.position - PlayerTransform.position;
	}

    void LateUpdate()
	{
		Vector3 newPos = PlayerTransform.position + CamereOffset;
		PlayerTransform.position = Vector3.Slerp(PlayerTransform.position, newPos, SmoothFactor);
	}
}
