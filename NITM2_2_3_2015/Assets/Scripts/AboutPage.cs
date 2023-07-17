using System;
using System.Collections;
using UnityEngine;
using Soomla;
using Soomla.Store;

public class AboutPage : MonoBehaviour{
	
	public void Update(){
		HandleUserTouches();
	}

	//https://www.facebook.com/pages/Ninjevade/670973099690232
	
    //https://twitter.com/Ninjevade


	private void HandleUserTouches(){
		for (int i = 0; i < Input.touchCount; i++){  
			Touch touch = Input.GetTouch(i);
			if (touch.phase == TouchPhase.Began && touch.tapCount == 1){    
				Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position); 

				//Pay button
				if(touchPosition.x > 4.42 && touchPosition.y < 2.22 ){   
					//Pay For Ninjevade  

					SoomlaStore.BuyMarketItem(NinjevadeAssets.PAY_FOR_NINJEVADE_ID, "Gratuity");

//					PlayerPrefs.SetInt("hasMadePurchase",1);        
//					PlayerPrefs.SetInt("displayThankYou",1);  
				}      

				//Rate Ninjevade Button
				else if(touchPosition.x < -4.42 && touchPosition.y < 2.22){
					//Android
					Application.OpenURL("market://details?id=com.MatthewBurton.NITM2");
				}      

//				else if(touchPosition.x > -3.4 && touchPosition.x < -.5 && touchPosition.y < 3.5 && touchPosition.y > 1){
//					//ANDROID
//					Application.OpenURL("https://www.facebook.com/pages/Ninjevade/670973099690232");
//				}else if(touchPosition.x < 3.4 && touchPosition.x > .5 && touchPosition.y < 3.5 && touchPosition.y > 1){
//					//ANDROID
//					Application.OpenURL("https://twitter.com/Ninjevade"); 
//				}

				else if(touchPosition.x < -2.0 && touchPosition.x > -9.2 && touchPosition.y < 12.5 && touchPosition.y > 11){
					//ANDROID
					Application.OpenURL("https://twitter.com/MattWBurton"); 
				}
			}
		}
	}
}	
