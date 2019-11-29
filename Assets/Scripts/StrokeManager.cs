﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrokeManager : MonoBehaviour
{
   
    void Start()
    {
        FindPlayerBall();
    }


    public float StrokeAngle { get; protected set; }
    public float StrokeForce { get; protected set; }

    public enum StrokeModeEnum {READY_TO_HIT, BALL_IS_ROLLING };
    public StrokeModeEnum StrokeMode { get; protected set; }

    Rigidbody playerBallRB;
    bool doWhack = false;
    
    //Update is called once per visual frame -- use this for inputs

    private void Update()
    {

        
        if (Input.GetKeyUp(KeyCode.Space))
        {
            doWhack = true;
        }

        StrokeAngle += Input.GetAxis("Horizontal") * 100f * Time.deltaTime;
            
    }


    private void FindPlayerBall()
    {
        //GameObject go = FindObjectOfType<Ball>();
        GameObject go = GameObject.FindGameObjectWithTag("Player"); //niet beste oplossing...

        if (go == null)
        {
            Debug.LogError("Couldn't find the Ball!");
        }

        playerBallRB = go.GetComponent<Rigidbody>();

        if(playerBallRB == null)
        {
            Debug.LogError("Ball has no Ridgidbody....???");
        }
    }


    void updateStrokeMode()
    {
        //is de bal nog steeds aan het rollen?
        if(playerBallRB.IsSleeping())
        {
            StrokeMode = StrokeModeEnum.READY_TO_HIT;
        }
    }


    // Runs on every tick of the physics, manipulation things :)

    void FixedUpdate()
    {

        if (playerBallRB == null)
        {
            //Mag geen error zijn, Kan zijn als de ball out of bounce is, of gedelete, ...
            //Is nog niet gerespawned
            return;
        }

        if (StrokeMode == StrokeModeEnum.BALL_IS_ROLLING)
        {
            //Niks mogen doen, Wachten tot bal terug stil ligt
            updateStrokeMode();
            return;
        }


        if (doWhack)
        {
            doWhack = false;
        }

        if ( Input.GetKeyUp(KeyCode.Space))
		{
            Vector3 forceVec = new Vector3(0, 0, 1.3f);

            playerBallRB.AddForce(Quaternion.Euler(0, StrokeAngle, 0) * forceVec, ForceMode.Impulse);

            StrokeMode = StrokeModeEnum.BALL_IS_ROLLING;
		}
        
    }
}
