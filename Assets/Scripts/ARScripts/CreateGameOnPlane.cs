using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.XR;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class CreateGameOnPlane : MonoBehaviour
{

    public ARRaycastManager raycastManager;
    public GraphicRaycaster raycaster;


    void Start()
    {
 
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !isClickOverUI())
        {
            List<ARRaycastHit> hitPoints = new List<ARRaycastHit>();
            raycastManager.Raycast(Input.mousePosition, hitPoints, (UnityEngine.XR.ARSubsystems.TrackableType)TrackableType.Planes);

            if (hitPoints.Count > 0)
            {
                Pose pose = hitPoints[0].pose;
                transform.rotation = pose.rotation;
                transform.position = pose.position;
            }
        }
    }

    bool isClickOverUI()
    {
        PointerEventData data = new PointerEventData(EventSystem.current)
        {
            position = Input.mousePosition
        };
        List<RaycastResult> results = new List<RaycastResult>();
        raycaster.Raycast(data, results);
        return results.Count > 0;
    }

}





//[SerializeField]
//private GameObject gameModel;
//private GameObject canvasButtons;

//private GameObject arInstance;
//private bool objectPlaced = false;


//sessionOrigin = GetComponent<ARRaycastManager>();
////hits = new List<ARRaycastHit>();

////gameModel.SetActive(false);
//canvasButtons.SetActive(false);

//arInstance = Instantiate(gameModel);
//arInstance.gameObject.SetActive(false);



//if (objectPlaced)
//{
//    return;
//}

//List<ARRaycastHit>  hits = new List<ARRaycastHit>();

////var screenPoint = new Vector3(Screen.width / 2.0f, Screen.height / 2.0f, 4);

//Touch touch = Input.GetTouch(0);

//if (sessionOrigin.Raycast(touch.position, hits))
//{
//    // If we did hit something then we should place the instance in that point in space.
//    // Order hits to find closest one.
//    hits.OrderBy(h => h.distance);
//    var pose = hits[0].pose;
//    // Activate instance and move it to position on detected surface
//    arInstance.gameObject.SetActive(true);
//    arInstance.transform.position = pose.position;
//    arInstance.transform.up = pose.up;

//}
//else
//{
//    // If we didn't hit anything than we should hide instance
//    arInstance.gameObject.SetActive(false);
//}

//if (Input.touchCount == 0)
//{
//    return;
//}

//Touch touch = Input.GetTouch(0);

//if (sessionOrigin.Raycast(touch.position, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes))
//{
//    Pose pose = hits[0].pose;

//    if(!gameModel.activeInHierarchy)
//    {
//        gameModel.SetActive(true);
//        gameModel.transform.position = pose.position;
//        canvasButtons.SetActive(true);
//    } else
//    {
//        gameModel.transform.position = pose.position;
//    }

//}



//public void PlacingFinished()
//{
//    objectPlaced = true;
//}

//public void PlacingBegin()
//{
//    objectPlaced = false;
//}

