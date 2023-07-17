using UnityEngine;        
using System.Collections; 
using Soomla;
using Soomla.Store;

public class PaymentMenu : MonoBehaviour {

	public GameObject DollarAmount;
	public GameObject BangsAmount;
	public GameObject LowerGrass;
	public GameObject UpperText; 
	public GameObject LowerText; 
	public GameObject Bangs;
	public GameObject UnlockedText;
	public AudioClip UnlockSound; 
	//public NinjevadeBilling NB;
	

	void Start () {  
		//SoomlaStore.Initialize(new NinjevadeAssets());  
	}

	void Update () {
		HandleUserTouches();
		//HandleKeyboard();

		if(PlayerPrefs.GetInt("hasMadePurchase") == 1){

			DollarAmount.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANKButton", typeof(Sprite)) as Sprite;
			UpperText.GetComponent<SpriteRenderer>().enabled = false;
			LowerText.GetComponent<SpriteRenderer>().enabled = false;
			Bangs.GetComponent<SpriteRenderer>().enabled = false;
			UnlockedText.GetComponent<SpriteRenderer>().enabled = true;

			if(PlayerPrefs.GetInt("displayThankYou") == 1){
				LowerGrass.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("LowerGrassThankYou", typeof(Sprite)) as Sprite;
			}else{
				LowerGrass.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("LowerGrassThanksAnyways", typeof(Sprite)) as Sprite;
			}
		}
	}

	private void HandleKeyboard(){
		if(Input.GetKeyDown(KeyCode.J)){
			ToggleDollarAmountToLeft();
			ToggleBangsAmountToLeft();
		}else if(Input.GetKeyDown(KeyCode.K)){
			ToggleDollarAmountToRight();
			ToggleBangsAmountToRight();
		}else if(Input.GetKeyDown(KeyCode.L)){
			InitiatePayment();        
		}  
	}

	private void HandleUserTouches(){
		for (int i = 0; i < Input.touchCount; i++){
			Touch touch = Input.GetTouch(i);
			//if (touch.phase == TouchPhase.Began && touch.tapCount == 1){
			if (touch.phase == TouchPhase.Began){// && touch.tapCount == 1){ 
				Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);    
				

				if(touchPosition.x > -5 && touchPosition.x < -2.85 && touchPosition.y > 4.9 && touchPosition.y < 7.5){
					ToggleDollarAmountToLeft();
					ToggleBangsAmountToLeft();   
				}
				
				else if(touchPosition.x > 2.85 && touchPosition.x < 5.3 && touchPosition.y > 4.9 && touchPosition.y < 7.5){
					ToggleDollarAmountToRight();
					ToggleBangsAmountToRight();             
				}
				
				else if(touchPosition.x > -3.8 && touchPosition.x < 3.8 && touchPosition.y < 3.7){
					InitiatePayment();
				}

				if(PlayerPrefs.GetInt("hasMadePurchase") == 1){

					//About BUTTON
					if(touchPosition.x < -4.42 && touchPosition.y < 2.22){
						Application.LoadLevel(5);     
					}
					
					//MAIN MENU BUTTON
					else if(touchPosition.x > 4.42 && touchPosition.y < 2.22 ){
						Application.LoadLevel(4); 
					}      
				}
			}
		}
	}

	private void ToggleDollarAmountToLeft(){
		if(DollarAmount.GetComponent<SpriteRenderer>().sprite.name.Equals("ZeroDolla")){
			//DO NUSSING
		}else if(DollarAmount.GetComponent<SpriteRenderer>().sprite.name.Equals("OneDolla")){
			DollarAmount.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ZeroDolla", typeof(Sprite)) as Sprite;
		}else if(DollarAmount.GetComponent<SpriteRenderer>().sprite.name.Equals("TwoDolla")){
			DollarAmount.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("OneDolla", typeof(Sprite)) as Sprite;
		}else if(DollarAmount.GetComponent<SpriteRenderer>().sprite.name.Equals("ThreeDolla")){
			DollarAmount.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("TwoDolla", typeof(Sprite)) as Sprite;
		}else if(DollarAmount.GetComponent<SpriteRenderer>().sprite.name.Equals("FourDolla")){
			DollarAmount.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ThreeDolla", typeof(Sprite)) as Sprite;
		}else if(DollarAmount.GetComponent<SpriteRenderer>().sprite.name.Equals("FiveDolla")){
			DollarAmount.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("FourDolla", typeof(Sprite)) as Sprite;
		}
	}

	private void ToggleDollarAmountToRight(){      
		if(DollarAmount.GetComponent<SpriteRenderer>().sprite.name.Equals("ZeroDolla")){
			DollarAmount.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("OneDolla", typeof(Sprite)) as Sprite;
		}else if(DollarAmount.GetComponent<SpriteRenderer>().sprite.name.Equals("OneDolla")){
			DollarAmount.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("TwoDolla", typeof(Sprite)) as Sprite;
		}else if(DollarAmount.GetComponent<SpriteRenderer>().sprite.name.Equals("TwoDolla")){
			DollarAmount.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ThreeDolla", typeof(Sprite)) as Sprite;
		}else if(DollarAmount.GetComponent<SpriteRenderer>().sprite.name.Equals("ThreeDolla")){
			DollarAmount.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("FourDolla", typeof(Sprite)) as Sprite;
		}else if(DollarAmount.GetComponent<SpriteRenderer>().sprite.name.Equals("FourDolla")){
			DollarAmount.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("FiveDolla", typeof(Sprite)) as Sprite;
		}else if(DollarAmount.GetComponent<SpriteRenderer>().sprite.name.Equals("FiveDolla")){
			//DO NUSSING
		}
	}

	private void ToggleBangsAmountToLeft(){
		if(BangsAmount.GetComponent<SpriteRenderer>().sprite.name.Equals("BLANKButton")){
			//DO NUSSING
		}else if(BangsAmount.GetComponent<SpriteRenderer>().sprite.name.Equals("OneBang")){
			BangsAmount.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANKButton", typeof(Sprite)) as Sprite;
		}else if(BangsAmount.GetComponent<SpriteRenderer>().sprite.name.Equals("TwoBang")){
			BangsAmount.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("OneBang", typeof(Sprite)) as Sprite;
		}else if(BangsAmount.GetComponent<SpriteRenderer>().sprite.name.Equals("ThreeBang")){
			BangsAmount.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("TwoBang", typeof(Sprite)) as Sprite;
		}else if(BangsAmount.GetComponent<SpriteRenderer>().sprite.name.Equals("FourBang")){
			BangsAmount.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ThreeBang", typeof(Sprite)) as Sprite;
		}else if(BangsAmount.GetComponent<SpriteRenderer>().sprite.name.Equals("FiveBang")){
			BangsAmount.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("FourBang", typeof(Sprite)) as Sprite;
		}
	}

	private void ToggleBangsAmountToRight(){
		if(BangsAmount.GetComponent<SpriteRenderer>().sprite.name.Equals("BLANKButton")){
			BangsAmount.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("OneBang", typeof(Sprite)) as Sprite;
		}else if(BangsAmount.GetComponent<SpriteRenderer>().sprite.name.Equals("OneBang")){
			BangsAmount.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("TwoBang", typeof(Sprite)) as Sprite;
		}else if(BangsAmount.GetComponent<SpriteRenderer>().sprite.name.Equals("TwoBang")){
			BangsAmount.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ThreeBang", typeof(Sprite)) as Sprite;
		}else if(BangsAmount.GetComponent<SpriteRenderer>().sprite.name.Equals("ThreeBang")){
			BangsAmount.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("FourBang", typeof(Sprite)) as Sprite;
		}else if(BangsAmount.GetComponent<SpriteRenderer>().sprite.name.Equals("FourBang")){
			BangsAmount.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("FiveBang", typeof(Sprite)) as Sprite;
		}else if(BangsAmount.GetComponent<SpriteRenderer>().sprite.name.Equals("FiveBang")){
			//DO NUSSING
		}
	}

	private void InitiatePayment(){

		if(PlayerPrefs.GetInt("hasMadePurchase") != 1){
			if(DollarAmount.GetComponent<SpriteRenderer>().sprite.name.Equals("ZeroDolla")){
				ChargeZeroDollars();
			}else if(DollarAmount.GetComponent<SpriteRenderer>().sprite.name.Equals("OneDolla")){
				ChargeOneDollar();
			}else if(DollarAmount.GetComponent<SpriteRenderer>().sprite.name.Equals("TwoDolla")){
				ChargeTwoDollars();
			}else if(DollarAmount.GetComponent<SpriteRenderer>().sprite.name.Equals("ThreeDolla")){
				ChargeThreeDollars();
			}else if(DollarAmount.GetComponent<SpriteRenderer>().sprite.name.Equals("FourDolla")){
				ChargeFourDollars();
			}else if(DollarAmount.GetComponent<SpriteRenderer>().sprite.name.Equals("FiveDolla")){
				ChargeFiveDollars();
			}
			
//			UpperText.GetComponent<SpriteRenderer>().enabled = false;
//			LowerText.GetComponent<SpriteRenderer>().enabled = false;
//			Bangs.GetComponent<SpriteRenderer>().enabled = false;
//			UnlockedText.GetComponent<SpriteRenderer>().enabled = true; 

			//AudioSource.PlayClipAtPoint(UnlockSound, transform.position);
		}
	}

	private void ChargeZeroDollars(){
		PlayerPrefs.SetInt("hasMadePurchase",1);
		LowerGrass.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("LowerGrassThanksAnyways", typeof(Sprite)) as Sprite;
		DollarAmount.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANKButton", typeof(Sprite)) as Sprite;
	}

	private void ChargeOneDollar(){

		//WIP

		SoomlaStore.BuyMarketItem(NinjevadeAssets.NINJEVADE_99_UNLOCK_ID, "Full Unlock");                

//		PlayerPrefs.SetInt("hasMadePurchase",1);  
//		PlayerPrefs.SetInt("displayThankYou",1);
		//Google/Apple Payment for $1.00 
//		LowerGrass.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("LowerGrassThankYou", typeof(Sprite)) as Sprite;  
//		DollarAmount.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANKButton", typeof(Sprite)) as Sprite;  
	}

	private void ChargeTwoDollars(){

		SoomlaStore.BuyMarketItem(NinjevadeAssets.NINJEVADE_199_UNLOCK_ID, "Full Unlock 2");

//		PlayerPrefs.SetInt("hasMadePurchase",1);
//		PlayerPrefs.SetInt("displayThankYou",1);
//		//Google/Apple Payment for $2.00
//		LowerGrass.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("LowerGrassThankYou", typeof(Sprite)) as Sprite;
//		DollarAmount.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANKButton", typeof(Sprite)) as Sprite;
	}

	private void ChargeThreeDollars(){

		SoomlaStore.BuyMarketItem(NinjevadeAssets.NINJEVADE_299_UNLOCK_ID, "Full Unlock 3");

//		PlayerPrefs.SetInt("hasMadePurchase",1);
//		PlayerPrefs.SetInt("displayThankYou",1);
//		//Google/Apple Payment for $3.00
//		LowerGrass.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("LowerGrassThankYou", typeof(Sprite)) as Sprite;
//		DollarAmount.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANKButton", typeof(Sprite)) as Sprite;
	}

	private void ChargeFourDollars(){

		SoomlaStore.BuyMarketItem(NinjevadeAssets.NINJEVADE_399_UNLOCK_ID, "Full Unlock 4");
		
//		PlayerPrefs.SetInt("hasMadePurchase",1);
//		PlayerPrefs.SetInt("displayThankYou",1);
//		//Google/Apple Payment for $4.00
//		LowerGrass.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("LowerGrassThankYou", typeof(Sprite)) as Sprite;
//		DollarAmount.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANKButton", typeof(Sprite)) as Sprite;
	}

	private void ChargeFiveDollars(){

		SoomlaStore.BuyMarketItem(NinjevadeAssets.NINJEVADE_499_UNLOCK_ID, "Full Unlock 5");
		
//		PlayerPrefs.SetInt("hasMadePurchase",1);
//		PlayerPrefs.SetInt("displayThankYou",1);
//		//Google/Apple Payment for $5.00
//		LowerGrass.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("LowerGrassThankYou", typeof(Sprite)) as Sprite;
//		DollarAmount.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANKButton", typeof(Sprite)) as Sprite;
	}
}
