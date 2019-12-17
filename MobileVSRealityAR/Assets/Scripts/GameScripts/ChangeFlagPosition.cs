using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFlagPosition : MonoBehaviour
{
    public Transform flag;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            flag.transform.position = new Vector3(flag.position.x, 0.0003f, flag.position.z);

        }
    }

    void OnTriggerExit(Collider other)
    {

        flag.transform.position = new Vector3(flag.position.x, 0, flag.position.z);

    }
}
