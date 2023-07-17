using UnityEngine;
using System.Collections;    

public class PlayerAi: MonoBehaviour, ITakeDamage{   

	//initially private
	public CharacterController2D _controller;
	//public GameObject OuchEffect;
	public GameObject NinjaScarf;

	public ADeflector Deflector;
	   
	public Transform DeflectorFireLocation;
	public Vector2 _startPosition { get; protected set; }                                          


	public bool _isFacingRight;
	public bool IsDead; //{get; private set;}  
	private float _normalizedHorizontalSpeed;
	private float _canFireIn;
	public float MaxSpeed = 8; 
	public float SpreedAccelerationOnGround = 10f;  
	public float SpeedAccelerationInAir = 5f;
	public float FireRate;
	public int MaxHealth = 100;
	public int Health{ get; private set;}                                 
	public Animator Animator;        

	private static System.Random random = new System.Random();                                    

	public AudioClip PlayerHitSound;   
	public AudioClip PlayerJumpSound;  
	public AudioClip PlayerSwingSound; 

	public AudioClip RoboSoundOne;
	public AudioClip RoboSoundTwo;
	public AudioClip RoboSoundThree;
	public AudioClip RoboSoundFour;
	public AudioClip RoboSoundFive;  
	public AudioClip RoboSoundSix;

	public void Awake(){
		_controller = GetComponent<CharacterController2D> ();
		_isFacingRight = transform.localScale.x > 0;

//		if(gameObject.name == "Player"){                 
			_startPosition = Camera.main.ScreenToWorldPoint( new Vector3(Screen.width/2, Screen.height + 120, 1));
//		}else{
//			_startPosition = Camera.main.ScreenToWorldPoint( new Vector3(Screen.width/2, Screen.height - 195, 1));
//		}     
//		Health = MaxHealth;
	}

	public void Start(){            
		transform.position = _startPosition;          
	}

	public void Update(){

		_canFireIn -= Time.deltaTime; 

		if(!IsDead && Time.timeScale != 0){   
			HandleUserTouches();  
			//HandleInput(); //FOR KEYBOARD                 
		} 
			

		var movementFactor = _controller.State.IsGrounded ? SpreedAccelerationOnGround : SpeedAccelerationInAir;
		_controller.SetHorizontalForce(Mathf.Lerp(_controller.Velocity.x, _normalizedHorizontalSpeed * MaxSpeed, Time.deltaTime * movementFactor));

		if(!_controller.State.IsGrounded
		   && (gameObject.name.Equals("Player") || gameObject.name.Equals("Punch"))){
			if(Animator != null){
				Animator.SetTrigger("PlayerJump"); 
			}
		}


		if(_controller.State.IsGrounded){
			if(Animator != null){
				Animator.SetTrigger("PlayerGrounded");        
			}  
		}
	}

	public void Kill(){
		if(Animator != null){
			Animator.SetTrigger("PlayerKilled");        
		}

		//WIP

//		_controller.HandleCollisions = false;
//		collider2D.enabled = false; 
		IsDead = true;
//		Health = 0;
	}

	public void TakeDamage(int damage, GameObject instigator){
		//Instantiate (OuchEffect, transform.position, transform.rotation);

		AudioSource.PlayClipAtPoint(PlayerHitSound, transform.position);

		Health -= damage;

		if (Health <= 0)
			LevelManager.Instance.KillPlayer ();

		//WIP
		Health = 100;  
	}

	private void HandleInput(){   
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			if (!_isFacingRight)
			Flip ();
			SpawnDeflector();
			//AudioSource.PlayClipAtPoint(PlayerSwingSound, transform.position);     

//			if(gameObject.name == "Robo"){ 
//				makeRandomRoboSound();
//			}    

		} else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			if(_isFacingRight)
			Flip();
			SpawnDeflector();
			//AudioSource.PlayClipAtPoint(PlayerSwingSound, transform.position);

//			if(gameObject.name == "Robo"){ 
//				makeRandomRoboSound();
//			}

		}else{
			_normalizedHorizontalSpeed = 0;
		}

		if(_controller.CanJump && Input.GetKeyDown(KeyCode.Space) 
		   && !Animator.GetCurrentAnimatorStateInfo(0).IsName("SuperNinjaJump")){         
			AudioSource.PlayClipAtPoint(PlayerJumpSound, transform.position);
			_controller.Jump();      
			if(gameObject.name == "SuperNinja" || gameObject.name == "Robo" ){    
				Vanish();           
			}
			if(gameObject.name == "Robo"){ 
				makeRandomRoboJumpSound();
			}
		}
//		if( _controller.State.IsGrounded){ INITIALLY NOT COMMENTED OUT. LAWLS
			//HandleUserTouches();
//		}


	}
	
	private void HandleUserTouches(){
		for (int i = 0; i < Input.touchCount; i++){
			Touch touch = Input.GetTouch(i);
			
			// -- Tap: quick touch & release
			// ------------------------------------------------
			if (touch.phase == TouchPhase.Began){// && touch.tapCount == 1){ 
				// Touch are screens location. Convert to world. Not JUST KIDDING! LALAL
				Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

				if(Application.loadedLevel == 0
				   || Application.loadedLevel == 4
				   || Application.loadedLevel == 5
				   || Application.loadedLevel == 6){
					if(touchPosition.y > 10.7 || touchPosition.y < 2.5){  
						return;
					}

					else if(touchPosition.y < 3.8 && touchPosition.x > -3.81 && touchPosition.x < 3.81){
						return;         
					}
				}

				//if(touchPosition.y > (Camera.main.orthographicSize)){ //INITIAL Y POSITIONING  FUCK!!                      
				if(touchPosition.y >= 8 && touchPosition.y < 16){               
					if((_controller.CanJump)
					&& !Animator.GetCurrentAnimatorStateInfo(0).IsName("SuperNinjaJump")){   
						AudioSource.PlayClipAtPoint(PlayerJumpSound, transform.position);   
						_controller.Jump();

						if(gameObject.name == "SuperNinja" || gameObject.name == "Robo" ){    
							Vanish();           
						}
						if(gameObject.name == "Robo"){              
							makeRandomRoboJumpSound();                     
						}                                     
					}  
					return;       
				}

				if((touchPosition.x > - 7.5) && (touchPosition.x < 7.5) && touchPosition.y < 8 ){
					if((_controller.CanJump)
					   //&& Application.loadedLevel != 0
					   //&& Application.loadedLevel != 4
					   //&& Application.loadedLevel != 5
					   && Application.loadedLevel != 6
					&& !Animator.GetCurrentAnimatorStateInfo(0).IsName("SuperNinjaJump")){
						AudioSource.PlayClipAtPoint(PlayerJumpSound, transform.position);
						_controller.Jump();

						if(gameObject.name == "SuperNinja" || gameObject.name == "Robo" ){    
							Vanish();           
						}
						if(gameObject.name == "Robo"){ 
							makeRandomRoboJumpSound();
						}
					} 
					return;

				}else if(touchPosition.x > (0)  && touchPosition.y < 8 ){
					if (!_isFacingRight)
						Flip ();
						SpawnDeflector();
						//AudioSource.PlayClipAtPoint(PlayerSwingSound, transform.position);

//					if(gameObject.name == "Robo"){ 
//						makeRandomRoboSound();
//					}

				}else if(touchPosition.x < (0)  && touchPosition.y < 8 ){
					if(_isFacingRight)
						Flip();
						SpawnDeflector();
						//AudioSource.PlayClipAtPoint(PlayerSwingSound, transform.position);

//					if(gameObject.name == "Robo"){ 
//						makeRandomRoboSound();
//					}

				}else{
					_normalizedHorizontalSpeed = 0;
				}
			}
		}
	}
		

	private void SpawnDeflector(){

		if(gameObject.layer == LayerMask.NameToLayer("Player")){
			if (_canFireIn > 0)
				return;


			AudioSource.PlayClipAtPoint(PlayerSwingSound, transform.position);            
			var direction = _isFacingRight ? Vector2.right : -Vector2.right;        
			var deflector = (ADeflector)Instantiate (Deflector, DeflectorFireLocation.position, DeflectorFireLocation.rotation);
			
			deflector.Initialize (gameObject, direction);
			_canFireIn = FireRate;
			
			if(Animator != null){
				Animator.SetTrigger("PlayerDeflect");       
			}

			if(gameObject.name == "Robo"){ 
				makeRandomRoboSound();
			}
		}
	}

	private void Flip(){
		transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);
		NinjaScarf.transform.localScale = new Vector3 (-NinjaScarf.transform.localScale.x, NinjaScarf.transform.localScale.y, NinjaScarf.transform.localScale.z);
		_isFacingRight = transform.localScale.x > 0;
	}

	public void Vanish(){
		if(!Animator.GetCurrentAnimatorStateInfo(0).IsName("SuperNinjaJump")){          
			if(Animator != null){   
				Animator.SetTrigger("Vanish");   
			}
			StartCoroutine(VanishCo());                
		}
	}

	private IEnumerator VanishCo(){
		_canFireIn = 1;
		yield return new WaitForSeconds (.09f);      
		gameObject.layer = LayerMask.NameToLayer("Projectiles");
		yield return new WaitForSeconds (.19f);  
		_canFireIn = 0;           
		gameObject.layer = LayerMask.NameToLayer("Player");
	}

	private void makeRandomRoboSound(){


		int scenarioNumber = random.Next (1, 9);

		//Debug.Log(scenarioNumber + "Deflect");  

		if (scenarioNumber == 1){        
			AudioSource.PlayClipAtPoint(RoboSoundOne, transform.position);
		}else if(scenarioNumber == 2){
			AudioSource.PlayClipAtPoint(RoboSoundTwo, transform.position);
		}else if(scenarioNumber == 3){
			AudioSource.PlayClipAtPoint(RoboSoundThree, transform.position);
		}  
	}

	private void makeRandomRoboJumpSound(){  

		int scenarioNumber = random.Next (1, 9);        

		//Debug.Log(scenarioNumber + "Jump");      

		if (scenarioNumber == 4){        
			AudioSource.PlayClipAtPoint(RoboSoundFour, transform.position);
		}else if(scenarioNumber == 5){
			AudioSource.PlayClipAtPoint(RoboSoundFive, transform.position);
		}else if(scenarioNumber == 2){
			AudioSource.PlayClipAtPoint(RoboSoundSix, transform.position);
		}
	}
}