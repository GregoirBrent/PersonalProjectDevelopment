using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    LevelManager LevelManager;
    ScoreWindow ScoreWindow;
    StrokeManager StrokeManager;

    void Start()
    {
        ScoreWindow = GameObject.FindObjectOfType<ScoreWindow>();
        StrokeManager = GameObject.FindObjectOfType<StrokeManager>();
        LevelManager = GameObject.FindObjectOfType<LevelManager>();

        NextHole();
    }

    void NextHole()
    {
        Debug.Log("NEXT");

        LevelManager.LevelComplete();

        StrokeManager.ResetScore();

        //ScoreWindow.deActiveScoreboard();
    }
}
