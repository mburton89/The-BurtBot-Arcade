using UnityEngine;
using System.Collections;

public class Belt : MonoBehaviour {

	public void Update(){

		if(Application.loadedLevel != 1){
			if(PlayerPrefs.GetInt ("currentHighScore") < 5){
				//WHITE    
				GetComponent<SpriteRenderer>().color = Color.white; 
			}else if(PlayerPrefs.GetInt ("currentHighScore") >= 5 && PlayerPrefs.GetInt ("currentHighScore") < 10){     
				//YELLOW  
				GetComponent<SpriteRenderer>().color = Color.yellow;
			}else if (PlayerPrefs.GetInt ("currentHighScore") >= 10 && PlayerPrefs.GetInt ("currentHighScore") < 20){
				//ORANGE 
				GetComponent<SpriteRenderer>().color = new Color(1, 0.5f, 0.0f, 1); 
			}else if (PlayerPrefs.GetInt ("currentHighScore") >= 20 && PlayerPrefs.GetInt ("currentHighScore") < 40){
				//GREEN
				GetComponent<SpriteRenderer>().color = Color.green; 
			}else if (PlayerPrefs.GetInt ("currentHighScore") >= 40 && PlayerPrefs.GetInt ("currentHighScore") < 70){
				//BLUE
				GetComponent<SpriteRenderer>().color = Color.blue; 
			}else if (PlayerPrefs.GetInt ("currentHighScore") >= 70 && PlayerPrefs.GetInt ("currentHighScore") < 100){
				//PURPLE
				GetComponent<SpriteRenderer>().color = new Color(.7f, 0.0f, 0.8f, 1); 
			}else if (PlayerPrefs.GetInt ("currentHighScore") >= 100 && PlayerPrefs.GetInt ("currentHighScore") < 140){
				//BROWN
				GetComponent<SpriteRenderer>().color = new Color(.6f, 0.3f, 0.1f, 1); 
			}else if (PlayerPrefs.GetInt ("currentHighScore") >= 140 && PlayerPrefs.GetInt ("currentHighScore") < 200){
				//RED
				GetComponent<SpriteRenderer>().color = Color.red;
			}else if (PlayerPrefs.GetInt ("currentHighScore") >= 200 && PlayerPrefs.GetInt ("currentHighScore") < 100000){
				//BLACK
				GetComponent<SpriteRenderer>().color = Color.black; 
			}
		}
	}
}