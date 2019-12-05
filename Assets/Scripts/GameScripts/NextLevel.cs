using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    LevelManager LevelManager;
    ScoreWindow ScoreWindow;
    //StrokeManager StrokeManager;

    void Start()
    {

        NextHole();
    }

    void NextHole()
    {
        LevelManager = GameObject.FindObjectOfType<LevelManager>();
        LevelManager.LevelComplete();

        ScoreWindow = GameObject.FindObjectOfType<ScoreWindow>();
        ScoreWindow.deActiveScoreboard();

        
    }
}
