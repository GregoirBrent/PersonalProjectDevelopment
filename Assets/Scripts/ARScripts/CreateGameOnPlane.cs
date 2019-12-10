using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.XR;
using UnityEngine.XR.ARFoundation;

public class CreateGameOnPlane : MonoBehaviour
{

    private ARRaycastManager sessionOrigin;
    private List<ARRaycastHit> hits;

    public GameObject game;
    public GameObject canvas;

    void Start()
    {

        sessionOrigin = GetComponent<ARRaycastManager>();
        hits = new List<ARRaycastHit>();

        game.SetActive(false);
        canvas.SetActive(false);

    }


    void Update()
    {

        if (Input.touchCount == 0)
        {
            return;
        }

        if(Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (sessionOrigin.Raycast(touch.position, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes))
            {

                Pose pose = hits[0].pose;

                if (!game.activeInHierarchy)
                {
                    game.SetActive(true);
                    game.transform.position = pose.position;
                    canvas.SetActive(true);
                }
                //else
                //{
                //    game.transform.position = pose.position;
                //}
            }
        }

        //If there are two touches on the device...
        //if (Input.touchCount == 2)
        //{
        //    // Store both touches.
        //    Touch touchZero = Input.GetTouch(0);
        //    Touch touchOne = Input.GetTouch(1);

        //    // Find the position in the previous frame of each touch.
        //    Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
        //    Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

        //    // Find the magnitude of the vector (the distance) between the touches in each frame.
        //    float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
        //    float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

        //    // Find the difference in the distances between each frame.
        //    float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

        //    game.transform.localScale = new Vector3(deltaMagnitudeDiff, deltaMagnitudeDiff, deltaMagnitudeDiff);

        //}
    }

}