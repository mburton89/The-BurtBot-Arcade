using UnityEngine;
using System;

public class GameOverMenu : MonoBehaviour{

	public TextMesh Score;
	public TextMesh HighScore;

//	public void Awake(){
//		Score.text = "Score: " + PlayerPrefs.GetInt ("score");
//		HighScore.text = "High Score: " + PlayerPrefs.GetInt ("currentHighScore");
//	}

	void OnGUI(){
		GUI.TextArea (new Rect (Screen.width / 2.5f, Screen.height / 10, Screen.width / 5, Screen.height / 10), "Score: " + PlayerPrefs.GetInt ("score")); 
		GUI.TextArea (new Rect (Screen.width / 2.5f, Screen.height / 5, Screen.width / 5, Screen.height / 10), "High Score: " + PlayerPrefs.GetInt ("currentHighScore")); 
		
		if (GUI.Button (new Rect (Screen.width / 2.5f, Screen.height / 3, Screen.width / 5, Screen.height / 10), "Play")) {
			Application.LoadLevel(1);		
		}
		
		if (GUI.Button (new Rect (Screen.width / 2.5f, Screen.height / 2, Screen.width / 5, Screen.height / 10), "Leaderboard")) {
			Application.LoadLevel(3);		
		}
	}
}

