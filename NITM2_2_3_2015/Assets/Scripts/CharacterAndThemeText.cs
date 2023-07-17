using UnityEngine;
using System.Collections;

public class CharacterAndThemeText : MonoBehaviour {
	
	void Update () {
		if(Application.loadedLevel == 0 || Application.loadedLevel == 4){
			gameObject.GetComponent<SpriteRenderer>().enabled = true;
		}

		else{
			gameObject.GetComponent<SpriteRenderer>().enabled = false;
		}  
	}
}
