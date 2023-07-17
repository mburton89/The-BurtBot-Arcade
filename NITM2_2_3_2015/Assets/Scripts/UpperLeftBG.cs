using UnityEngine;
using System.Collections;

public class UpperLeftBG : MonoBehaviour {
	

	public void Awake(){
		transform.position = Camera.main.ScreenToWorldPoint( new Vector3((Screen.width/20), Screen.height - (Screen.height/24), 1));            
	}
	
	public void Start(){       
	}
	
	public void Update(){   
		
		if(Application.loadedLevel == 0 && transform.position != Camera.main.ScreenToWorldPoint( new Vector3((Screen.width/20), Screen.height - (Screen.height/12), 1))){
			transform.position = Camera.main.ScreenToWorldPoint( new Vector3((Screen.width/20), Screen.height - (Screen.height/24), 1));
		}
	}
}  