using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.IO.Ports;

public class StrokeManager : MonoBehaviour
{

    void Start()
	{
        //sp.Open();
        //sp.ReadTimeout = 1;

        FindPlayerBall();
        StrokeCount = 0;
        Arrow = GameObject.FindGameObjectWithTag("Arrow");
    }

    //SerialPort sp = new SerialPort("/dev/cu.usbmodem14201", 9600);
    //int Arduino = 0;

    public float StrokeAngle { get; protected set; }
    public float StrokeForce { get; protected set; }
    public int StrokeCount { get; protected set; }

    float strokeForceFillSpeed = 5f;
    int fillDir = 1;
    float MaxStrokeForce = 10f;

    public enum StrokeModeEnum { AIMING, FILLING, DO_HIT, BALL_IS_ROLLING };
    public StrokeModeEnum StrokeMode { get; protected set; }

    public float StrokeForcePerc { get { return StrokeForce / MaxStrokeForce; } }

    Rigidbody playerBallRB;

    public GameObject Arrow;

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
        //if (sp.IsOpen)
        //{
        //    try
        //    {
        //        int Value = sp.ReadByte();
        //        Arduino = Value;
        //    }
        //    catch (System.Exception)
        //    {
        //        return;
        //    }

        //}

        //Debug.Log(++Counter + " Arduino: " + Arduino);

        if (StrokeMode == StrokeModeEnum.AIMING)
        {

            StrokeAngle += Input.GetAxis("Horizontal") * 100f * Time.deltaTime;

            //if (Arduino == 2)
            //{
            //    //Debug.Log("joystick +1");
            //    StrokeAngle += 1f;
            //}

            //if (Arduino == 3)
            //{
            //    //Debug.Log("joystick -1");
            //    StrokeAngle -= 1f;
            //}

            if  (Input.GetButtonUp("Fire1") /*Arduino == 1*/)
            {
                //Debug.Log("volume");
                StrokeMode = StrokeModeEnum.FILLING;
                return;
            }

        }



        if (StrokeMode == StrokeModeEnum.FILLING)
        {
            StrokeForce += (strokeForceFillSpeed * fillDir) * Time.deltaTime;

            if (StrokeForce > MaxStrokeForce)
            {
                StrokeForce = MaxStrokeForce;
                fillDir = -1;
            }
            else if (StrokeForce < 0)
            {
                StrokeForce = 0;
                fillDir = 1;
            }

            if (Input.GetButtonUp("Fire1"))
            {
                Arrow.SetActive(false);
                StrokeMode = StrokeModeEnum.DO_HIT;
            }
        }
    }


    void CheckRollingStatus()
    {
        //is de bal nog aan het rollen?
        if (playerBallRB.IsSleeping())
        {
            Arrow.SetActive(true);
            StrokeMode = StrokeModeEnum.AIMING;
        }

        //Debug.Log(playerBallRB.IsSleeping());
    }


    private void FixedUpdate() //Run over elke tik in de physics
    {
        if (playerBallRB == null)
        {
            //De bal is out of bounce of gedelete of nog niet gerespawned
            return;
        }

        if (StrokeMode == StrokeModeEnum.BALL_IS_ROLLING)
        {
            CheckRollingStatus();
            return;
        }

        if (StrokeMode != StrokeModeEnum.DO_HIT)
        {
            return;
        }


        Vector3 forceVec = new Vector3(0, 0, StrokeForce);

        playerBallRB.AddForce(Quaternion.Euler(0, StrokeAngle, 0) * forceVec, ForceMode.Impulse);

        StrokeForce = 0;
        fillDir = 1;
        StrokeCount++;
        StrokeMode = StrokeModeEnum.BALL_IS_ROLLING;
    }
}
