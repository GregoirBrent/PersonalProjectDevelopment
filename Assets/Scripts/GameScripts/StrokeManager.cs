using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using System.IO.Ports;
//using System.Threading;
using System;

public class StrokeManager : MonoBehaviour
{

    //SerialPort stream = new SerialPort("/dev/cu.usbmodem14201", 9600);

    //private SerialPort stream;
    //private Thread thread;
    ////private Queue outputQueue;
    //private Queue inputQueue;
    //public bool looping = true;


    void Start()
    { 
        FindPlayerBall();
        StrokeCount = 0;
        Arrow = GameObject.FindGameObjectWithTag("Arrow");

        //StartThread();
    }

    //ARDUINO
    //public void StartThread() //creates and start thread
    //{
    //    //outputQueue = Queue.Synchronized(new Queue());
    //    inputQueue = Queue.Synchronized(new Queue());
    //    thread = new Thread(ThreadLoop);
    //    thread.Start();
    //    Debug.Log("START THREAD");
    //}

    //public bool IsLooping()
    //{
    //    lock (this)
    //    {
    //        return looping;
    //    }
    //}

    //public void ThreadLoop() //The code of the thread goes here
    //{

    //    //open the connection on the serial port
    //    stream = new SerialPort("/dev/cu.usbmodem14201", 9600);
    //    stream.ReadTimeout = 50;
    //    stream.Open();

    //    //looping
    //    while (IsLooping())
    //    {
    //        //Debug.Log("THREAD LOOP");
    //        //Read from Arduino
    //        int result = ReadFromArduino();
    //        //Debug.Log(result);
    //        if (result != 0)
    //        {
    //            //Debug.Log("Hallo van Arduino");
    //            inputQueue.Enqueue("" + result);
    //            //Debug.Log(result);
    //        }
    //    }

    //    //close the steam
    //    stream.Close();
    //}

    //public int ReadFromArduino(int timeout = 0)
    //{
    //    stream.ReadTimeout = timeout;
    //    try
    //    {
    //        return stream.ReadByte();
    //    }
    //    catch (TimeoutException)
    //    {
    //        return 0;
    //    }
    //}

    //public void StopThread()
    //{
    //    lock (this)
    //    {
    //        looping = false;
    //    }
    //}

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


    public void ResetScore()
    {
        StrokeCount = 0;
    }

    //public string ReadFromArduinoQueue()
    //{
    //    if (inputQueue.Count == 0)
    //        return null;

    //    return (string)inputQueue.Dequeue();
    //}

    private void Update() //Gebruiken voor visuele frames/inputs
    {
        //string arduinoMessage = ReadFromArduinoQueue();

        if (StrokeMode == StrokeModeEnum.AIMING)
        {
            //StrokeAngle += Input.GetAxis("Horizontal") * 100f * Time.deltaTime;

            //if (arduinoMessage == "2")
            //{
            //    StrokeAngle += 2;
            //}

            //if (arduinoMessage == "3")
            //{
            //    StrokeAngle -= 2;
            //}

            //if (arduinoMessage == "1")
            ////if (Input.GetButtonUp("Fire1"))
            //{
            //    Debug.Log("SET FORCE");
            //    StrokeMode = StrokeModeEnum.FILLING;
            //    return;
            //}
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

            //if (Input.GetButtonUp("Fire1"))
            //if (arduinoMessage == "1")
            //{
            //    Debug.Log("BAL HIT");
            //    Arrow.SetActive(false);
            //    StrokeMode = StrokeModeEnum.DO_HIT;
            //}
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
