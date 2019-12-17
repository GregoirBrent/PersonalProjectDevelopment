using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectGamemodeScript : MonoBehaviour
{
    [System.Obsolete]
    public void SelectSingleplayer()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Application.LoadLevel("SingleplayerScene");
    }

    [System.Obsolete]
    public void SelectMultiplayer()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Application.LoadLevel("MultiplayerScene");
    }
}
