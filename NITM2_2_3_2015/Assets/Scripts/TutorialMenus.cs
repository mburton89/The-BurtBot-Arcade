using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TutorialMenus : MonoBehaviour{
	
	public static TutorialMenus Instance {get; private set;}
	public PlayerAi Player {get; private set;}
	private static System.Random random = new System.Random();  
	
	public GameObject ThanksNinja;

	public GameObject ThanksNinja2A;
	public GameObject ThanksNinja2B;

	public AudioClip RoboHiNatalie;

	public void Awake(){
		Instance = this;
	}
	
	public void Start(){
		Player = FindObjectOfType<PlayerAi> ();

		if(PlayerPrefs.GetInt("displayThankYou") == 1){
			ThanksNinja.GetComponent<SpriteRenderer>().enabled = true; 

			int scenarioNumber = random.Next (1, 8);

			if(scenarioNumber == 7){
				ThanksNinja2A.GetComponent<SpriteRenderer>().enabled = false;
				ThanksNinja2B.GetComponent<SpriteRenderer>().enabled = true;
			}else{
				ThanksNinja2A.GetComponent<SpriteRenderer>().enabled = true;
				ThanksNinja2B.GetComponent<SpriteRenderer>().enabled = false;
			}

		}else{
			ThanksNinja.GetComponent<SpriteRenderer>().enabled = false;  
			ThanksNinja2A.GetComponent<SpriteRenderer>().enabled = false; 
			ThanksNinja2B.GetComponent<SpriteRenderer>().enabled = false;
		}

//		Vector3 initialCoordinates = new Vector3(GUITextObject.transform.position.x, GUITextObject.transform.position.y, GUITextObject.transform.position.z);
//		GUITextObject.transform.position = Camera.main.ScreenToWorldPoint( new Vector3((Screen.width/2), transform.position.y, 1)); 
//		GUITextObject.transform.position = new Vector3(GUITextObject.transform.position.x, initialCoordinates.y, initialCoordinates.z);
	}

	public void WaitForABit(){ 
		StartCoroutine(WaitForABitCoroutine()); 
	}
	
	private IEnumerator WaitForABitCoroutine(){
		yield return new WaitForSeconds (5f); 
		Application.LoadLevel(1);
	}
	
	public void Update(){ 
		WaitForABit();

		HandleUserTouches();
		//HandleKeyboard();
//
//		if (Input.GetKeyDown(KeyCode.Space)){
//			Application.LoadLevel(LevelNumberToLoad);
//		}
//
//		for (int i = 0; i < Input.touchCount; i++){
//			Touch touch = Input.GetTouch(i);
//			
//			// -- Tap: quick touch & release
//			// ------------------------------------------------
//			if (touch.phase == TouchPhase.Began && touch.tapCount == 1){
//				Application.LoadLevel(LevelNumberToLoad);
//			}
//		}
	}

	private void HandleKeyboard(){
		if(Input.GetKeyDown(KeyCode.H)){  
			roboHello();
		}
	}

	private void HandleUserTouches(){
		for (int i = 0; i < Input.touchCount; i++){
			Touch touch = Input.GetTouch(i);
			if (touch.phase == TouchPhase.Began && touch.tapCount == 1){
				Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
				if(touchPosition.x < - 11 && touchPosition.y > 17 ){ 
					roboHello();
				}
			}
		}
	}

	private void roboHello(){
		if(Player.name.Equals("Robo")){
			//Debug.Log("SKIP");   
			AudioSource.PlayClipAtPoint(RoboHiNatalie, transform.position);
			Player.Animator.SetTrigger("RoboHello");    
		}
	}
}