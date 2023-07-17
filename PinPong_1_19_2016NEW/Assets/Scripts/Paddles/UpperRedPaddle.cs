using UnityEngine;
using System.Collections;

public class UpperRedPaddle : APaddle {

	public UpperBluePaddle upperBluePaddle {get; private set;}
	public GameObject upperRedPeg;
	public GameManager gameManager;
	
	public void Start(){
		upperBluePaddle = FindObjectOfType<UpperBluePaddle> ();
		gameManager = FindObjectOfType<GameManager> ();
	}
	
	void Update () {
		if(!gameManager.isSinglePlayer){
			//HandleKeyboard();
			HandleUserTouches();
		}
		canFireIn -= Time.deltaTime;
		upperBluePaddle.canFireIn = canFireIn;
		DeterminePegVisibility();
	}

	private void HandleKeyboard(){
		if (Input.GetKeyDown(KeyCode.A)){
			SpawnDeflector();
		}
	}

	private void HandleUserTouches(){
		if(Time.timeScale != 0){
			for (int i = 0; i < Input.touchCount; i++){  
				Touch touch = Input.GetTouch(i);
				if (touch.phase == TouchPhase.Began){
					Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
					if(touchPosition.x < 0 && touchPosition.y > 1.3){  
						SpawnDeflector();
					}
				}
			}
		}
	}

	private void DeterminePegVisibility(){
		if(canFireIn <= 0){
			upperRedPeg.GetComponent<SpriteRenderer>().enabled = true;
		}else{
			upperRedPeg.GetComponent<SpriteRenderer>().enabled = false;
		}
	}
}
