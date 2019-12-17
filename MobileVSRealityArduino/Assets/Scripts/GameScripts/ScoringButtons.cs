using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringButtons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void HomeButton()
    {
        Application.LoadLevel("StartScene");
    }

  
    public void RestartButton()
    {
        Application.LoadLevel("SinglepLayerScene");
    }
}
