using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ScoreManager : MonoBehaviour
{
	Dictionary<string, Dictionary<string, int>> playerScores;

	void Start()
	{
		//SetScore("Arduino", "stroke1", 3);
		//SetScore("Arduino", "stroke2", 5);
		//SetScore("Arduino", "stroke3", 10);
		//SetScore("Arduino", "total", 18);

		//SetScore("Brent", "stroke1", 3);
		//SetScore("Brent", "stroke2", 5);

		//SetScore("Lotte", "stroke1", 10);
		//SetScore("Lotte", "stroke2", 18);
	}

	void Init()
	{
		if (playerScores != null)
		{
			return;
		}
		playerScores = new Dictionary<string, Dictionary<string, int>>();
	}


	public int GetScore(string username, string scoreType)
	{
		Init();

		if (playerScores.ContainsKey(username) == false)
		{
			//nog geen score gevonden
			return 0;
		}

		if (playerScores[username].ContainsKey(scoreType) == false)
		{
			return 0;
		}

		return playerScores[username][scoreType];
	}

	public void SetScore(string username, string scoreType, int value)
	{
		Init();

		if (playerScores.ContainsKey(username) == false)
		{
			playerScores[username] = new Dictionary<string, int>();
		}

		playerScores[username][scoreType] = value;

	}

	//public void ChangeScore(string username, string scoreType, int amount)
	//{
	//    Init();
	//    int currScore = GetScore(username, scoreType);
	//    SetScore(username, scoreType, currScore + amount);
	//}

	public string[] GetPlayerNames()
	{
		Init();
		return playerScores.Keys.ToArray();
	}

}
