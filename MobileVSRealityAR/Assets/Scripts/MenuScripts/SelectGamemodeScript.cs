using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectGamemodeScript : MonoBehaviour
{
    
    public void SelectSingleplayer()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Application.LoadLevel("SingleplayerScene");
    }

 
    public void SelectMultiplayer()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Application.LoadLevel("MultiplayerScene");
    }
}
