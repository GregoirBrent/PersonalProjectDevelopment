using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreWindow : MonoBehaviour
{
    public GameObject scoreBoard;
    ScoreManager ScoreManager;
    StrokeManager StrokeManager;


    void Start()
    {
        ScoreManager = GameObject.FindObjectOfType<ScoreManager>();
        StrokeManager = GameObject.FindObjectOfType<StrokeManager>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ActiveScoreboard()
    {
        Debug.Log("zichtbaar");

        scoreBoard.SetActive(true);

        ScoreManager.SetScore("AR", "stroke1", StrokeManager.StrokeCount);
    }

    public void deActiveScoreboard()
    {
        Debug.Log("Niet zichtbaar");
        scoreBoard.SetActive(false);
    }
}
