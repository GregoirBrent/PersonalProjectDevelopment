using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    LevelManager LevelManager;
    ScoreWindow ScoreWindow;

    void Start()
    {
        LevelManager = GameObject.FindObjectOfType<LevelManager>();
        LevelManager.LevelComplete();

        ScoreWindow = GameObject.FindObjectOfType<ScoreWindow>();
        ScoreWindow.deActiveScoreboard();

    }
}
