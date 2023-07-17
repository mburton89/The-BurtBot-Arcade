using UnityEngine;

public class GameHud : MonoBehaviour{

	public GUISkin Skin;

	public void OnGUI(){
		GUI.skin = Skin;

		GUILayout.BeginArea(new Rect(0 ,0, Screen.width, Screen.height)); //also added padding for GameSkin on Inspector
		{
			GUILayout.BeginVertical(Skin.GetStyle("GameHud"));
			{
				if(Application.loadedLevel == 1){
					GUILayout.Label(string.Format("{0}", GameManager.Instance.Points), Skin.GetStyle("EnemyKillText")); 
				}

//				if(Application.loadedLevel == 0 || Application.loadedLevel == 4){
//					GUILayout.Label(string.Format("NINJEVADE"), Skin.GetStyle("EnemyKillText")); 
//				}

//				if(Application.loadedLevel == 2){
//					GUILayout.Label(string.Format("GAME OVER"), Skin.GetStyle("EnemyKillText"));
//				}

//		UNCOMMENT FOR TIME GUI
//				var time = LevelManager.Instance.RunningTime;
//				GUILayout.Label(string.Format(
//					"{0:00}:{1:00} with {2} bonus", 
//					time.Minutes + (time.Hours * 60), 
//					time.Seconds,
//				    LevelManager.Instance.CurrentTimeBonus), Skin.GetStyle("TimeText"));
			}
			GUILayout.EndVertical();
		}
		GUILayout.EndArea();
	}
}