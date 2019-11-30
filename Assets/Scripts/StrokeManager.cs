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
    }


    public float StrokeAngle { get; protected set; }
    public float XA { get; protected set; }
    public float YA { get; protected set; }
    public float StrokeForce { get; protected set; }

    public enum StrokeModeEnum {READY_TO_HIT, BALL_IS_ROLLING };
    public StrokeModeEnum StrokeMode { get; protected set; }

    Rigidbody playerBallRB;
    bool doWhack = false;
    
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

        //if (Input.GetKeyUp(KeyCode.Space))
        //{
        //    doWhack = true;
        //}

        //StrokeAngle += Input.GetAxis("Horizontal") * 100f * Time.deltaTime;

        //if (Arduino == 2)
        //{
        //    XA += -Input.GetAxis("Horizontal") * 1f;
        //    StrokeAngle += -1f;
        //    YA += -Input.GetAxis("Vertical") * 1f;
        //}

        //if (Arduino == 3)
        //{
        //    XA += Input.GetAxis("Horizontal") * 1f;
        //    StrokeAngle += 1f;
        //    YA += Input.GetAxis("Vertical") * 1f;
        //}
    }

    void MoveObject(int Direction)
    {
        if(Direction == 1)
        {
            doWhack = true;
            Arduino = 1;
        }

  
        if (Direction == 2)
        {
            Arduino = 2;
            XA += -Input.GetAxis("Horizontal") * 1f;
            StrokeAngle += -1f;
            YA += -Input.GetAxis("Vertical") * 1f;

        }

        if (Direction == 3)
        {
            Arduino = 3;
            XA += Input.GetAxis("Horizontal") * 1f;
            StrokeAngle += 1f;
            YA += Input.GetAxis("Vertical") * 1f;
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

        if (StrokeMode != StrokeModeEnum.READY_TO_HIT)
        {
            //Niks mogen doen, Wachten tot bal terug stil ligt
            updateStrokeMode();
            return;
        }


        if (doWhack)
        {
            doWhack = false;
        }

        if ( Arduino == 1)
		{
            Vector3 forceVec = new Vector3(0, 0, 2f);

            playerBallRB.AddForce(Quaternion.Euler(XA, StrokeAngle, YA) * forceVec, ForceMode.Impulse);

            StrokeMode = StrokeModeEnum.BALL_IS_ROLLING;
		}

    }
}
