using UnityEngine;
using System.Collections;

public class LowerRedPaddle : APaddle {

	public LowerBluePaddle lowerBluePaddle {get; private set;}
	public GameObject lowerRedPeg;

	public void Start(){
		lowerBluePaddle = FindObjectOfType<LowerBluePaddle> ();
	}

	void Update () {
		//HandleKeyboard();
		HandleUserTouches();
		canFireIn -= Time.deltaTime;
		lowerBluePaddle.canFireIn = canFireIn;
		DeterminePegVisibility();
	}

	private void HandleKeyboard(){
		if (Input.GetKeyDown(KeyCode.RightArrow)){
			SpawnDeflector(); 
		}
	}

	private void HandleUserTouches(){
		if(Time.timeScale != 0){
			for (int i = 0; i < Input.touchCount; i++){
				Touch touch = Input.GetTouch(i);
				if (touch.phase == TouchPhase.Began){
					Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
					if(touchPosition.x > 0 && touchPosition.y < - 1.3){  
						SpawnDeflector();
					}
				}
			}
		}
	}

	private void DeterminePegVisibility(){
		if(canFireIn <= 0){
			lowerRedPeg.GetComponent<SpriteRenderer>().enabled = true;
		}else{
			lowerRedPeg.GetComponent<SpriteRenderer>().enabled = false;
		}
	}
}
