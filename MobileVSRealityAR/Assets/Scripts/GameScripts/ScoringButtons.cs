using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringButtons : MonoBehaviour
{
    public void HomeButton()
    {
        Application.LoadLevel("StartScene");
    }


    public void RestartButton()
    {
        Application.LoadLevel("SinglepLayerScene");
    }
}
