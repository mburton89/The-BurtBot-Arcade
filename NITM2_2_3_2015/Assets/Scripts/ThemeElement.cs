using UnityEngine;
using System.Collections;

public class ThemeElement: MonoBehaviour{
	
	public void Awake(){
		
	}
	
	public void Update(){
		HandleUserTouches();
		//HandleKeyboard();
	}
	
	private void HandleKeyboard(){
		if(Application.loadedLevel == 0 || Application.loadedLevel == 4){
			if(Input.GetKeyDown(KeyCode.Alpha1)){
				//layering
			}else if(Input.GetKeyDown(KeyCode.Alpha2)){
			}else if(Input.GetKeyDown(KeyCode.Alpha3)){
			}else if(Input.GetKeyDown(KeyCode.Alpha4)){
			}  
		}
	}
	
	private void HandleUserTouches(){
		
	}

	public void showRain(){
		if(gameObject.name.Equals("ThemeRainLayer1")){  
			GetComponent<SpriteRenderer>().sortingLayerName = "Default";  
		}
//		if(gameObject.name.Equals("ThemeRainLayer2")){  
//			GetComponent<SpriteRenderer>().sortingOrder = 2;
//		}
	}

	public void hideRain(){
		if(gameObject.name.Equals("ThemeRainLayer1")){  
			GetComponent<SpriteRenderer>().sortingLayerName = "Invisible";
			//GetComponent<SpriteRenderer>().sortingOrder = -1;
		}
//		if(gameObject.name.Equals("ThemeRainLayer2")){  
//			GetComponent<SpriteRenderer>().sortingOrder = -1;
//		}
	}

	public void showStars(){
		
	}

	public void hideStars(){
		
	}
}

