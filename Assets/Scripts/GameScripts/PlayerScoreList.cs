using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScoreList : MonoBehaviour
{
    public GameObject playerScoreEntryPrefab;

    ScoreManager scoreManager;

    void Start()
    {
        scoreManager = GameObject.FindObjectOfType<ScoreManager>();

  
    }


    
    void Update()
    {

        if (scoreManager == null)
        {
            Debug.Log("Geen scoremanager gevonden");
            return;
        }

        while (this.transform.childCount > 0)
        {
            Transform c = this.transform.GetChild(0);
            c.SetParent(null);
            //Destroy(c.gameObject);
        }

        string[] names = scoreManager.GetPlayerNames();

        foreach (string name in names)
        {
            GameObject go = (GameObject)Instantiate(playerScoreEntryPrefab);
            go.transform.SetParent(this.transform);
            go.transform.Find("Username").GetComponent<Text>().text = name;
            go.transform.Find("Number1").GetComponent<Text>().text = scoreManager.GetScore(name, "stroke1").ToString();
            go.transform.Find("Number2").GetComponent<Text>().text = scoreManager.GetScore(name, "stroke2").ToString();
            go.transform.Find("Number3").GetComponent<Text>().text = scoreManager.GetScore(name, "stroke3").ToString();
            go.transform.Find("Total").GetComponent<Text>().text = scoreManager.GetScore(name, "total").ToString();
        }

    }
}
