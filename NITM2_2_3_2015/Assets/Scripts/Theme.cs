using UnityEngine;
using System.Collections;

public class Theme: MonoBehaviour{

	//public BGSound BGSoundObject {get; private set;}

	private int themePositionNumber = 1;   

	public void Awake(){

	}

	public void Start(){
		//BGSoundObject = FindObjectOfType<BGSound> ();
	}

	public void Update(){  
		HandleUserTouches();    
		HandleKeyboard();         
	}

	private void HandleKeyboard(){
		if(Application.loadedLevel == 0 || Application.loadedLevel == 4){
			if(Input.GetKeyDown(KeyCode.Alpha1)){
				if(themePositionNumber == 1){
					initiateNightBackground();
					themePositionNumber = 2;
				}else if(themePositionNumber == 2){    
					initiateRainBackground();
					themePositionNumber = 3;
				}else if(themePositionNumber == 3){
					initiateSpaceBackground();
					themePositionNumber = 4;
				}else if(themePositionNumber == 4){  
					initiateSunsetBackground();
					themePositionNumber = 1;
				}
			}  
		}
	}

	private void HandleUserTouches(){
		for (int i = 0; i < Input.touchCount; i++){
			Touch touch = Input.GetTouch(i);
			if (touch.phase == TouchPhase.Began && touch.tapCount == 1){  
				Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
				if(Application.loadedLevel == 0 || Application.loadedLevel == 4){
					if(touchPosition.x > 11.1 && touchPosition.x < 13.7 && touchPosition.y > 11.4 && touchPosition.y < 13.8){
						if(themePositionNumber == 1){
							initiateNightBackground();
							themePositionNumber = 2;
						}else if(themePositionNumber == 2){    
							initiateRainBackground();
							themePositionNumber = 3;
						}else if(themePositionNumber == 3){
							initiateSpaceBackground();
							themePositionNumber = 4;
						}else if(themePositionNumber == 4){  
							initiateSunsetBackground();
							themePositionNumber = 1;
						}
					}

					else if(touchPosition.x > 2.25 && touchPosition.x < 4.7 && touchPosition.y > 11.4 && touchPosition.y < 13.8){
						if(themePositionNumber == 1){
							initiateSpaceBackground();
							themePositionNumber = 4;
						}else if(themePositionNumber == 2){    
							initiateSunsetBackground();
							themePositionNumber = 1;
						}else if(themePositionNumber == 3){
							initiateNightBackground();
							themePositionNumber = 2;
						}else if(themePositionNumber == 4){  
							initiateRainBackground();
							themePositionNumber = 3;
						}
					}
				}
			}
		}
	}

	public void initiateSunsetBackground(){
		if(gameObject.name.Equals("ThemeBackground")){      
			gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Background5", typeof(Sprite)) as Sprite;  
		}
		hideRain();
		hideStars();

		if(gameObject.name.Equals("ThemeText")){
			gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("SunsetText", typeof(Sprite)) as Sprite;
		}  

		if(gameObject.name.Equals("UpperLeftBG")){
			gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BlankButton", typeof(Sprite)) as Sprite;
		}  

		if(gameObject.name.Equals("UpperRightBG")){
			gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BlankButton", typeof(Sprite)) as Sprite;
		}

		//BGSoundObject.audio.clip = (AudioClip)Resources.Load("Wind", typeof(AudioClip)) as AudioClip;
		//BGSoundObject.audio.Play();         
	}

	public void initiateRainBackground(){        
		if(gameObject.name.Equals("ThemeBackground")){  
			gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("RainBackground", typeof(Sprite)) as Sprite;
		}
		showRain();
		hideStars();

		if(gameObject.name.Equals("ThemeText")){        
			gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("RainText", typeof(Sprite)) as Sprite;
		}

		if(gameObject.name.Equals("UpperLeftBG")){
			gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BlankButton", typeof(Sprite)) as Sprite;
		}

		if(gameObject.name.Equals("UpperRightBG")){
			gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BlankButton", typeof(Sprite)) as Sprite;
		}

		//BGSoundObject.audio.clip = (AudioClip)Resources.Load("RainSound", typeof(AudioClip)) as AudioClip;
		//BGSoundObject.audio.Play();   
	}

	public void initiateNightBackground(){   
		if(gameObject.name.Equals("ThemeBackground")){  
			gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("NightBackground", typeof(Sprite)) as Sprite;
		}
		hideRain();
		showStars();

		if(gameObject.name.Equals("ThemeText")){        
			gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("MoonriseText", typeof(Sprite)) as Sprite;
		}

		if(gameObject.name.Equals("UpperLeftBG")){
			gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("UpperLeftMoon", typeof(Sprite)) as Sprite;
		}

		if(gameObject.name.Equals("UpperRightBG")){
			gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("UpperLeftMoon", typeof(Sprite)) as Sprite;
		}

		//BGSoundObject.audio.clip = (AudioClip)Resources.Load("NightSound", typeof(AudioClip)) as AudioClip;
		//BGSoundObject.audio.Play(); 
	}

	public void initiateSpaceBackground(){   

		if(gameObject.name.Equals("ThemeBackground")){ 
			gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("SpaceBackground", typeof(Sprite)) as Sprite;
		}
		hideRain();
		showStars();      

		if(gameObject.name.Equals("ThemeText")){
			gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("SpaceText", typeof(Sprite)) as Sprite;
		}

		if(gameObject.name.Equals("UpperLeftBG")){
			gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("UpperLeftSpace", typeof(Sprite)) as Sprite;
		}

		if(gameObject.name.Equals("UpperRightBG")){  
			gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("UpperLeftSpace", typeof(Sprite)) as Sprite;
		}

		//BGSoundObject.audio.clip = (AudioClip)Resources.Load("SpaceSound", typeof(AudioClip)) as AudioClip;
		//BGSoundObject.audio.Play();              
	}

	private void showRain(){
		if(gameObject.name.Equals("ThemeRainLayer1")){  
			GetComponent<SpriteRenderer>().sortingLayerName = "Default";         
		}
		if(gameObject.name.Equals("ThemeRainLayer2")){  
			GetComponent<SpriteRenderer>().sortingLayerName = "Background";
		}
		if(gameObject.name.Equals("ThemeRainLayer3A")){  
			GetComponent<SpriteRenderer>().sortingLayerName = "Background";
		}
		if(gameObject.name.Equals("ThemeRainLayer3B")){  
			GetComponent<SpriteRenderer>().sortingLayerName = "Background";     
		}
	}
	
	private void hideRain(){
		if(gameObject.name.Equals("ThemeRainLayer1")){     
			GetComponent<SpriteRenderer>().sortingLayerName = "Invisible";   
		}
		if(gameObject.name.Equals("ThemeRainLayer2")){  
			GetComponent<SpriteRenderer>().sortingLayerName = "Invisible";
		}
		if(gameObject.name.Equals("ThemeRainLayer3A")){  
			GetComponent<SpriteRenderer>().sortingLayerName = "Invisible";
		}
		if(gameObject.name.Equals("ThemeRainLayer3B")){  
			GetComponent<SpriteRenderer>().sortingLayerName = "Invisible";
		}  
	}
	
	private void showStars(){
		if(gameObject.name.Equals("Stars")){     
			GetComponent<SpriteRenderer>().sortingLayerName = "Background";   
		}
	}
	
	private void hideStars(){
		if(gameObject.name.Equals("Stars")){     
			GetComponent<SpriteRenderer>().sortingLayerName = "Invisible";   
		}
	}
}
