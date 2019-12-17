using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;
using UnityEngine;

public class StrokeManager : MonoBehaviour
{
    //ARDUINO
    private SerialPort stream;
    private Thread thread;
    private Queue inputQueue;
    public bool looping = true;

    public int xDirection = 0; // 1, 0, -1
    public int yDirection = 0; // 1, 0, -1

    public bool hitPressed = false;
    public bool leftPressed = false;
    public bool rightPressed = false;

    void Start()
    {
        StrokeCount = 0;

        //ARDUINO
        StartThread();

        FindPlayerBall();
    }


    //ARDUINO
    public void StartThread() //creates and start thread
    {
        //outputQueue = Queue.Synchronized(new Queue());
        inputQueue = Queue.Synchronized(new Queue());
        thread = new Thread(ThreadLoop);
        thread.Start();
        Debug.Log("START THREAD");
    }

    public bool IsLooping()
    {
        lock (this)
        {
            return looping;
        }
    }

    public void ThreadLoop() //The code of the thread goes here
    {

        //open the connection on the serial port
        stream = new SerialPort("/dev/cu.usbmodem14201", 9600);
        stream.ReadTimeout = 50;
        stream.Open();

        //looping
        while (IsLooping())
        {
            //Debug.Log("THREAD LOOP");
            //Read from Arduino
            int result = ReadFromArduino();
            //Debug.Log(result);
            if (result != 0)
            {
                //Debug.Log("Hallo van Arduino");
                inputQueue.Enqueue("" + result);
                //Debug.Log(result);
            }
        }

        //close the steam
        stream.Close();
    }

    public int ReadFromArduino(int timeout = 0)
    {
        stream.ReadTimeout = timeout;
        try
        {
            return stream.ReadByte();
        }
        catch (TimeoutException)
        {
            return 0;
        }
    }

    public void StopThread()
    {
        lock (this)
        {
            looping = false;
        }
    }

    public float StrokeAngle { get; protected set; }
    public float StrokeForce { get; protected set; }
    public int StrokeCount { get; protected set; }

    float strokeForceFillSpeed = 5f;
    int fillDir = 1;
    float MaxStrokeForce = 10f;

    public enum StrokeModeEnum { AIMING, FILLING, DO_HIT, BALL_IS_ROLLING };
    public StrokeModeEnum StrokeMode { get; protected set; }

    public float StrokeForcePerc { get { return StrokeForce / MaxStrokeForce; } }

    public Rigidbody playerBallRB;

    public GameObject Arrow;


    private void FindPlayerBall()
    {

        GameObject go = GameObject.Find("Ball");
        //GameObject go = GameObject.FindObjectOfType<>;

        if (playerBallRB == null)
        {
            Debug.Log("Kan bal niet vinden...");
            //startGame();
        }

        playerBallRB = go.GetComponent<Rigidbody>();

        if (playerBallRB == null)
        {
            Debug.Log("Ball heeft geen RidgidBody...");
            //startGame();
        }
    }

    public void ResetScore()
    {
        StrokeCount = 0;
    }

    //ARDUINO
    public string ReadFromArduinoQueue()
    {
        if (inputQueue.Count == 0)
            return null;

        return (string)inputQueue.Dequeue();
    }


    private void Update() //Gebruiken voor visuele frames/inputs
    {

        string arduinoMessage = ReadFromArduinoQueue();

        switch (arduinoMessage)
        {
            case "1":
                xDirection = 1;
                break;
            case "2":
                xDirection = 0;
                break;
            case "3":
                xDirection = -1;
                break;
            case "4":
                yDirection = 1;
                break;
            case "5":
                yDirection = 0;
                break;
            case "6":
                yDirection = -1;
                break;
            case "7":
                hitPressed = true;
                break;
            case "8":
                hitPressed = false;
                break;

            case "9":
                leftPressed = true;
                break;
            case "10":
                leftPressed = false;
                break;

            case "11":
                rightPressed = true;
                break;
            case "12":
                rightPressed = false;
                break;
        }

        if (StrokeMode == StrokeModeEnum.AIMING)
        {
            //StrokeAngle += Input.GetAxis("Horizontal") * 100f * Time.deltaTime;

            //ARDUINO
            if (leftPressed)
            {
                StrokeAngle -= 2;
            }

            if (rightPressed)
            {
                StrokeAngle += 2;
            }

            if (hitPressed)
            //if (Input.GetButtonUp("Fire1"))
            {
                Debug.Log("SET FORCE");
                StrokeMode = StrokeModeEnum.FILLING;
                hitPressed = false;
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

            //if (Input.GetButtonUp("Fire1"))
            if (hitPressed)
            {
                Debug.Log("BAL HIT");
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
            Debug.Log("Geen BALL");
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
