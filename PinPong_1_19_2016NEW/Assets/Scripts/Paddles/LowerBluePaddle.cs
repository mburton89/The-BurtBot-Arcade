using UnityEngine;
using System.Collections;

public class LowerBluePaddle : APaddle {

	public LowerRedPaddle lowerRedPaddle {get; private set;}
	public GameObject lowerBluePeg;
	public int ssNumber;

	public void Start(){
		lowerRedPaddle = FindObjectOfType<LowerRedPaddle> ();
	}

	void Update () {
		//HandleKeyboard();
		HandleUserTouches();
		canFireIn -= Time.deltaTime;
		lowerRedPaddle.canFireIn = canFireIn;
		DeterminePegVisibility();
	}

	private void HandleKeyboard(){
		if (Input.GetKeyDown(KeyCode.LeftArrow)){
			SpawnDeflector(); 
		}else if (Input.GetKeyDown(KeyCode.S)){
			Application.CaptureScreenshot("iPadPinPongSS" + ssNumber + ".PNG", 2);         
			ssNumber ++;
			Debug.Log("SCREENSHOT");
		}
	}

	private void HandleUserTouches(){
		if(Time.timeScale != 0){
			for (int i = 0; i < Input.touchCount; i++){
				Touch touch = Input.GetTouch(i);
				if (touch.phase == TouchPhase.Began){
					Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
					if(touchPosition.x < 0 && touchPosition.y < -1.3){   
						SpawnDeflector();
					}
				}
			}
		}
	}

	private void DeterminePegVisibility(){
		if(canFireIn <= 0){
			lowerBluePeg.GetComponent<SpriteRenderer>().enabled = true;
		}else{
			lowerBluePeg.GetComponent<SpriteRenderer>().enabled = false;
		}
	}
}
