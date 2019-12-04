using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SpawnLevel();
        //Debug.Log(Levels.Length);
    }

    public GameObject[] Levels;
    int levelIndex;
    GameObject currLevel;

    

    void DespawnLevel()
    {
        Destroy(currLevel);
    }

    void SpawnLevel()
    {
        //Debug.Log(levelIndex);
        currLevel = GameObject.Instantiate(Levels[levelIndex]);
        //Debug.Log(currLevel);
    }

    public void LevelComplete()
    {
        DespawnLevel();
        levelIndex++;
        SpawnLevel();
    }

}
