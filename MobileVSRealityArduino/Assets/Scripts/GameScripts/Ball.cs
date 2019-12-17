using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
	Rigidbody rb;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		rb.sleepThreshold = 0.5f; //Default is 0.005
	}
}
