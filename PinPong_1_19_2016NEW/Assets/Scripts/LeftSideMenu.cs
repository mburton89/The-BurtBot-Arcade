using UnityEngine;
using System.Collections;

public class LeftSideMenu : MonoBehaviour {

	public MenuSprite leftMenuSprite;
	public GameObject middleMenuSprite;
	public BallDispenser ballDispenser;
	public MainMenu mainMenu;
	public AudioClip Bleep;
	public AudioClip startUp;
	public GameManager gameManager;
	public Achievements achievements;
	
	public void Start(){
		mainMenu = FindObjectOfType<MainMenu>();
		gameManager = FindObjectOfType<GameManager>();
		gameManager.leftSideMenu = FindObjectOfType<LeftSideMenu>();
		//ballDispenser.DisplayBallDispenser();

		//PlayerPrefs.SetInt("hasSeenHowToPlay", 0);

		if(AudioListener.volume == 0){
			leftMenuSprite.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("LeftSideMenuMuted", typeof(Sprite)) as Sprite;
		}
		
		if(PlayerPrefs.GetInt("hasSeenHowToPlay") != 1){ 
			waitSecondsToHideHowToPlayMenu(5);  
		}

		AudioSource.PlayClipAtPoint(startUp, transform.position);    
	}  
	
	public void Update(){
		HandleKeyboard();  
		HandleUserTouches();    
	} 
	
	private void HandleKeyboard(){
		if (Input.GetKeyDown(KeyCode.Q)){
			if(middleMenuSprite.GetComponent<SpriteRenderer>().enabled == false){  
				DisplayExitMenu();
				//DisplayRateMenu();
			}else{
				HideExitMenu();
			}
		}else if (Input.GetKeyDown(KeyCode.M)){ 
			if(AudioListener.volume == 1){
				MuteGame();
			}else{   
				UnmuteGame();
			}  
		}else if (Input.GetKeyDown(KeyCode.H)){
			if(middleMenuSprite.GetComponent<SpriteRenderer>().enabled == false){
				DisplayHowToPlayMenu();
			}else{
				HideHowToPlayMenu();
			}
		}else if (Input.GetKeyDown(KeyCode.Y)){
			if(middleMenuSprite.GetComponent<SpriteRenderer>().sprite.name.Equals("ExitMenu")){
				ReturnToMainMenu();
			}else if(middleMenuSprite.GetComponent<SpriteRenderer> ().sprite.name.Equals ("HowToPlayMenu")){
				HideHowToPlayMenu();
			}
		}else if (Input.GetKeyDown(KeyCode.N)){
			if(middleMenuSprite.GetComponent<SpriteRenderer>().sprite.name.Equals("ExitMenu")){
				HideExitMenu();
			}else if(middleMenuSprite.GetComponent<SpriteRenderer> ().sprite.name.Equals ("HowToPlayMenu")){
				HideHowToPlayMenu();
			}  
		}
	}

	public void HandleUserTouches(){
		for (int i = 0; i < Input.touchCount; i++){
			Touch touch = Input.GetTouch(i);
			if (touch.phase == TouchPhase.Began){
				Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
				if(touchPosition.x < -2 && touchPosition.y < 1.38 && touchPosition.y > .55){ 
					if(AudioListener.volume == 1){
						MuteGame();
					}else{   
						UnmuteGame();
					}  
				}else if(touchPosition.x < -2 && touchPosition.y < .47 && touchPosition.y > -.55){ 
					if(middleMenuSprite.GetComponent<SpriteRenderer>().enabled == false){
						DisplayExitMenu();
					}else{
						HideExitMenu();
					}
				}else if(touchPosition.x < -2 && touchPosition.y < .65 && touchPosition.y > -1.38){ 
					if(middleMenuSprite.GetComponent<SpriteRenderer>().enabled == false){
						DisplayHowToPlayMenu();
					}else{
						HideHowToPlayMenu();
					}
				}else if(touchPosition.x > -1.83 && touchPosition.x < 0.247 && touchPosition.y < .47 && touchPosition.y > -.55){ 
					if(middleMenuSprite.GetComponent<SpriteRenderer>().sprite.name.Equals("ExitMenu")){
						ReturnToMainMenu();
					}else if(middleMenuSprite.GetComponent<SpriteRenderer>().sprite.name.Equals("RateMenu")){
						PlayerPrefs.SetInt("hasRatedGame", 1 ); 
						achievements.unlockPinPongerAchievement();
						Application.OpenURL("market://details?id=com.MatthewBurton.TwoPlayersOnly");
						HideExitMenu();
					}
				}else if(touchPosition.x > 0.35 && touchPosition.x < 1.83 && touchPosition.y < .47 && touchPosition.y > -.55){ 
					if(middleMenuSprite.GetComponent<SpriteRenderer>().sprite.name.Equals("ExitMenu") ||
					   middleMenuSprite.GetComponent<SpriteRenderer>().sprite.name.Equals("RateMenu")){
						HideExitMenu();
					}
				}
			}
		}
	}

	public void DisplayExitMenu(){
		AudioSource.PlayClipAtPoint(Bleep, transform.position);
		ballDispenser.HideBallDispenser();
		gameManager.HideEmoji();
		middleMenuSprite.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ExitMenu", typeof(Sprite)) as Sprite;
		middleMenuSprite.GetComponent<SpriteRenderer>().enabled = true;
	}  

	public void HideExitMenu(){
		AudioSource.PlayClipAtPoint(Bleep, transform.position);
		middleMenuSprite.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANK", typeof(Sprite)) as Sprite;
		middleMenuSprite.GetComponent<SpriteRenderer>().enabled = false;
		ballDispenser.DisplayBallDispenser();
		//gameManager.DisplayEmoji();    
	}


	public void DisplayRateMenu(){
		PlayerPrefs.SetInt("adCycle", 1 );
		ballDispenser.HideBallDispenser();
		gameManager.HideEmoji();
		middleMenuSprite.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("RateMenu", typeof(Sprite)) as Sprite;
		middleMenuSprite.GetComponent<SpriteRenderer>().enabled = true;
	}  
	
	public void HideRateMenu(){
		middleMenuSprite.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANK", typeof(Sprite)) as Sprite;
		middleMenuSprite.GetComponent<SpriteRenderer>().enabled = false;
		ballDispenser.DisplayBallDispenser();
		//gameManager.DisplayEmoji();    
	}



	public void MuteGame(){
		AudioListener.volume = 0;
		leftMenuSprite.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("LeftSideMenuMuted", typeof(Sprite)) as Sprite;
	}

	public void UnmuteGame(){
		AudioListener.volume = 1;
		leftMenuSprite.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("LeftSideMenu1", typeof(Sprite)) as Sprite;
		AudioSource.PlayClipAtPoint(Bleep, transform.position);
	}

	public void DisplayHowToPlayMenu(){
		AudioSource.PlayClipAtPoint(Bleep, transform.position);
		ballDispenser.HideBallDispenser();
		middleMenuSprite.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("HowToPlayMenu", typeof(Sprite)) as Sprite;
		middleMenuSprite.GetComponent<SpriteRenderer>().enabled = true;
	}
	
	public void HideHowToPlayMenu(){
		AudioSource.PlayClipAtPoint(Bleep, transform.position);
		middleMenuSprite.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANK", typeof(Sprite)) as Sprite;
		middleMenuSprite.GetComponent<SpriteRenderer>().enabled = false;
		ballDispenser.DisplayBallDispenser();
	}

	public void ReturnToMainMenu(){ 
		HideExitMenu(); 
		Application.LoadLevel(2);
		mainMenu.startUpMainMenu();
		return;
	}

	private void waitSecondsToHideHowToPlayMenu(float seconds){
		StartCoroutine(waitSecondsCo(seconds));
	}
	
	private IEnumerator waitSecondsCo(float seconds){
		ballDispenser.HideBallDispenser();
		middleMenuSprite.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("HowToPlayMenu", typeof(Sprite)) as Sprite;
		middleMenuSprite.GetComponent<SpriteRenderer>().enabled = true;
		yield return new WaitForSeconds (seconds); 
		HideHowToPlayMenu();
		PlayerPrefs.SetInt("hasSeenHowToPlay", 1);
	}
}
