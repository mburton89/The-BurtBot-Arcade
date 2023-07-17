using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
using UnityEngine.Advertisements;
using Soomla;
using Soomla.Store;

public class MainMenu : MonoBehaviour { 

	public GameManager gameManager;
	public MenuSprite MenuSprite;
	public GameObject pinPongLogo;   
	public GameObject pinPongTitle; 
	public OpponentAI opponent;  
	public AudioClip Bleep;    
	public AudioClip AppStartSound;   
	public Achievements achievements;   

	public GameObject GooglePlayIcon;
    public GameObject PipSpinAd;

    private const string AD_UNIT_ID = "ca-app-pub-7408152150396026/1699749598";
    //private AdMobPlugin admob;

	void Start () {

		PlayerPrefs.SetInt("adCycle", 2 );    

		AudioSource.PlayClipAtPoint(AppStartSound, transform.position);

		Advertisement.Initialize("50134");
		
		if(Application.loadedLevel == 0){ 
		
			PlayGamesPlatform.Activate();
			Social.localUser.Authenticate((bool success) =>{
				if(success){
					//Debug.Log("Succesful Login");
					GooglePlayIcon.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("games_achievements_green", typeof(Sprite)) as Sprite;
				}else{
					//Debug.Log("Login Fail");
				}
			});

            determinePipSpinAd();
		}

		gameManager = FindObjectOfType<GameManager> ();
		//MenuSprite = FindObjectOfType<MenuSprite> ();
		//pinPongLogo = FindObjectOfType<PinPongLogo> ();
		//pinPongTitle = FindObjectOfType<PinPongTitle> ();  
		opponent = FindObjectOfType<OpponentAI> ();  
        
        
	}   

	void Update () {
        if(Application.loadedLevel != 1){
            if(Application.loadedLevel == 2) {
                HandleKeyboard ();     
	            HandleUserTouches (); 
            }else {
                if(Application.loadedLevel != 1){  
                    if(PipSpinAd.activeInHierarchy == true) {
                        if(Application.loadedLevel == 0) {
                             HandlePipSpinAdTouches();
                        }
                    }else {
                        HandleKeyboard ();     
			            HandleUserTouches ();    
                    }
		        } 
            }
        }
	}

	public void HandleKeyboard (){

		if (MenuSprite.GetComponent<SpriteRenderer> ().sprite.name.Equals ("MainMenu1")) {
			if (Input.GetKeyDown(KeyCode.Alpha1)){
				displayOnePlayerMenu();
			}else if (Input.GetKeyDown(KeyCode.Alpha2)){  
				displayTwoPlayerMenu();       
			}else if (Input.GetKeyDown(KeyCode.Alpha3)){  
				displayAboutMenu();
                //goToPipSpinAd();  
			}
			return;
		}

		else if (MenuSprite.GetComponent<SpriteRenderer> ().sprite.name.Equals ("OnePlayerMenu")) {
			if (Input.GetKeyDown(KeyCode.Alpha1)){
				startGame(true, 9, 13, .6f, .38f);
			}else if (Input.GetKeyDown(KeyCode.Alpha2)){
				startGame(true, 11, 16, .5f, .3f);
			}else if (Input.GetKeyDown(KeyCode.Alpha3)){
				startGame(true, 13.2f, 19.5f, .405f, .23f);
			}else if (Input.GetKeyDown(KeyCode.Alpha4)){  
				startGame(true, 15.2f, 23, .348f, .19f);
			}else if (Input.GetKeyDown(KeyCode.Alpha5)){
				displayMainMenu();
			}
			return;
		}

		else if (MenuSprite.GetComponent<SpriteRenderer> ().sprite.name.Equals ("TwoPlayerMenu")) {
			if (Input.GetKeyDown(KeyCode.Alpha1)){
				startGame(false, 9, 13);
			}else if (Input.GetKeyDown(KeyCode.Alpha2)){
				startGame(false, 11, 16);
			}else if (Input.GetKeyDown(KeyCode.Alpha3)){
				startGame(false, 13.2f, 19.5f);
			}else if (Input.GetKeyDown(KeyCode.Alpha4)){
				startGame(false, 15.2f, 23);
			}else if (Input.GetKeyDown(KeyCode.Alpha5)){
				displayMainMenu(); 
			}
			return;
		}

		else if (MenuSprite.GetComponent<SpriteRenderer> ().sprite.name.Equals ("AboutMenu")) {
			if (Input.GetKeyDown(KeyCode.Alpha1)){
				//
			}else if (Input.GetKeyDown(KeyCode.Alpha2)){  
				//
			}else if (Input.GetKeyDown(KeyCode.Alpha3)){  
				displayMainMenu();
			}
			return;
		}

        else if (MenuSprite.GetComponent<SpriteRenderer> ().sprite.name.Equals ("PipSpinAd")) {
			if (Input.GetKeyDown(KeyCode.Alpha1)){
				//
			}else if (Input.GetKeyDown(KeyCode.Alpha2)){  
				displayMainMenu();
			}
			return;
		}
	}

	private void HandleUserTouches(){        


		if (MenuSprite.GetComponent<SpriteRenderer> ().sprite.name.Equals ("MainMenu1")) {  
			//if(Time.timeScale != 0){
				for (int i = 0; i < Input.touchCount; i++){    
					Touch touch = Input.GetTouch(i);    
					if (touch.phase == TouchPhase.Began){
						Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
						if(touchPosition.x > -2.55 && touchPosition.x < 2.55){       
							if(touchPosition.y > 0.92 && touchPosition.y < 2){   
								displayTwoPlayerMenu();
							}else if(touchPosition.y > -.1 && touchPosition.y < 0.79){   
								displayOnePlayerMenu();
							}else if(touchPosition.y > -2.61 && touchPosition.y < -1.55){   
								//displayAboutMenu();
								goToPinPongPage();
							}else if(touchPosition.y > -1.43 && touchPosition.y < -.38){   
								//Social.ShowAchievementsUI();    
								SoomlaStore.BuyMarketItem(PinPongAssets.REMOVE_ADS_ID, "Remove Ads");        
							}else if(touchPosition.x > -.6 && touchPosition.x < .6 && touchPosition.y < -3.3  && touchPosition.y > -4.27){  

								if(Social.localUser.authenticated){
									Social.ShowAchievementsUI();  
								}else{
									//Social.localUser.Authenticate((bool success) =>{}); 
									Social.localUser.Authenticate((bool success) =>{
										if(success){
											//Debug.Log("Succesful Login");
											GooglePlayIcon.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("games_achievements_green", typeof(Sprite)) as Sprite;
										}else{
											//Debug.Log("Login Fail");
										}
									});
								}
							}
								return;            
							}   
						}    
					}
			//}
			}  
		
		if (MenuSprite.GetComponent<SpriteRenderer> ().sprite.name.Equals ("OnePlayerMenu")) {
			//if(Time.timeScale != 0){
				for (int i = 0; i < Input.touchCount; i++){
					Touch touch = Input.GetTouch(i);
					if (touch.phase == TouchPhase.Began){
						Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
						if(touchPosition.x > -2.55 && touchPosition.x < 2.55){   
							if(touchPosition.y > 1.21 && touchPosition.y < 2){   
								startGame(true, 9, 13, .6f, .38f);
							}else if(touchPosition.y > 0.25 && touchPosition.y < 1.05){   
								startGame(true, 11, 16, .5f, .3f);
							}else if(touchPosition.y > -0.68 && touchPosition.y < 0.07){   
								//startGame(true, 13, 19, .42f, .25f);
								startGame(true, 13.2f, 19.5f, .405f, .23f);
							}else if(touchPosition.y > -1.65 && touchPosition.y < -0.85){   
								//startGame(true, 14.5f, 21, .38f, .2f);
								//startGame(true, 16, 23.5f, .34f, .185f);
								startGame(true, 15.2f, 23, .348f, .19f);
							}else if(touchPosition.y > -2.6 && touchPosition.y < -1.81){   
								displayMainMenu();
							}  
						}
					}
				}
			//}
		}
		
		if (MenuSprite.GetComponent<SpriteRenderer> ().sprite.name.Equals ("TwoPlayerMenu")) {
			//if(Time.timeScale != 0){
				for (int i = 0; i < Input.touchCount; i++){
					Touch touch = Input.GetTouch(i);
					if (touch.phase == TouchPhase.Began){
						Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
						if(touchPosition.x > -2.55 && touchPosition.x < 2.55){   
							if(touchPosition.y > 1.21 && touchPosition.y < 2){   
								startGame(false, 9, 13);
							}else if(touchPosition.y > 0.25 && touchPosition.y < 1.05){   
								startGame(false, 11, 16);
							}else if(touchPosition.y > -0.68 && touchPosition.y < 0.07){   
								//startGame(false, 13, 19);
								startGame(false, 13.2f, 19.5f);
							}else if(touchPosition.y > -1.65 && touchPosition.y < -0.85){   
								//startGame(false, 14.5f, 21);
								//startGame(false, 16, 23.5f);
								startGame(false, 15.2f, 23);
							}else if(touchPosition.y > -2.6 && touchPosition.y < -1.81){   
								displayMainMenu();
							}
						}
					}
				}
			//}
		}
	

	if (MenuSprite.GetComponent<SpriteRenderer> ().sprite.name.Equals ("AboutMenu")) {
		//if(Time.timeScale != 0){
			for (int i = 0; i < Input.touchCount; i++){
				Touch touch = Input.GetTouch(i);
				if (touch.phase == TouchPhase.Began){
					Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
					if(touchPosition.x > -2.55 && touchPosition.x < 2.55){   
						if(touchPosition.y > 0.09 && touchPosition.y < 0.845){   
							goToPinPongPage();
						}else if(touchPosition.y > -2.3 && touchPosition.y < -1.5){   
							goToNinjevadePage();
						}else if(touchPosition.y > -4.6 && touchPosition.y < -3.9){   
							startUpMainMenu();
						}else if(touchPosition.y > 3.46 && touchPosition.y < 4.08 && touchPosition.x > 0.06 && touchPosition.x < 3.2){   
							goToMyTwitter();   
						}
					}
				}
			}
		}
	//}
    if (MenuSprite.GetComponent<SpriteRenderer> ().sprite.name.Equals ("PipSpinAd")) {
		//if(Time.timeScale != 0){
			for (int i = 0; i < Input.touchCount; i++){
				Touch touch = Input.GetTouch(i);
				    if (touch.phase == TouchPhase.Began){
					    Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
				    if(touchPosition.x < -1.4 && touchPosition.x > -3  && touchPosition.y < -1 && touchPosition.y > -2.35){
                        displayMainMenu();
                     }else if(touchPosition.x < 3 && touchPosition.x > 1.4  && touchPosition.y < -1 && touchPosition.y > -2.35){
                        // goToPipSpinPage();

                    }
				}
			}
		}
}

    public void HandlePipSpinAdTouches (){
        for (int i = 0; i < Input.touchCount; i++){    
			Touch touch = Input.GetTouch(i);    
			if (touch.phase == TouchPhase.Began){
				Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
				if(touchPosition.x < -1.1 && touchPosition.x > -2.5  && touchPosition.y < -1.5 && touchPosition.y > -2.75){
                    PipSpinAd.SetActive(false);
                }else if(touchPosition.x < 2.5 && touchPosition.x > 1.2  && touchPosition.y < -1.5 && touchPosition.y > -2.75){
                    Application.OpenURL("market://details?id=com.MatthewBurton.PipSpin");
                    PipSpinAd.SetActive(false);
                }
            }
        }
    }

	public void startGame(bool isSinglePlayer, 
	                      float slowBallSpeed, 
	                      float fastBallSpeed){
		gameManager.isSinglePlayer = isSinglePlayer;
		gameManager.slowBallSpeed = slowBallSpeed;
		gameManager.fastBallSpeed = fastBallSpeed;
		Application.LoadLevel (1);
		HideMenu();
		//gameManager.opponent = FindObjectOfType<OpponentAI> ();
	}

	public void startGame(bool isSinglePlayer, 
	                      float slowBallSpeed, 
	                      float fastBallSpeed,
	                      float slowTimeToWait,
	                      float fastTimeToWait){
		gameManager.isSinglePlayer = isSinglePlayer;
		gameManager.slowBallSpeed = slowBallSpeed;
		gameManager.fastBallSpeed = fastBallSpeed;
		opponent.slowTimeToWait = slowTimeToWait;
		opponent.fastTimeToWait = fastTimeToWait;
		Application.LoadLevel (1);
		HideMenu();
	}

	public void displayOnePlayerMenu(){
		hidePingPongLogoAndTitle();
		AudioSource.PlayClipAtPoint(Bleep, transform.position);
		MenuSprite.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("OnePlayerMenu", typeof(Sprite)) as Sprite;
	}

	public void displayTwoPlayerMenu(){
		hidePingPongLogoAndTitle();
		AudioSource.PlayClipAtPoint(Bleep, transform.position);  
		MenuSprite.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("TwoPlayerMenu", typeof(Sprite)) as Sprite;
	}

	public void displayMainMenu(){ 
		AudioSource.PlayClipAtPoint(Bleep, transform.position);
		MenuSprite.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("MainMenu1", typeof(Sprite)) as Sprite;
		displayPingPongLogoAndTitle();
	}

//	public void displaySettingsMenu(){
//		AudioSource.PlayClipAtPoint(Bleep, transform.position);
//		MenuSprite.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("AboutMenu", typeof(Sprite)) as Sprite;
//	}

	public void displayAboutMenu(){
		hidePingPongLogoAndTitle();
		AudioSource.PlayClipAtPoint(Bleep, transform.position);
		MenuSprite.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("AboutMenu", typeof(Sprite)) as Sprite;
	}

    public void displayPipSpinAd(){
		//hidePingPongLogoAndTitle();
		//AudioSource.PlayClipAtPoint(Bleep, transform.position);
		//MenuSprite.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("PipSpinAd", typeof(Sprite)) as Sprite;
        SceneManager.LoadScene(3);
	}

    public void goToPipSpinAd() {
        Debug.Log("PIP");
        SceneManager.LoadScene(3);
    }
	
	public void HideMenu(){
		StartCoroutine(HideMenuCo()); 
		gameManager.ResetPointsToFive(false);
	}
	
	private IEnumerator HideMenuCo(){   
		yield return new WaitForSeconds (.05f); 
		MenuSprite.GetComponent<SpriteRenderer>().enabled = false;
		AudioSource.PlayClipAtPoint(Bleep, transform.position);
	}

	public void startUpMainMenu(){
		displayMainMenu();
		MenuSprite.GetComponent<SpriteRenderer>().enabled = true;
	}

	public void goToPinPongPage(){
		achievements.unlockPinPongerAchievement();
		PlayerPrefs.SetInt("hasRatedGame", 1 ); 
		AudioSource.PlayClipAtPoint(Bleep, transform.position);
		Application.OpenURL("market://details?id=com.MatthewBurton.TwoPlayersOnly");
	}	

	public void goToNinjevadePage(){
		achievements.unlockNinjevaderAchievement();
		AudioSource.PlayClipAtPoint(Bleep, transform.position);
		Application.OpenURL("market://details?id=com.MatthewBurton.NITM2");
	}

	public void goToMyTwitter(){
		AudioSource.PlayClipAtPoint(Bleep, transform.position);
		Application.OpenURL("https://twitter.com/MattWBurton");
	}
	
	public void displayPingPongLogoAndTitle(){
		GooglePlayIcon.GetComponent<SpriteRenderer>().enabled = true;
		pinPongLogo.GetComponent<SpriteRenderer>().enabled = true;
		pinPongTitle.GetComponent<SpriteRenderer>().enabled = true;
	}

	public void hidePingPongLogoAndTitle(){
		GooglePlayIcon.GetComponent<SpriteRenderer>().enabled = false;
		pinPongLogo.GetComponent<SpriteRenderer>().enabled = false;
		pinPongTitle.GetComponent<SpriteRenderer>().enabled = false;
	}

    public void determinePipSpinAd() {
        if(PlayerPrefs.GetInt("PipSpinAdCounter") >= 1) {
            if(PlayerPrefs.GetInt("hasMadePurchase") != 1) {
                PipSpinAd.SetActive(true);
            }
            PlayerPrefs.SetInt("PipSpinAdCounter",-5);
        }
        PlayerPrefs.SetInt("PipSpinAdCounter", PlayerPrefs.GetInt("PipSpinAdCounter") + 1);
        Debug.Log("PipSpinAdCounter " + PlayerPrefs.GetInt("PipSpinAdCounter"));
    }
}
