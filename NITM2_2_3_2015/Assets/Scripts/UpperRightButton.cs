using UnityEngine;
using System.Collections;

public class UpperRightButton : MonoBehaviour {     

	public void Awake(){ 

		transform.position = Camera.main.ScreenToWorldPoint( new Vector3((Screen.width - (Screen.width/20)), Screen.height - (Screen.height/24), 1)); 

	}
	
	public void Update(){       
		
		HandleUserTouches();            
		//HandleKeyboard();         

		if(Application.loadedLevel == 0 || Application.loadedLevel == 2 || Application.loadedLevel == 4){  
			if(!gameObject.name.Equals("UpperRightBG")){
				if( AudioListener.volume == 0){  
					gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("MutedButton2", typeof(Sprite)) as Sprite;
				}else{
					gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("NotMuteButton2", typeof(Sprite)) as Sprite;
				}           
			}
		}

		if(Application.loadedLevel == 0 && transform.position != Camera.main.ScreenToWorldPoint( new Vector3((Screen.width - (Screen.width/20)), Screen.height - (Screen.height/12), 1))){
			transform.position = Camera.main.ScreenToWorldPoint( new Vector3((Screen.width - (Screen.width/20)), Screen.height - (Screen.height/24), 1));
		}
	}
	
	private void HandleKeyboard(){
		if(Input.GetKeyDown(KeyCode.R)){  
			if(!gameObject.name.Equals("UpperRightBG")){
				if(Application.loadedLevel == 0 || Application.loadedLevel == 2 || Application.loadedLevel == 4){
					if(AudioListener.volume == 1){
						AudioListener.volume = 0;
					}else{   
						AudioListener.volume = 1; //IF I FUCKING CUSS THE CODE COMPILES. FUCK!!. SHIT. BOOOON!
					}  
				}

				else if(Application.loadedLevel == 3){ 
					Application.LoadLevel(1); 
				}
			}
		}
	}
	
	private void HandleUserTouches(){
		for (int i = 0; i < Input.touchCount; i++){
			Touch touch = Input.GetTouch(i);
			if (touch.phase == TouchPhase.Began && touch.tapCount == 1){
				Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
				
				//MUTE BUTTON
				if(touchPosition.x > 11 && touchPosition.y > 17 ){ 
					if(!gameObject.name.Equals("UpperRightBG")){
						if(Application.loadedLevel == 0 || Application.loadedLevel == 2 || Application.loadedLevel == 4){
							if(AudioListener.volume == 1){
								AudioListener.volume = 0;
							}else{   
								AudioListener.volume = 1;
							}
						}

						else if(Application.loadedLevel == 3){
							Application.LoadLevel(1);
						}
					}
				}
			}
		}
	}
}  