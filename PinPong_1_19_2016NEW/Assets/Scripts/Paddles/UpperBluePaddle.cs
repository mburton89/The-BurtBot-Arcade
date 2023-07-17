using UnityEngine;
using System.Collections;

public class UpperBluePaddle : APaddle {

	public UpperRedPaddle upperRedPaddle {get; private set;}
	public GameObject upperBluePeg;
	public GameManager gameManager;
	
	public void Start(){
		upperRedPaddle = FindObjectOfType<UpperRedPaddle> ();
		gameManager = FindObjectOfType<GameManager> ();
	}

	void Update () {
		if(!gameManager.isSinglePlayer){
			//HandleKeyboard();
			HandleUserTouches();
		}
		canFireIn -= Time.deltaTime;
		upperRedPaddle.canFireIn = canFireIn;
		DeterminePegVisibility();
	}

	private void HandleKeyboard(){
		if (Input.GetKeyDown(KeyCode.D)){
			SpawnDeflector();
		}
	}

	private void HandleUserTouches(){
		if(Time.timeScale != 0){
			for (int i = 0; i < Input.touchCount; i++){
				Touch touch = Input.GetTouch(i);
				if (touch.phase == TouchPhase.Began){
					Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
					if(touchPosition.x > 0 && touchPosition.y > 1.3){  
						SpawnDeflector();
					}
				}
			}
		}
	}

	private void DeterminePegVisibility(){
		if(canFireIn <= 0){
			upperBluePeg.GetComponent<SpriteRenderer>().enabled = true;
		}else{
			upperBluePeg.GetComponent<SpriteRenderer>().enabled = false;
		}
	}
}
