using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
	public Transform spawnPoint;
	public Ball Ball;

	void Start()
	{
		Spawn();
	}

	public void Spawn()
	{
		Ball = GameObject.FindObjectOfType<Ball>();
		Ball.transform.position = spawnPoint.transform.position;
	}
}
