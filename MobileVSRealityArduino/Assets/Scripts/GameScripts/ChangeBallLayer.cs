using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBallLayer : MonoBehaviour
{
    public int LayerOnEnter; //Ball gaat in de Hole
    public int LayerOnExit; // Ball op grasmat



    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.layer = LayerOnEnter;

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.layer = LayerOnExit;
        }
    }
}
