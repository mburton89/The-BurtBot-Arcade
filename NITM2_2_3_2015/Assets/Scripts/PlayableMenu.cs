using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class PlayableMenu : MonoBehaviour{
	
	public static PlayableMenu Instance {get; private set;}  
	public PlayerAi Player {get; private set;}  
	public GUIStyle EmptyTexture;
	public AudioClip tickSound;
	public GameObject Background;  

	//WIP
	public GameObject Monk;
	public GameObject Wizard;
	public GameObject Gentleman;
	public GameObject Robo;

	public GameObject BGSound;  
	
	public BGSound BGSoundObject {get; private set;}    

	public CharacterText CharacterText{get; private set;}           
	//public GameObject CharacterLockedStatus;
	public CharacterLockedStatusClass CharacterLockedStatus{get; private set;}            
	public ThemeLockedStatusClass ThemeLockedStatus{get; private set;} 
	public GameObject LowerGrassMenu;
	public GameObject LowerGrassCover;  

	void OnGUI(){                                       //initially 250
//		if (GUI.Button (new Rect (Screen.width / 2.5f, Screen.height - 250  , Screen.width / 5, Screen.height / 10), "START", EmptyTexture)){ 
//			Application.LoadLevel(3); 
//
//			//WIP
//			PlayerPrefs.SetInt("isFirstDeath", 1);    
//		}                             

		//CLOCK
//		if (GUI.Button (new Rect (Screen.width / 2.5f, Screen.height - 400  , Screen.width / 5, Screen.height / 10), System.DateTime.UtcNow.ToString("HH:mm dd MMMM, yyyy"), EmptyTexture)){ 
//		
//		}

//		if (GUI.Button (new Rect (Screen.width / 2.5f, Screen.height / 8 , Screen.width / 5, Screen.height / 10), "START", EmptyTexture)){ 
//			Application.LoadLevel(1);		
//		}
//
//		if (PlayerPrefs.GetInt ("currentHighScore") > 10) {
//			if (GUI.Button (new Rect (Screen.width / 2.5f, Screen.height / 6 , Screen.width / 5, Screen.height / 10), "TOP HAT", EmptyTexture)){ 
//				Application.LoadLevel(1);		
//			}
//		}

		//FOR LEADERBOARDS
//		if (GUI.Button (new Rect (Screen.width / 2.5f, Screen.height - 180, Screen.width / 5, Screen.height / 10), "LEADERBOARDS", EmptyTexture)) {
//			Social.ShowLeaderboardUI();
//		}

//		if (GUI.Button (new Rect (Screen.width / 2.5f, Screen.height / 2, Screen.width / 5, Screen.height / 10), "HOW TO PLAY", EmptyTexture)) {
//			Application.LoadLevel(3);		
//		}
	}
		
	public void Awake(){  
		Instance = this;            
	}
	
	public void Start(){

//		PlayerPrefs.SetInt("hasMadePurchase",0);               
//		PlayerPrefs.SetInt("displayThankYou",0);                        


		PlayerPrefs.SetInt("hasMadePurchase",1);
		

		if(Application.loadedLevel == 0){  
			PlayGamesPlatform.Activate();
			Social.localUser.Authenticate((bool success) =>{      

				if(success){
					Debug.Log("Succesful Login");
				}else{
					Debug.Log("Login Fail");
				}
			});
			Player = FindObjectOfType<PlayerAi> ();	//Need to put at begining?	  

   
		}

		if(Application.loadedLevel == 4){
			Player = FindObjectOfType<PlayerAi> ();
			Debug.Log("Player Character: " + Player.gameObject.name);
		}

		BGSoundObject = FindObjectOfType<BGSound> ();      
		CharacterText = FindObjectOfType<CharacterText> ();

		CharacterLockedStatus = FindObjectOfType<CharacterLockedStatusClass> ();  
		ThemeLockedStatus = FindObjectOfType<ThemeLockedStatusClass> ();

		if(PlayerPrefs.GetInt("hasMadePurchase") == 1){
			CharacterLockedStatus.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANKButton", typeof(Sprite)) as Sprite;
			ThemeLockedStatus.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANKButton", typeof(Sprite)) as Sprite;
		}

		determineLowerGrassStatus();    

//		if(BGSoundObject.audio.clip.name.Equals("NightSound")){  
//			ThemeText.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANKButton 1", typeof(Sprite)) as Sprite;
//		}           
	}
	
	public void Update(){
		HandleUserTouches();  
		HandleKeyboard();        
	}

	private void HandleUserTouches(){
		for (int i = 0; i < Input.touchCount; i++){
			Touch touch = Input.GetTouch(i);
			if (touch.phase == TouchPhase.Began && touch.tapCount == 1){
				Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);  

				//CharacterSelction
				if(touchPosition.x > -4.5 && touchPosition.x < -2.2 && touchPosition.y > 11.4 && touchPosition.y < 13.8){
					ToggleCharacterToRight();      
				}

				else if(touchPosition.x > -13.3 && touchPosition.x < -11 && touchPosition.y > 11.4 && touchPosition.y < 13.8){
					ToggleCharacterToLeft();                       
				}

				else if(touchPosition.x > 11.1 && touchPosition.x < 13.7 && touchPosition.y > 11.4 && touchPosition.y < 13.8){
					ToggleThemeSoundToRight();
				}

				else if(touchPosition.x > 2.25 && touchPosition.x < 4.7 && touchPosition.y > 11.4 && touchPosition.y < 13.8){
					ToggleThemeSoundToLeft();
				}

				if(LowerGrassMenu.GetComponent<SpriteRenderer>().sprite.name.Equals("LowerGrassUnlockButton")){
					if(touchPosition.x > -3.8 && touchPosition.x < 3.8 && touchPosition.y < 3.7){
						Application.LoadLevel(6);	                    
					}
				}

				else{
					
					//START BUTTON. PREVIOUSLY Achievement BUTTON
					if(touchPosition.x > 4.42 && touchPosition.y < 2.22 ){
						//AudioSource.PlayClipAtPoint(tickSound, transform.position);
						//Social.ShowAchievementsUI();

						PlayerPrefs.SetInt("isFirstDeath", 1);
						Application.LoadLevel(3);
					}
					
//					//HowToButton. Previously Rate BUTTON
//					else if(touchPosition.x > -4 && touchPosition.x < 4 && touchPosition.y < 2.22){
//						//AudioSource.PlayClipAtPoint(tickSound, transform.position);
//						
//						//ANDROID
//						//Application.OpenURL("market://details?id=com.MatthewBurton.NITM2");
//						Application.LoadLevel(5);    
//					}
					
					//ABOUT BUTTON. PREVIOUSLY LEADERBOARDS BUTTON
					else if(touchPosition.x < -4.42 && touchPosition.y < 2.22){
						//AudioSource.PlayClipAtPoint(tickSound, transform.position);
						//Social.ShowLeaderboardUI();

						Application.LoadLevel(5);        
					}

//					else if(touchPosition.x > -1 && touchPosition.x < 1 && touchPosition.y > 17.2){
//						PlayerPrefs.SetInt("hasMadePurchase",0);
//						PlayerPrefs.SetInt("displayThankYou",0);   	                      
//					}
					
//		
//					else if(touchPosition.x > -4 && touchPosition.x < 4 && touchPosition.y > 2.23 && touchPosition.y < 4.5){
//						PlayerPrefs.SetInt("isFirstDeath", 1);
//						Application.LoadLevel(3);	   
//					}
					
					else{ 
						//nuffin
					}
				}
			}
		}
	}

	//WIP
	private void HandleKeyboard(){

		if(Input.GetKeyDown(KeyCode.Alpha8)){    
				
//			if(Monk.activeInHierarchy){
//				Monk.SetActive(false);
//				Wizard.SetActive(true);
//				CharacterText.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("WizardText", typeof(Sprite)) as Sprite;
//			}
//				
//			else if(Wizard.activeInHierarchy){
//				Wizard.SetActive(false);  
//				Gentleman.SetActive(true);
//				CharacterText.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("GentlemanText", typeof(Sprite)) as Sprite;
//			}
//
//			else if(Gentleman.activeInHierarchy){     
//				Gentleman.SetActive(false);          
//				Robo.SetActive(true);
//				CharacterText.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("RoboText", typeof(Sprite)) as Sprite;
//			}
//
//			else if(Robo.activeInHierarchy){  
//				Robo.SetActive(false);                          
//				Monk.SetActive(true);
//				CharacterText.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("MonkText", typeof(Sprite)) as Sprite;
//			}

			
			//WIP

			if(Player.gameObject.name.Equals("Player")){
				Player.gameObject.SetActive(false);
				Wizard.SetActive(true);
				Player = FindObjectOfType<PlayerAi> (); 
				CharacterText.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("WizardText", typeof(Sprite)) as Sprite;

				CharacterLockedStatus.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANKButton", typeof(Sprite)) as Sprite;

				determineCharacterLockedStatus();

			}
			
			else if(Player.gameObject.name.Equals("SuperNinja")){
				Player.gameObject.SetActive(false);
				Gentleman.SetActive(true); 
				Player = FindObjectOfType<PlayerAi> ();  
				CharacterText.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("GentlemanText", typeof(Sprite)) as Sprite;

				determineCharacterLockedStatus();

			}
			
			else if(Player.gameObject.name.Equals("Punch")){
				Player.gameObject.SetActive(false);
				Robo.SetActive(true);
				Player = FindObjectOfType<PlayerAi> ();
				CharacterText.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("RoboText", typeof(Sprite)) as Sprite;

				determineCharacterLockedStatus();  

			}
			
			else if(Player.gameObject.name.Equals("Robo")){  
				Player.gameObject.SetActive(false);                     
				Monk.SetActive(true);
				Player = FindObjectOfType<PlayerAi> ();
				CharacterText.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("MonkText", typeof(Sprite)) as Sprite;

				CharacterLockedStatus.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANKButton", typeof(Sprite)) as Sprite;
				determineLowerGrassStatus();    
			}
		}

		else if(Input.GetKeyDown(KeyCode.Alpha1)){

			if(BGSoundObject.audio.clip.name.Equals("Wind")){
				BGSoundObject.audio.clip = (AudioClip)Resources.Load("NightSound", typeof(AudioClip)) as AudioClip;
				BGSoundObject.audio.Play();  

				determineThemeLockedStatus();

			}

			else if(BGSoundObject.audio.clip.name.Equals("NightSound")){
				BGSoundObject.audio.clip = (AudioClip)Resources.Load("RainSound", typeof(AudioClip)) as AudioClip;
				BGSoundObject.audio.Play();         

				determineThemeLockedStatus();

			}

			else if(BGSoundObject.audio.clip.name.Equals("RainSound")){
				BGSoundObject.audio.clip = (AudioClip)Resources.Load("SpaceSound", typeof(AudioClip)) as AudioClip;
				BGSoundObject.audio.Play();  

				determineThemeLockedStatus();

			}

			else if(BGSoundObject.audio.clip.name.Equals("SpaceSound")){
				BGSoundObject.audio.clip = (AudioClip)Resources.Load("Wind", typeof(AudioClip)) as AudioClip;
				BGSoundObject.audio.Play();     

				ThemeLockedStatus.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANKButton", typeof(Sprite)) as Sprite;
				determineLowerGrassStatus();
			}
		}  

		else if(Input.GetKeyDown(KeyCode.J)){
			Application.LoadLevel(6);      
		}
	}

	private void ToggleCharacterToRight(){      
//		if(Monk.activeInHierarchy){
//			Monk.SetActive(false);
//			Wizard.SetActive(true);
//			CharacterText.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("WizardText", typeof(Sprite)) as Sprite;
//		}
//		
//		else if(Wizard.activeInHierarchy){
//			Wizard.SetActive(false);  
//			Gentleman.SetActive(true);
//			CharacterText.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("GentlemanText", typeof(Sprite)) as Sprite;
//		}
//		
//		else if(Gentleman.activeInHierarchy){     
//			Gentleman.SetActive(false);
//			Robo.SetActive(true);
//			CharacterText.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("RoboText", typeof(Sprite)) as Sprite;
//		}
//		
//		else if(Robo.activeInHierarchy){  
//			Robo.SetActive(false);
//			Monk.SetActive(true);
//			CharacterText.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("MonkText", typeof(Sprite)) as Sprite;
//		}

		if(Player.gameObject.name.Equals("Player")){
			Player.gameObject.SetActive(false);
			Wizard.SetActive(true);
			Player = FindObjectOfType<PlayerAi> (); 
			CharacterText.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("WizardText", typeof(Sprite)) as Sprite;

			determineCharacterLockedStatus();

		}
		
		else if(Player.gameObject.name.Equals("SuperNinja")){
			Player.gameObject.SetActive(false);
			Gentleman.SetActive(true); 
			Player = FindObjectOfType<PlayerAi> ();  
			CharacterText.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("GentlemanText", typeof(Sprite)) as Sprite;

			determineCharacterLockedStatus();

		}
		
		else if(Player.gameObject.name.Equals("Punch")){
			Player.gameObject.SetActive(false);
			Robo.SetActive(true);
			Player = FindObjectOfType<PlayerAi> ();
			CharacterText.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("RoboText", typeof(Sprite)) as Sprite;

			determineCharacterLockedStatus();

		}
		
		else if(Player.gameObject.name.Equals("Robo")){  
			Player.gameObject.SetActive(false);                     
			Monk.SetActive(true);
			Player = FindObjectOfType<PlayerAi> ();
			CharacterText.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("MonkText", typeof(Sprite)) as Sprite;

			CharacterLockedStatus.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANKButton", typeof(Sprite)) as Sprite;
			determineLowerGrassStatus(); 
		}
	}
	
	private void ToggleCharacterToLeft(){  
//		if(Monk.activeInHierarchy){
//			Monk.SetActive(false);
//			Robo.SetActive(true);
//			CharacterText.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("RoboText", typeof(Sprite)) as Sprite;
//		}
//		
//		else if(Wizard.activeInHierarchy){  
//			Wizard.SetActive(false);  
//			Monk.SetActive(true);  
//			CharacterText.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("MonkText", typeof(Sprite)) as Sprite;
//		}
//		
//		else if(Gentleman.activeInHierarchy){     
//			Gentleman.SetActive(false);
//			Wizard.SetActive(true);
//			CharacterText.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("WizardText", typeof(Sprite)) as Sprite;
//		}
//		
//		else if(Robo.activeInHierarchy){  
//			Robo.SetActive(false);
//			Gentleman.SetActive(true);
//			CharacterText.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("GentlemanText", typeof(Sprite)) as Sprite;
//		}

		if(Player.gameObject.name.Equals("Player")){
			Player.gameObject.SetActive(false);
			Robo.SetActive(true);
			Player = FindObjectOfType<PlayerAi> ();
			CharacterText.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("RoboText", typeof(Sprite)) as Sprite;

			determineCharacterLockedStatus();

		}
		
		else if(Player.gameObject.name.Equals("SuperNinja")){
			Player.gameObject.SetActive(false);                     
			Monk.SetActive(true);
			Player = FindObjectOfType<PlayerAi> ();
			CharacterText.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("MonkText", typeof(Sprite)) as Sprite;

			CharacterLockedStatus.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANKButton", typeof(Sprite)) as Sprite;
			determineLowerGrassStatus(); 
		}
		
		else if(Player.gameObject.name.Equals("Punch")){
			Player.gameObject.SetActive(false);
			Wizard.SetActive(true);
			Player = FindObjectOfType<PlayerAi> (); 
			CharacterText.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("WizardText", typeof(Sprite)) as Sprite;

			determineCharacterLockedStatus();

		}
		
		else if(Player.gameObject.name.Equals("Robo")){  
			Player.gameObject.SetActive(false);
			Gentleman.SetActive(true); 
			Player = FindObjectOfType<PlayerAi> ();  
			CharacterText.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("GentlemanText", typeof(Sprite)) as Sprite;

			determineCharacterLockedStatus();

		}
	}
	
	private void ToggleThemeSoundToRight(){
		if(BGSoundObject.audio.clip.name.Equals("Wind")){
			BGSoundObject.audio.clip = (AudioClip)Resources.Load("NightSound", typeof(AudioClip)) as AudioClip;
			BGSoundObject.audio.Play();  

			determineThemeLockedStatus();

		}
			
		else if(BGSoundObject.audio.clip.name.Equals("NightSound")){
			BGSoundObject.audio.clip = (AudioClip)Resources.Load("RainSound", typeof(AudioClip)) as AudioClip;
			BGSoundObject.audio.Play();  

			determineThemeLockedStatus();

		}
			
		else if(BGSoundObject.audio.clip.name.Equals("RainSound")){
			BGSoundObject.audio.clip = (AudioClip)Resources.Load("SpaceSound", typeof(AudioClip)) as AudioClip;
			BGSoundObject.audio.Play(); 

			determineThemeLockedStatus();

		}
			
		else if(BGSoundObject.audio.clip.name.Equals("SpaceSound")){
			BGSoundObject.audio.clip = (AudioClip)Resources.Load("Wind", typeof(AudioClip)) as AudioClip;
			BGSoundObject.audio.Play();   

			ThemeLockedStatus.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANKButton", typeof(Sprite)) as Sprite;
			determineLowerGrassStatus();
			
		}
	}

	private void ToggleThemeSoundToLeft(){
		if(BGSoundObject.audio.clip.name.Equals("Wind")){
			BGSoundObject.audio.clip = (AudioClip)Resources.Load("SpaceSound", typeof(AudioClip)) as AudioClip;
			BGSoundObject.audio.Play(); 

			determineThemeLockedStatus();        

		}
		
		else if(BGSoundObject.audio.clip.name.Equals("NightSound")){
			BGSoundObject.audio.clip = (AudioClip)Resources.Load("Wind", typeof(AudioClip)) as AudioClip;
			BGSoundObject.audio.Play(); 

			ThemeLockedStatus.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANKButton", typeof(Sprite)) as Sprite;
			determineLowerGrassStatus();
			
		}
		
		else if(BGSoundObject.audio.clip.name.Equals("RainSound")){
			BGSoundObject.audio.clip = (AudioClip)Resources.Load("NightSound", typeof(AudioClip)) as AudioClip;
			BGSoundObject.audio.Play(); 

			determineThemeLockedStatus();

		}
		
		else if(BGSoundObject.audio.clip.name.Equals("SpaceSound")){
			BGSoundObject.audio.clip = (AudioClip)Resources.Load("RainSound", typeof(AudioClip)) as AudioClip;
			BGSoundObject.audio.Play();   

			determineThemeLockedStatus();

		}
	}

	private void determineCharacterLockedStatus(){
		if(PlayerPrefs.GetInt("hasMadePurchase") == 1){
			CharacterLockedStatus.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANKButton", typeof(Sprite)) as Sprite;
			LowerGrassCover.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("LowerGrassCover", typeof(Sprite)) as Sprite;
		}else{
			CharacterLockedStatus.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("LockedLabel", typeof(Sprite)) as Sprite;
			LowerGrassCover.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANKButton", typeof(Sprite)) as Sprite;
		}      

		determineLowerGrassStatus();   

	}

	private void determineThemeLockedStatus(){
		if(PlayerPrefs.GetInt("hasMadePurchase") == 1){
			ThemeLockedStatus.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANKButton", typeof(Sprite)) as Sprite;
		}else{
			ThemeLockedStatus.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("LockedLabel", typeof(Sprite)) as Sprite;
		}

		determineLowerGrassStatus();

	}

	private void determineLowerGrassStatus(){   
		if(PlayerPrefs.GetInt("hasMadePurchase") == 1){  
			LowerGrassMenu.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("MainMenu2", typeof(Sprite)) as Sprite;
		}else{  
			if(ThemeLockedStatus.GetComponent<SpriteRenderer>().sprite.name.Equals("LockedLabel")
			   ||CharacterLockedStatus.GetComponent<SpriteRenderer>().sprite.name.Equals("LockedLabel")){
				LowerGrassMenu.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("LowerGrassUnlockButton", typeof(Sprite)) as Sprite;
			}else{    
				LowerGrassMenu.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("MainMenu2", typeof(Sprite)) as Sprite;
			}  
		}
	}
}