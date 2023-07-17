using UnityEngine;
using System.Collections;

public class BallDispenser : MonoBehaviour {

	private CharacterController2D controller;
	public GameManager gameManager;// { get; private set;}
	public virtual Vector2 direction { get; protected set; }
	public virtual Vector2 down { get; protected set; }
	public virtual Vector2 _startPosition { get; protected set; }
	public Ball ball;
	public AudioClip DispenseSound;
	public Animator Animator;
	public GameObject Emoji;
	
	public float FireRate;
	private float _canFireIn;

	public virtual void Start(){
		gameManager = FindObjectOfType<GameManager> ();  
		_startPosition = _startPosition;    

		if(gameManager.isSinglePlayer){      
			gameManager.robo.DisplayRobo();  
			gameManager.robo.tauntPlayer();  
		}
	}  
	
	public void Update(){
		if(Application.loadedLevel == 1 && Time.timeScale != 0){
			HandleKeyboard();
			HandleUserTouches();
		}
	} 

	private void FireBall(){  
		if(gameObject.GetComponent<SpriteRenderer>().enabled == true){
			AudioSource.PlayClipAtPoint(DispenseSound, transform.position); 
			Vector3 projectileSpawnLocation = new Vector3(transform.position.x + direction.x, transform.position.y, transform.position.z); 
			var gameBall = (Ball)Instantiate (ball, projectileSpawnLocation, transform.rotation); 
			gameBall.Initialize (gameObject,
			                     direction,
			                     new Vector2(0, .02f));  
			gameObject.GetComponent<SpriteRenderer>().enabled = false;
		}
	}

	private void HandleKeyboard(){
		if (Input.GetKeyDown(KeyCode.DownArrow)){
			if(gameManager.Emoji.GetComponent<SpriteRenderer>().sprite.name.Equals("RetryButton2")){
				//Debug.Log("SCOOOOON");
				gameManager.ResetPointsToFive(true);
			}else{
				FireBall();
			}
		}
	}

	private void HandleUserTouches(){
		for (int i = 0; i < Input.touchCount; i++){
			Touch touch = Input.GetTouch(i);
			if (touch.phase == TouchPhase.Began){
				Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
				if(touchPosition.x < 1.95  
				 && touchPosition.x > -1.95
				 && touchPosition.y < 1.175
				 && touchPosition.y > -1.175){  
					if(gameManager.Emoji.GetComponent<SpriteRenderer>().sprite.name.Equals("RetryButton2")){
						//Emoji.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Blank", typeof(Sprite)) as Sprite;
						gameManager.ResetPointsToFive(true);
					}else{
						FireBall();
					}
				}
			}
		}
	}
	
	public virtual void TakeDamage(int damage, GameObject instigator){  
		
	}

	public void DisplayBallDispenser(){
		//gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Ball", typeof(Sprite)) as Sprite;
		gameObject.GetComponent<SpriteRenderer>().enabled = true;
	}

	public void HideBallDispenser(){
		//gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANK", typeof(Sprite)) as Sprite;
		gameObject.GetComponent<SpriteRenderer>().enabled = false;
	}
}
