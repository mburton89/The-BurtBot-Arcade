using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PipSpinAd : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    HandleKeyboard ();     
		HandleUserTouches ();     
	}

    public void HandleKeyboard (){
		if (Input.GetKeyDown(KeyCode.Alpha1)){
			goBackToMainMenu();
		}else if (Input.GetKeyDown(KeyCode.Alpha2)){  
			goToPipSpinPage();      
		}
    }

    public void HandleUserTouches (){
        for (int i = 0; i < Input.touchCount; i++){    
			Touch touch = Input.GetTouch(i);    
			if (touch.phase == TouchPhase.Began){
				Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
				if(touchPosition.x < -1.4 && touchPosition.x > -3  && touchPosition.y < -1 && touchPosition.y > -2.35){
                    goBackToMainMenu();
                }else if(touchPosition.x < 3 && touchPosition.x > 1.4  && touchPosition.y < -1 && touchPosition.y > -2.35){
                    goToPipSpinPage();
                }
            }
        }
    }

    public void goBackToMainMenu() {
         SceneManager.LoadScene(2);
    }

    public void goToPipSpinPage() {
        SceneManager.LoadScene(2);
        Application.OpenURL("market://details?id=com.MatthewBurton.PipSpin");
    }
}
