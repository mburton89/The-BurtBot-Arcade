using UnityEngine;
using System.Collections;

public class BackButton : MonoBehaviour {

	public PlayerAi Player {get; private set;}
	public bool isPaused;
	public bool isPausable;
	public GameObject GrayPane;
	  
	public void Awake(){                                                        
		Player = FindObjectOfType<PlayerAi> ();
		transform.position = Camera.main.ScreenToWorldPoint( new Vector3((Screen.width/20), Screen.height - (Screen.height/24), 1));   
		isPaused = false;
		GrayPane.gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANKButton 1", typeof(Sprite)) as Sprite;
	}

	public void Start(){       
		isPausable = true;
	}

	public void Update(){   
		 
		HandleUserTouches();          
		//HandleKeyboard();  //adsksdlkjf asdfasdafdsasdasdasdasdasdswasdsadsaassdas sadasd

		if(Application.loadedLevel == 0 && transform.position != Camera.main.ScreenToWorldPoint( new Vector3((Screen.width/20), Screen.height - (Screen.height/12), 1))){
			transform.position = Camera.main.ScreenToWorldPoint( new Vector3((Screen.width/20), Screen.height - (Screen.height/24), 1));
		}
		//HANDLE INPUT
		//SWITCH SPRITES BASED ON THE LOADED LEVEL AND PAUSED STATE

//		if(Application.loadedLevel == 2){
//			gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Textures/Buttons/ARROW");
//		}
//		else if(Application.loadedLevel == 1){
//			if(isPaused){
//				gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("PLAY", typeof(Sprite)) as Sprite;
//			}else{
//				gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("PAUSE", typeof(Sprite)) as Sprite;
//			}
//		}
	}

	private void HandleKeyboard(){
		if(Input.GetKeyDown(KeyCode.P)){

			//Debug.Log("Key Pressed");  

			if(Application.loadedLevel == 2){
				GameManager.Instance.ResetPointsToZero ();
				Player.Animator.SetTrigger("PlayerRespawn");   
				Player.IsDead = false; 
				Application.LoadLevel(4);
			}
			else if(Application.loadedLevel == 1){  
				if(!isPaused && isPausable){ 

					gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("PLAY3", typeof(Sprite)) as Sprite;
					GrayPane.gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("GRAYPANE2", typeof(Sprite)) as Sprite;


					Time.timeScale = 0;
					//enable GrayPane
					isPaused = true; 
					return;
				}else if(isPaused){   
					//disable GrayPane
					Time.timeScale = 1;

					GrayPane.gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANKButton 1", typeof(Sprite)) as Sprite;
					gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANKButton2", typeof(Sprite)) as Sprite;
           

					GrayPane.gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANKButton 1", typeof(Sprite)) as Sprite;
					gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANKButton2", typeof(Sprite)) as Sprite;
					isPaused = false;
					isPausable = false;
					return;
				}else{   
					//Nuffin
				}
			}else if(Application.loadedLevel == 5 || Application.loadedLevel == 6){
				Application.LoadLevel(4);    
			}
		}
	}

	private void HandleUserTouches(){
		for (int i = 0; i < Input.touchCount; i++){
			Touch touch = Input.GetTouch(i);
			if (touch.phase == TouchPhase.Began && touch.tapCount == 1){
				Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
				
				//BACK BUTTON
				if(touchPosition.x < - 11 && touchPosition.y > 17 ){ 
					if(Application.loadedLevel == 2){
						GameManager.Instance.ResetPointsToZero ();
						Player.Animator.SetTrigger("PlayerRespawn");
						Player.IsDead = false; 
						Application.LoadLevel(4);
					}
					else if(Application.loadedLevel == 0 || Application.loadedLevel == 4){ 

						Application.Quit();

					}
					else if(Application.loadedLevel == 5  || Application.loadedLevel == 6){
						Application.LoadLevel(4);
					}
					else if(Application.loadedLevel == 1){
						if(!isPaused && isPausable){
							gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("PLAY3", typeof(Sprite)) as Sprite;
							GrayPane.gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("GRAYPANE2", typeof(Sprite)) as Sprite;
							Time.timeScale = 0;
							isPaused = true;
							return;
						}else if(isPaused){
							Time.timeScale = 1;
							GrayPane.gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANKButton 1", typeof(Sprite)) as Sprite;
							gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANKButton2", typeof(Sprite)) as Sprite;
							isPaused = false;
							isPausable = false;
							return;   
						}
					}

				}else{
					//nuffin
				}
			}
		}
	}

//	private void countDownFromThree(){
//		countOne ("3Button");
//		countOne ("2Button");
//		countOne ("1Button");
//
//	}
//
//	private void countOne(string imageName){
//		StartCoroutine(WaitCo(imageName)); 
//	}
//	
//	private IEnumerator WaitCo(string imageName){   
//		gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load (imageName);  
//		Debug.Log("Countdown");
//		yield return new WaitForSeconds (1);  
//		Debug.Log("Countdown1");
//		yield return new WaitForSeconds (1);
//		Debug.Log("Countdown2");
//		yield return new WaitForSeconds (1);
//		Time.timeScale = 1;
//	}
}  