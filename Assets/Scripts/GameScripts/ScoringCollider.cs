using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringCollider : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("BALL IN HOLE! NICE DONE!!!");
    }
}
