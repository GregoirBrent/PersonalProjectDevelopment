using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARStrokeManager : MonoBehaviour
{

    void Start()
    {
        FindPlayerBall();
        StrokeCount = 0;
        Arrow = GameObject.FindGameObjectWithTag("Arrow");
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

    public bool arHitIsPressed = false;
    public bool arLeftIsPressed = false;
    public bool arRightIsPressed = false;

    public void ARhitButton()
    {
        arHitIsPressed = true;
    }

    public void ARLeftButton()
    {
        arLeftIsPressed = true;
    }

    public void ARRightButton()
    {
        arRightIsPressed = true;
    }


    private void Update() //Gebruiken voor visuele frames/inputs
    {

        if (StrokeMode == StrokeModeEnum.AIMING)
        {
            StrokeAngle += Input.GetAxis("Horizontal") * 100f * Time.deltaTime;


            if (arRightIsPressed == true)
            {
                StrokeAngle += 1 * 100f * Time.deltaTime;
                //arRightIsPressed = false;
            }

            if (arLeftIsPressed == true)
            {
                StrokeAngle -= 1 * 100f * Time.deltaTime;
                //arLeftIsPressed = false;
            }


            if (arHitIsPressed == true)
            //if (Input.GetButtonUp("Fire1"))
            {
                Debug.Log("SET FORCE");
                StrokeMode = StrokeModeEnum.FILLING;
                arHitIsPressed = false;
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
            if (arHitIsPressed == true)
            {
                Debug.Log("BAL HIT");
                Arrow.SetActive(false);
                StrokeMode = StrokeModeEnum.DO_HIT;
                arHitIsPressed = false;
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
