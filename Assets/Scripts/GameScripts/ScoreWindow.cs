using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreWindow : MonoBehaviour
{

    public GameObject scoreBoard;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activeScoreboard()
    {
        Debug.Log("zichtbaar");
        scoreBoard.SetActive(true);
    }

    public void deActiveScoreboard()
    {
        Debug.Log("Niet zichtbaar");
        scoreBoard.SetActive(false);
    }
}

