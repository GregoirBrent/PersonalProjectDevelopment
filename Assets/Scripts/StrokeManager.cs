using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class StrokeManager : MonoBehaviour
{

    //private float amountToMove;
    int Arduino = 0;
    SerialPort sp = new SerialPort("/dev/cu.usbmodem14201", 9600);

    void Start()
    {
        sp.Open();
        sp.ReadTimeout = 1;

        FindPlayerBall();
        StrokeCount = 1;
    }


    public float StrokeAngle { get; protected set; }
    public float XA { get; protected set; }
    public float YA { get; protected set; }
    public float StrokeForce { get; protected set; }

    public int StrokeCount { get; protected set; }


    public float StrokeForcePerc { get { return StrokeForce / MaxStrokeForce; }}

    float strokeForceFillSpeed = 5f;
    int fillDir = 1;


    float MaxStrokeForce = 10f;

    public enum StrokeModeEnum {AIMING, FILLING, READY_TO_HIT, BALL_IS_ROLLING };
    public StrokeModeEnum StrokeMode { get; protected set; }

    Rigidbody playerBallRB;

    //bool doWhack = false;
    bool doFill = false;
    
    //Update is called once per visual frame -- use this for inputs

    private void Update()
    {


        //amountToMove = StrokeForce * Time.deltaTime;

        if (sp.IsOpen)
        {
            try
            {
                MoveObject(sp.ReadByte());

            }
            catch (System.Exception)
            {
                return;
            }

        }

        if (StrokeMode == StrokeModeEnum.AIMING)
        {
            if (Arduino == 2)
            {
                XA += -Input.GetAxis("Horizontal") * 1f;
                StrokeAngle += -1f;
                YA += -Input.GetAxis("Vertical") * 1f;
            }

            if (Arduino == 3)
            {
                XA += Input.GetAxis("Horizontal") * 1f;
                StrokeAngle += 1f;
                YA += Input.GetAxis("Vertical") * 1f;
            }

        }

        //if (Input.GetKeyUp(KeyCode.Space))
        //{
        //    doWhack = true;
        //}

        //StrokeAngle += Input.GetAxis("Horizontal") * 100f * Time.deltaTime;

        if(StrokeMode == StrokeModeEnum.FILLING && Arduino == 1)
        {
            StrokeForce += (strokeForceFillSpeed * fillDir) * Time.deltaTime;

            if(StrokeForce > MaxStrokeForce) {

                StrokeForce = MaxStrokeForce;
                fillDir = -1;
            }
            else if (StrokeForce < 0)
            {
                StrokeForce = 0;
                fillDir = 1;
            }
        }
    }

    void MoveObject(int Direction)
    {
        if(Direction == 1)
        {
            //doWhack = true;
            Arduino = 1;
            StrokeMode = StrokeModeEnum.READY_TO_HIT;
            return;
        }

  
        if (Direction == 2)
        {
            Arduino = 2;
            //XA += -Input.GetAxis("Horizontal") * 1f;
            //StrokeAngle += -1f;
            //YA += -Input.GetAxis("Vertical") * 1f;

        }

        if (Direction == 3)
        {
            Arduino = 3;
            //XA += Input.GetAxis("Horizontal") * 1f;
            //StrokeAngle += 1f;
            //YA += Input.GetAxis("Vertical") * 1f;
        }

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


    void CheckRollingStatus()
    {
        //is de bal nog steeds aan het rollen?
        if (playerBallRB.IsSleeping())
        {
            StrokeCount++; //TO DO: Tot we ebben gescoord;
            StrokeMode = StrokeModeEnum.AIMING;
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
            CheckRollingStatus();
            return;
        }

        if (StrokeMode != StrokeModeEnum.READY_TO_HIT)
        {
            //Niks mogen doen, Wachten tot bal terug stil ligt
            //updateStrokeMode();
            return;
        }


        Vector3 forceVec = new Vector3(0, 0, 5f);

        playerBallRB.AddForce(Quaternion.Euler(XA, StrokeAngle, YA) * forceVec, ForceMode.Impulse);

        StrokeForce = 0;
        fillDir = 1;
        StrokeMode = StrokeModeEnum.BALL_IS_ROLLING;

        //if (Arduino == 1)
        //{
        //    Vector3 forceVec = new Vector3(0, 0, 5f);

        //    playerBallRB.AddForce(Quaternion.Euler(XA, StrokeAngle, YA) * forceVec, ForceMode.Impulse);

        //    StrokeForce = 0;
        //    fillDir = 1;
        //    StrokeMode = StrokeModeEnum.BALL_IS_ROLLING;
        //}

    }
}
