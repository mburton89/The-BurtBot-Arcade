using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class DeathMenu : MonoBehaviour{
	
	public static DeathMenu Instance {get; private set;}
	public PlayerAi Player {get; private set;} 
	public GUIStyle EmptyTexture;
	public GUIStyle EmptyTextureBlackFont;  
	//public AchievementDeterminer AchievementDeterminer;

	//WIP
	public GameObject UnderPlayerText;

	public AudioClip NewHighScoreSound; 

	//ACHIEVEMENT STRINGS:
	public string determinedAchievement = "CgkImaiNpJgYEAIQEQ";   

	void OnGUI(){
		//GUI.skin = Skin;  
		//if (GUI.Button (new Rect (Screen.width / 2.5f, Screen.height / 3, Screen.width / 5, Screen.height / 10), "Play")) { 

		if((PlayerPrefs.GetInt ("score") > PlayerPrefs.GetInt("previousHighScore4")) && (PlayerPrefs.GetInt("previousHighScore4") > 0) && (Application.loadedLevel == 2)){ 

			//AudioSource.PlayClipAtPoint(NewHighScoreSound, transform.position);

			GUI.Label (new Rect (Screen.width / 2.5f, Screen.height / 4, Screen.width / 5, Screen.height / 10), "New Best: " + PlayerPrefs.GetInt ("score"), EmptyTextureBlackFont); 

			//WIP
			if(PlayerPrefs.GetInt ("score") < 5){   
				//HAS WHITE
				GUI.Label (new Rect (Screen.width / 2.5f, Screen.height / 3, Screen.width / 5, Screen.height / 10), "Get 5 for YELLOW belt", EmptyTextureBlackFont);
																																						
			}else if(PlayerPrefs.GetInt ("score") >= 5 && PlayerPrefs.GetInt ("score") < 10){
				//HAS YELLOW  
				GUI.Label (new Rect (Screen.width / 2.5f, Screen.height / 3, Screen.width / 5, Screen.height / 10), "Get 10 for ORANGE belt", EmptyTextureBlackFont);
			}else if (PlayerPrefs.GetInt ("score") >= 10 && PlayerPrefs.GetInt ("score") < 20){ 
				//HAS ORANGE 
				GUI.Label (new Rect (Screen.width / 2.5f, Screen.height / 3, Screen.width / 5, Screen.height / 10), "Get 20 for GREEN belt", EmptyTextureBlackFont);
			}else if (PlayerPrefs.GetInt ("score") >= 20 && PlayerPrefs.GetInt ("score") < 40){
				//HAS GREEN
				GUI.Label (new Rect (Screen.width / 2.5f, Screen.height / 3, Screen.width / 5, Screen.height / 10), "Get 40 for BLUE belt", EmptyTextureBlackFont);
			}else if (PlayerPrefs.GetInt ("score") >= 40 && PlayerPrefs.GetInt ("score") < 70){
				//HAS BLUE
				GUI.Label (new Rect (Screen.width / 2.5f, Screen.height / 3, Screen.width / 5, Screen.height / 10), "Get 70 for PURPLE belt", EmptyTextureBlackFont);
			}else if (PlayerPrefs.GetInt ("score") >= 70 && PlayerPrefs.GetInt ("score") < 100){
				//HAS PURPLE
				GUI.Label (new Rect (Screen.width / 2.5f, Screen.height / 3, Screen.width / 5, Screen.height / 10), "Get 100 for BROWN belt", EmptyTextureBlackFont);
			}else if (PlayerPrefs.GetInt ("score") >= 100 && PlayerPrefs.GetInt ("score") < 140){
				//HAS BROWN
				GUI.Label (new Rect (Screen.width / 2.5f, Screen.height / 3, Screen.width / 5, Screen.height / 10), "Get 140 for RED belt", EmptyTextureBlackFont);
			}else if (PlayerPrefs.GetInt ("score") >= 140 && PlayerPrefs.GetInt ("score") < 200){
				//HAS RED 
				GUI.Label (new Rect (Screen.width / 2.5f, Screen.height / 3, Screen.width / 5, Screen.height / 10), "Get 200 for BLACK belt", EmptyTextureBlackFont);
			}else if (PlayerPrefs.GetInt ("score") >= 200 && PlayerPrefs.GetInt ("score") < 500){
				//HAS BLACK  
				GUI.Label (new Rect (Screen.width / 2.5f, Screen.height / 3, Screen.width / 5, Screen.height / 10), "BLACK BELT", EmptyTextureBlackFont);
			}else if (PlayerPrefs.GetInt ("score") >= 500 ){ 
				//OVER 500
				GUI.Label (new Rect (Screen.width / 2.5f, Screen.height / 3, Screen.width / 5, Screen.height / 10), PlayerPrefs.GetInt ("score") + "! Seriously!?", EmptyTextureBlackFont);
			}  

		}else{ //if (Application.loadedLevel == 2){// && PlayerPrefs.GetInt ("score") <= PlayerPrefs.GetInt("previousHighScore4")){ 
			GUI.Label (new Rect (Screen.width / 2.5f, Screen.height / 4, Screen.width / 5, Screen.height / 10), "Score: " + PlayerPrefs.GetInt ("score"), EmptyTextureBlackFont); 
			GUI.Label (new Rect (Screen.width / 2.5f, Screen.height / 3, Screen.width / 5, Screen.height / 10), " Best: " + PlayerPrefs.GetInt ("currentHighScore"), EmptyTextureBlackFont); 
		}  
		//if (GUI.Button (new Rect (Screen.width / 2.5f, Screen.height - 100 , Screen.width / 5, Screen.height / 10), "Play")) { 


		//KEYBOARD RETRY BUTTON
														   //Initially 250
//		if (GUI.Button (new Rect (Screen.width / 2.5f, Screen.height - 250 , Screen.width / 5, Screen.height / 10), "RETRY", EmptyTexture)){ 
//
//			if(GameManager.Instance.Points == 0){
//				Debug.Log("LAWLS YOU GOT 0");  
//			}
//
//			//WIP 1_20_2015
//			//Works EXCEPT The first time. previousHighScore wont work the first time for extisting player.
//			// Perhaps I will try setting previousHighScore when player enters game. Then eat a Pizza. fuck
//			//PlayerPrefs.SetInt("previousHighScore4", PlayerPrefs.GetInt("currentHighScore"));    
//
//			//I FUCKING LOVE LIFE. AND NINJEVADE. THIS IS WHAT IM MEANT TO DO.          
//
//			GameManager.Instance.ResetPointsToZero (); 
//			Player.Animator.SetTrigger("PlayerRespawn");           
//			Player.IsDead = false;    
//			PlayerPrefs.SetInt("isFirstDeath", 0);
//			Application.LoadLevel(1);             
//		}                                
	}
	
	public void Awake(){  
		Instance = this;
	}
	
	public void Start(){
		Player = FindObjectOfType<PlayerAi> ();

		if((PlayerPrefs.GetInt ("score") >= 20)
		   && (PlayerPrefs.GetInt("isFirstDeath") == 0)
		   && (PlayerPrefs.GetInt ("hasSeenRateMenu") != 1)){
			UnderPlayerText.gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("LowerGrassDeathMenu3", typeof(Sprite)) as Sprite;
			PlayerPrefs.SetInt ("hasSeenRateMenu", 1); 
		}
		
		else if(PlayerPrefs.GetInt("isFirstDeath") == 0){
			UnderPlayerText.gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("LowerGrassDeathMenu5", typeof(Sprite)) as Sprite;
		}

		if((PlayerPrefs.GetInt ("score") > PlayerPrefs.GetInt("previousHighScore4")) && (PlayerPrefs.GetInt("previousHighScore4") > 0) && (Application.loadedLevel == 2)){
			AudioSource.PlayClipAtPoint(NewHighScoreSound, transform.position);
		}            
	}
	
	public void Update(){
		HandleUserTouches();



		//DEBUG  
//		if (Input.GetKeyDown (KeyCode.B)) {      
//			GameManager.Instance.ResetPointsToZero ();
//			Player.Animator.SetTrigger("PlayerRespawn"); asasdsdasd
//			Player.IsDead = false;   
//			Application.LoadLevel(4);
//		}
	}

	private void HandleUserTouches(){
		for (int i = 0; i < Input.touchCount; i++){
			Touch touch = Input.GetTouch(i);
			if (touch.phase == TouchPhase.Began && touch.tapCount == 1){
				Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

				//BACK BUTTON
//				if(touchPosition.x < - 13.5 && touchPosition.y > 17 ){
//					GameManager.Instance.ResetPointsToZero ();
//					Player.Animator.SetTrigger("PlayerRespawn");  
//					Player.IsDead = false; 
//					Application.LoadLevel(4);  
//
//				//RETRY BUTTON
//				}
			//if((touchPosition.x < -7.5 || touchPosition.x > 7.5) && touchPosition.y < 8){
				if(touchPosition.y < 16.9){

					if(GameManager.Instance.Points < 5){
						((PlayGamesPlatform) Social.Active).IncrementAchievement(
							determinedAchievement, 1, (bool success) =>{ 
							//nuffin 
						}); 
					}

					if(PlayerPrefs.GetInt("isFirstDeath") == 0){
						//ACHIEVEMENTS BUTTON
						if(touchPosition.x > 4.42 && touchPosition.y < 2.22 ){

							if(UnderPlayerText.gameObject.GetComponent<SpriteRenderer>().sprite.name.Equals("LowerGrassDeathMenu3")){
								//go to app store
								Application.OpenURL("market://details?id=com.MatthewBurton.NITM2");
							}

							else if(UnderPlayerText.gameObject.GetComponent<SpriteRenderer>().sprite.name.Equals("LowerGrassDeathMenu2")){
								Social.ShowAchievementsUI();
							}

							else{
								GameManager.Instance.ResetPointsToZero ();
								Player.Animator.SetTrigger("PlayerRespawn");
								Player.IsDead = false; 
								Application.LoadLevel(1);
								
								PlayerPrefs.SetInt("isFirstDeath", 0);
							}
						}
						
						//LEADERBOARDS BUTTON
						else if(touchPosition.x < -4.42 && touchPosition.y < 2.22){

							if(UnderPlayerText.gameObject.GetComponent<SpriteRenderer>().sprite.name.Equals("LowerGrassDeathMenu3")){
								//get up
								GameManager.Instance.ResetPointsToZero ();
								Player.Animator.SetTrigger("PlayerRespawn");
								Player.IsDead = false; 
								Application.LoadLevel(1);
								
								PlayerPrefs.SetInt("isFirstDeath", 0);
							}
							
							//AudioSource.PlayClipAtPoint(tickSound, transform.position);
							else if(UnderPlayerText.gameObject.GetComponent<SpriteRenderer>().sprite.name.Equals("LowerGrassDeathMenu2")){
								Social.ShowLeaderboardUI();    
							}

							else{
								GameManager.Instance.ResetPointsToZero ();
								Player.Animator.SetTrigger("PlayerRespawn");
								Player.IsDead = false; 
								Application.LoadLevel(1);
								
								PlayerPrefs.SetInt("isFirstDeath", 0);
							}
						}

						else if(touchPosition.x < 3.33 && touchPosition.x > -3.33 && touchPosition.y < 2.22){
							if(UnderPlayerText.gameObject.GetComponent<SpriteRenderer>().sprite.name.Equals("LowerGrassDeathMenu5")){
								UnderPlayerText.gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("LowerGrassDeathMenu2", typeof(Sprite)) as Sprite;
							}

							else{
								GameManager.Instance.ResetPointsToZero ();
								Player.Animator.SetTrigger("PlayerRespawn");    
								Player.IsDead = false; 
								Application.LoadLevel(1);
								
								PlayerPrefs.SetInt("isFirstDeath", 0); 
							}
						}    

						else{  
							GameManager.Instance.ResetPointsToZero ();
							Player.Animator.SetTrigger("PlayerRespawn");    
							Player.IsDead = false; 
							Application.LoadLevel(1);
							
							PlayerPrefs.SetInt("isFirstDeath", 0);  
						}
					}

					//Set playerPrefs Previous HighScore
					//PlayerPrefs.SetInt("previousHighScore4", PlayerPrefs.GetInt("currentHighScore"));

					else{
						GameManager.Instance.ResetPointsToZero ();
						Player.Animator.SetTrigger("PlayerRespawn");
						Player.IsDead = false; 
						Application.LoadLevel(1);
					
						PlayerPrefs.SetInt("isFirstDeath", 0);
					}
				}
			}
		}
	}
}