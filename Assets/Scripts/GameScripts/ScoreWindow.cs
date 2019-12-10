using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreWindow : MonoBehaviour
{

    public GameObject scoreBoard;
    ScoreManager ScoreManager;
    StrokeManager StrokeManager;
    LevelManager LevelManager;

    int levelIndex;

    void Start()
    {
        ScoreManager = GameObject.FindObjectOfType<ScoreManager>();
        StrokeManager = GameObject.FindObjectOfType<StrokeManager>();
        LevelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActiveScoreboard()
    {
        Debug.Log("zichtbaar");

        //scoreBoard.SetActive(!scoreBoard.activeSelf);

        LevelManager.GetComponent<LevelManager>();
        //Debug.Log(LevelManager.Levels.Length);

        if(LevelManager.Levels[0] == LevelManager.Levels[levelIndex])
        {
            Debug.Log("MAP 1");
            ScoreManager.SetScore("Arduino", "stroke1", StrokeManager.StrokeCount);
        }

        if (LevelManager.Levels[1] == LevelManager.Levels[levelIndex])
        {
            Debug.Log("MAP 2");
            ScoreManager.SetScore("Arduino", "stroke2", StrokeManager.StrokeCount);
        }


        //ScoreManager.SetScore("Arduino", "total", StrokeManager.StrokeCount);
        //ScoreManager.SetScore("Arduino", "stroke3", StrokeManager.StrokeCount);
    }

    //public void deActiveScoreboard()
    //{
    //    Debug.Log("Niet zichtbaar");
    //    scoreBoard.SetActive(scoreBoard.activeSelf);
    //}
}
