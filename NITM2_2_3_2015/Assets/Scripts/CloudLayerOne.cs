using UnityEngine;
using System.Collections;

public class CloudLayerOne : MonoBehaviour {

	private CharacterController2D _controller;
	private SpriteRenderer _sprite;
	public virtual Vector2 _direction { get; protected set; }
	public virtual Vector2 _startPosition { get; protected set; }  
	public virtual Vector3 _initialSize { get; protected set; }
	private static System.Random random = new System.Random();  
	public Animator Animator;
	private int themePositionNumber = 1;   

	//TLKSJDLFKJS LALALALA

	public void Start(){

		//WIP

		//ThemeObject = FindObjectOfType<Theme> ();

		int scenarioNumber = random.Next (1, 1000);
		if (scenarioNumber == 2){        
			gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("UFO", typeof(Sprite)) as Sprite; 
		}


		_direction = new Vector2 (1, 0);
		_controller = GetComponent<CharacterController2D> ();     
		_sprite = GetComponent<SpriteRenderer>();
		_initialSize = new Vector3 (transform.localScale.x, transform.localScale.y, transform.localScale.z);
		RandomizeStartingLocation();   
		RandomizeSizeAndSpeed();

		if(gameObject.name.Equals("Astronaut")){ 
			GetComponent<SpriteRenderer>().sortingOrder = -1;
		}    

		//WIP
//		initialVelocityX = _controller.Velocity.x;
//		currentVelocityX = initialVelocityX;
	}

	public void Update(){

		if(transform.position.x > 24){
//			_controller.SetHorizontalForce(_direction.x * 1);
//			transform.localScale = _initialSize;
//			RandomizeStartingLocation();
//			RandomizeSizeAndSpeed();

//			if(gameObject.GetComponent<SpriteRenderer>().sprite == (Sprite)Resources.Load ("UFO", typeof(Sprite)) as Sprite){
//				gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("PAUSE", typeof(Sprite)) as Sprite;
//			}
//
//			int scenarioNumber = random.Next (1, 10); 
//			if (scenarioNumber == 2 && !ufoHasAppeared){ 
//				ufoHasAppeared = true;
//				gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("UFO", typeof(Sprite)) as Sprite; 
//			}




			transform.position =  new Vector3 (-25, transform.position.y, 0); 
		}

		//WIP
//		if(currentVelocityX > 0){
//			_controller.SetHorizontalForce(0);
//			currentVelocityX = 0;
//			return;
//		}
//		
//		if(currentVelocityX == 0){
//			_controller.SetHorizontalForce(initialVelocityX);  
//			currentVelocityX = initialVelocityX;      
//		}  
		HandleUserTouches();
		//HandleKeyboard();
	}

	private void RandomizeStartingLocation(){           
		int xCoordinate = random.Next (-20, 21);
		int yCoordinate = random.Next (15, 21);
		transform.position =  new Vector3 (xCoordinate, yCoordinate, 0);     
	}

	private void RandomizeSizeAndSpeed(){
		int scenarioNumber = random.Next (1, 10);
		if ((scenarioNumber == 1) || (scenarioNumber == 2) || (scenarioNumber == 3) || (scenarioNumber == 4)) { //Greatest Chance,
			transform.localScale = new Vector3 (transform.localScale.x - 5, transform.localScale.y - 5, transform.localScale.z); //Small Size
			_controller.SetHorizontalForce(_direction.x * .5f); //Slow Speed       
			//_controller._velocity.x = .5;
			_sprite.sortingOrder = 2; 
		} else if ((scenarioNumber == 5) || (scenarioNumber == 6) || (scenarioNumber == 7)) { //Average chance
			//Medium Size
			_controller.SetHorizontalForce((_direction.x * .9f)); // Average Speed
			_sprite.sortingOrder = 3;   
		} else { //Least Chance
			transform.localScale = new Vector3 (transform.localScale.x + 5, transform.localScale.y + 5, transform.localScale.z);  //Large Size
			_controller.SetHorizontalForce((_direction.x * 1) + .5f); //Fast Speed
			_sprite.sortingOrder = 4;       
		} 
	}

	private void HandleUserTouches(){
		for (int i = 0; i < Input.touchCount; i++){
			Touch touch = Input.GetTouch(i);
			if (touch.phase == TouchPhase.Began && touch.tapCount == 1){  
				Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
				if(Application.loadedLevel == 0 || Application.loadedLevel == 4){
					if(touchPosition.x > 11.1 && touchPosition.x < 13.7 && touchPosition.y > 11.4 && touchPosition.y < 13.8){
					//if(touchPosition.x > 1.6 && touchPosition.x < 2.8 && touchPosition.y > 16.2 && touchPosition.y < 18 ){    
						if(themePositionNumber == 1){
							initiateNightClouds();
							themePositionNumber = 2;
						}else if(themePositionNumber == 2){    
							initiateRainClouds();
							themePositionNumber = 3;
						}else if(themePositionNumber == 3){
							initiateSpaceClouds();
							themePositionNumber = 4;
						}else if(themePositionNumber == 4){  
							initiateOrangeClouds();
							themePositionNumber = 1;
						}
					}

					else if(touchPosition.x > 2.25 && touchPosition.x < 4.7 && touchPosition.y > 11.4 && touchPosition.y < 13.8){
						//if(touchPosition.x > 1.6 && touchPosition.x < 2.8 && touchPosition.y > 16.2 && touchPosition.y < 18 ){    
						if(themePositionNumber == 1){
							initiateSpaceClouds();
							themePositionNumber = 4;
						}else if(themePositionNumber == 2){    
							initiateOrangeClouds();
							themePositionNumber = 1;
						}else if(themePositionNumber == 3){
							initiateNightClouds();
							themePositionNumber = 2;
						}else if(themePositionNumber == 4){  
							initiateRainClouds();
							themePositionNumber = 3;
						}
					}
				}
			}
		}
	}

	private void HandleKeyboard(){
		if(Application.loadedLevel == 0 || Application.loadedLevel == 4){
			if(Input.GetKeyDown(KeyCode.Alpha1)){
				if(themePositionNumber == 1){
					initiateNightClouds();
					themePositionNumber = 2;
				}else if(themePositionNumber == 2){    
					initiateRainClouds();
					themePositionNumber = 3;
				}else if(themePositionNumber == 3){
					initiateSpaceClouds();
					themePositionNumber = 4;
				}else if(themePositionNumber == 4){  
					initiateOrangeClouds();
					themePositionNumber = 1;
				}
			}
		}
	}

	private void initiateOrangeClouds(){
		if(gameObject.name.Equals("Cloud1")){
			gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Cloud1", typeof(Sprite)) as Sprite;
		}
		if(gameObject.name.Equals("Cloud2")){
			gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Cloud2", typeof(Sprite)) as Sprite;
		}
		if(gameObject.name.Equals("Cloud3")){
			gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Cloud3", typeof(Sprite)) as Sprite;
		}
		if(gameObject.name.Equals("Cloud4")){
			gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Cloud4", typeof(Sprite)) as Sprite;
		}
		if(gameObject.name.Equals("Cloud5")){
			gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Cloud5", typeof(Sprite)) as Sprite;
		}
		if(gameObject.name.Equals("Cloud6")){
			gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Cloud6", typeof(Sprite)) as Sprite;
		}
		if(gameObject.name.Equals("Cloud7")){
			gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Cloud7", typeof(Sprite)) as Sprite;
		}
		if(gameObject.name.Equals("Cloud8")){
			gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Cloud8", typeof(Sprite)) as Sprite;
		}
		if(gameObject.name.Equals("Cloud9")){
			gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Cloud9", typeof(Sprite)) as Sprite;
		}
		if(gameObject.name.Equals("Cloud10")){         
			gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Cloud10", typeof(Sprite)) as Sprite;
			if(Animator != null){
				Animator.SetTrigger("CloudIdle");     
			}
		}
		if(gameObject.name.Equals("Astronaut")){  
			_sprite.sortingOrder = -1; 
		}
	}

	private void initiateRainClouds(){
		if(gameObject.name.Equals("Cloud1")){  
			gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Cloud1Rain", typeof(Sprite)) as Sprite;
		}
		if(gameObject.name.Equals("Cloud2")){
			gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Cloud2Rain", typeof(Sprite)) as Sprite;
		}
		if(gameObject.name.Equals("Cloud3")){
			gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Cloud3Rain", typeof(Sprite)) as Sprite;
		}
		if(gameObject.name.Equals("Cloud4")){
			gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Cloud4Rain", typeof(Sprite)) as Sprite;
		}
		if(gameObject.name.Equals("Cloud5")){
			gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Cloud5Rain", typeof(Sprite)) as Sprite;
		}
		if(gameObject.name.Equals("Cloud6")){
			gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Cloud6Rain", typeof(Sprite)) as Sprite;
		}
		if(gameObject.name.Equals("Cloud7")){
			gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Cloud7Rain", typeof(Sprite)) as Sprite;
		}
		if(gameObject.name.Equals("Cloud8")){
			gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Cloud8Rain", typeof(Sprite)) as Sprite;
		}
		if(gameObject.name.Equals("Cloud9")){
			gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Cloud9Rain", typeof(Sprite)) as Sprite;
		}
		if(gameObject.name.Equals("Cloud10")){
			gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Cloud10Rain", typeof(Sprite)) as Sprite;
		}
		if(gameObject.name.Equals("Astronaut")){  
			_sprite.sortingOrder = -1; 
		}
	}
	private void initiateNightClouds(){
		if(gameObject.name.Equals("Cloud1")){
			gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Cloud1Night", typeof(Sprite)) as Sprite;
		}
		if(gameObject.name.Equals("Cloud2")){
			gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Cloud2Night", typeof(Sprite)) as Sprite;
		}
		if(gameObject.name.Equals("Cloud3")){
			gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Cloud3Night", typeof(Sprite)) as Sprite;
		}
		if(gameObject.name.Equals("Cloud4")){
			gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Cloud4Night", typeof(Sprite)) as Sprite;
		}
		if(gameObject.name.Equals("Cloud5")){
			gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Cloud5Night", typeof(Sprite)) as Sprite;
		}
		if(gameObject.name.Equals("Cloud6")){
			gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Cloud6Night", typeof(Sprite)) as Sprite;
		}
		if(gameObject.name.Equals("Cloud7")){
			gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Cloud7Night", typeof(Sprite)) as Sprite;
		}
		if(gameObject.name.Equals("Cloud8")){
			gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Cloud8Night", typeof(Sprite)) as Sprite;
		}
		if(gameObject.name.Equals("Cloud9")){
			gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Cloud9Night", typeof(Sprite)) as Sprite;
		}
		if(gameObject.name.Equals("Cloud10")){
			gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Cloud10Night", typeof(Sprite)) as Sprite;
		}
		if(gameObject.name.Equals("Astronaut")){  
			_sprite.sortingOrder = -1; 
		}
	}
	private void initiateSpaceClouds(){
		if(gameObject.name.Equals("Cloud1")){
			gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Cloud1Space", typeof(Sprite)) as Sprite;
		}
		if(gameObject.name.Equals("Cloud2")){
			gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Cloud2Space", typeof(Sprite)) as Sprite;
		}
		if(gameObject.name.Equals("Cloud3")){
			gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Cloud3Space", typeof(Sprite)) as Sprite;
		}
		if(gameObject.name.Equals("Cloud4")){
			gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Cloud4Space", typeof(Sprite)) as Sprite;
		}
		if(gameObject.name.Equals("Cloud5")){
			gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Cloud5Space", typeof(Sprite)) as Sprite;
		}
		if(gameObject.name.Equals("Cloud6")){
			gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Cloud6Space", typeof(Sprite)) as Sprite;
		}
		if(gameObject.name.Equals("Cloud7")){
			gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Cloud7Space", typeof(Sprite)) as Sprite;
		}
		if(gameObject.name.Equals("Cloud8")){
			gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Cloud8Space", typeof(Sprite)) as Sprite;
		}
		if(gameObject.name.Equals("Cloud9")){
			gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Cloud9Space", typeof(Sprite)) as Sprite;
		}
		if(gameObject.name.Equals("Cloud10")){
			//ThemeObject.initiateSpaceBackground();    
			gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Cloud10Space", typeof(Sprite)) as Sprite;
		}
		if(gameObject.name.Equals("Astronaut")){  
			//transform.localScale = new Vector3 (transform.localScale.x - 6, transform.localScale.y - 6, transform.localScale.z); //Small Size
			transform.localScale = new Vector3 (5, 5, transform.localScale.z); //Small Size
			_controller.SetHorizontalForce((_direction.x * .9f));
			_sprite.sortingOrder = 3;           
			if(Animator != null){      //sdf     dasdasd   asdasd    fuck     poo  sneeze
				Animator.SetTrigger("AsteroidRotate"); 
			}
		}
	}
}