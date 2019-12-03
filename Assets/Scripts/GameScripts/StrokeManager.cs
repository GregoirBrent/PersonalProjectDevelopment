using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrokeManager : MonoBehaviour
{

    void start()
	{
		FindPlayerBall();
	}

    public float StrokeAngle { get; protected set; }

    Rigidbody playerBallRB;

    private void FindPlayerBall()
	{
		GameObject go = GameObject.FindGameObjectWithTag("Player");

        if (go == null)
        {
            Debug.Log("Kan bal niet vinden...");
        }

        playerBallRB = go.GetComponent<Rigidbody>();

        if (playerBallRB == null)
        {
            Debug.Log("Ball heeft geen RidgidBody...");
        }
	}


    private void Update() //Gebruiken voor visuele frames/inputs
    {
        StrokeAngle += Input.GetAxis("Horizontal") * 100f * Time.deltaTime; 
    }


    private void FixedUpdate() //Run over elke tik in de physics
    {
        if (playerBallRB == null)
        {
            //De bal is out of bounce of gedelete of nog niet gerespawned
            return;
        }

        Vector3 forceVec = new Vector3(0, 0, 5f);

        playerBallRB.AddForce(Quaternion.Euler(0, StrokeAngle, 0) * forceVec, ForceMode.Impulse);
        
    }
}
