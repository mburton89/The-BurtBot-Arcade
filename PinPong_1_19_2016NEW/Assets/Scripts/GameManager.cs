using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class GameManager : MonoBehaviour{ 

	public GameObject BRPoints;
	public GameObject OTPoints;
	public GameObject Emoji;
	public GameObject OTWinner;
	public GameObject BRWinner;
	public AudioClip RestartSound;
	public AudioClip WinnerSound;
	public LeftSideMenu leftSideMenu;
	public Achievements achievements;
	//public OpponentAI opponent;
	public bool isSinglePlayer;
	public float slowBallSpeed;
	public float fastBallSpeed;

	public Robo robo;

	public void Start(){

	}

	public void ResetPointsToFive(bool playSound){

		BRPoints.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("RB5", typeof(Sprite)) as Sprite;
		OTPoints.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("OT5", typeof(Sprite)) as Sprite;
		Emoji.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANK", typeof(Sprite)) as Sprite;
		HideWinnerText();    
		if(playSound){   
			AudioSource.PlayClipAtPoint(RestartSound, transform.position);
		}   
		robo.HideRobo();

		if(PlayerPrefs.GetInt("hasMadePurchase") != 1){
			if(Advertisement.IsReady() && PlayerPrefs.GetInt("adCycle") >= 3){
				Advertisement.Show();
				PlayerPrefs.SetInt("adCycle", 1 );
				if(isSinglePlayer){  
					robo.prepareForAd();
				}
			}
		}
	}
	
	public void DeductPointsFromBR(){   
		if(BRPoints.GetComponent<SpriteRenderer>().sprite.name.Equals("RB5")){       
			//Debug.Log("I AM A PINEABBLE CHAMPION");    
			BRPoints.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("RB4", typeof(Sprite)) as Sprite;
			FlashEmoji("OT");    
		}else if(BRPoints.GetComponent<SpriteRenderer>().sprite.name.Equals("RB4")){    
			BRPoints.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("RB3", typeof(Sprite)) as Sprite;
			FlashEmoji("OT"); 
		}else if(BRPoints.GetComponent<SpriteRenderer>().sprite.name.Equals("RB3")){
			BRPoints.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("RB2", typeof(Sprite)) as Sprite;
			FlashEmoji("OT");
		}else if(BRPoints.GetComponent<SpriteRenderer>().sprite.name.Equals("RB2")){
			BRPoints.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("RB1", typeof(Sprite)) as Sprite;
			FlashEmoji("OT");
		}else if(BRPoints.GetComponent<SpriteRenderer>().sprite.name.Equals("RB1")){
			BRPoints.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANK", typeof(Sprite)) as Sprite;
			//FlashEmoji("OT");
			DisplayGameOverScreen();
		}
	}

	public void DeductPointsFromOT(){
		if(OTPoints.GetComponent<SpriteRenderer>().sprite.name.Equals("OT5")){
			OTPoints.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("OT4", typeof(Sprite)) as Sprite;
			FlashEmoji("BR");
		}else if(OTPoints.GetComponent<SpriteRenderer>().sprite.name.Equals("OT4")){
			OTPoints.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("OT3", typeof(Sprite)) as Sprite;
			FlashEmoji("BR");
		}else if(OTPoints.GetComponent<SpriteRenderer>().sprite.name.Equals("OT3")){
			OTPoints.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("OT2", typeof(Sprite)) as Sprite;
			FlashEmoji("BR");
		}else if(OTPoints.GetComponent<SpriteRenderer>().sprite.name.Equals("OT2")){
			OTPoints.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("OT1", typeof(Sprite)) as Sprite;
			FlashEmoji("BR");
		}else if(OTPoints.GetComponent<SpriteRenderer>().sprite.name.Equals("OT1")){
			OTPoints.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BLANK", typeof(Sprite)) as Sprite;
			//FlashEmoji("BR");
			DisplayGameOverScreen();
		}
	}

	public void FlashEmoji(string emoji){
		StartCoroutine(FlashEmojiCo(emoji)); 
	}

	private IEnumerator FlashEmojiCo(string emoji){   

//		float scenarioNumber = random.Next (1, 4);
//		if (scenarioNumber == 1){
//			if(emoji.name.Equals ("BREmoji")){
//				emoji.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BRBang", typeof(Sprite)) as Sprite;
//			}else{
//				emoji.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("OTBang", typeof(Sprite)) as Sprite;
//			}
//		}else if (scenarioNumber == 2){
//			if(emoji.name.Equals ("BREmoji")){
//				emoji.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BRSmiley", typeof(Sprite)) as Sprite;
//			}else{
//				emoji.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("OTSmiley", typeof(Sprite)) as Sprite;
//			}
//		}else if (scenarioNumber == 3){
//			if(emoji.name.Equals ("BREmoji")){
//				emoji.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BRThumbsUp", typeof(Sprite)) as Sprite;
//			}else{
//				emoji.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("OTThumbsUp", typeof(Sprite)) as Sprite;
//			}
//		}
		if(emoji.Equals ("BR")){
			Emoji.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("BRThumbsUp", typeof(Sprite)) as Sprite;
		}else{
			Emoji.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("OTThumbsUp", typeof(Sprite)) as Sprite;
		}
		Emoji.GetComponent<SpriteRenderer>().enabled = true;
		yield return new WaitForSeconds (.4f);  
		Emoji.GetComponent<SpriteRenderer>().enabled = false; 
	}

	public void FlashWinnerText(){



		if(OTPoints.GetComponent<SpriteRenderer>().sprite.name.Equals("BLANK")){

			if(isSinglePlayer){
				robo.pout();
			}

			BRWinner.GetComponent<SpriteRenderer>().enabled = true;
			//PlayerPrefs.SetInt("numberOfWins", 9 );            
			PlayerPrefs.SetInt("numberOfWins", (PlayerPrefs.GetInt("numberOfWins") + 1));
			//Debug.Log("NUMBER OF WINS:" + PlayerPrefs.GetInt("numberOfWins")); 

			if(PlayerPrefs.GetInt("hasRatedGame") != 1){
				if(PlayerPrefs.GetInt("numberOfWins") == 5){  
					leftSideMenu.DisplayRateMenu();  
				}else if(PlayerPrefs.GetInt("numberOfWins") == 25){ 
					leftSideMenu.DisplayRateMenu();  
				}else if(PlayerPrefs.GetInt("numberOfWins") == 100){ 
					leftSideMenu.DisplayRateMenu();      
				}
			}

		}else if(BRPoints.GetComponent<SpriteRenderer>().sprite.name.Equals("BLANK")){   

			if(isSinglePlayer){  
				robo.celebrate();
			}

			OTWinner.GetComponent<SpriteRenderer>().enabled = true;  
		}

		DetermineAchievements();
	}

	public void HideWinnerText(){
		BRWinner.GetComponent<SpriteRenderer>().enabled = false;
		OTWinner.GetComponent<SpriteRenderer>().enabled = false;

	}

	public void DisplayGameOverScreen(){

		//INCREMENT ADCYCLE
		PlayerPrefs.SetInt("adCycle", PlayerPrefs.GetInt("adCycle") + 1);


		Emoji.GetComponent<SpriteRenderer>().enabled = true;
		Emoji.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("RetryButton2", typeof(Sprite)) as Sprite;
		FlashWinnerText();
		AudioSource.PlayClipAtPoint(WinnerSound, transform.position); 
		if(isSinglePlayer){  
			robo.DisplayRobo();
		}
	}

	public void DisplayEmoji(){
		Emoji.GetComponent<SpriteRenderer>().enabled = true;
	}
	
	public void HideEmoji(){
		Emoji.GetComponent<SpriteRenderer>().enabled = false;  
	}
	
	public void DetermineAchievements(){
		if(isSinglePlayer){
			if(fastBallSpeed == 13){
				if(OTPoints.GetComponent<SpriteRenderer>().sprite.name.Equals("BLANK")){
					achievements.unlockOnePlayerMediumWinAchievement();
				}
				if(OTPoints.GetComponent<SpriteRenderer>().sprite.name.Equals("BLANK") && BRPoints.GetComponent<SpriteRenderer>().sprite.name.Equals("RB5")){
					achievements.unlockOnePlayerMediumShutOutAchievement();
				}
			}else if(fastBallSpeed == 16){
				if(OTPoints.GetComponent<SpriteRenderer>().sprite.name.Equals("BLANK")){
					achievements.unlockOnePlayerFastWinAchievement();
				}
				if(OTPoints.GetComponent<SpriteRenderer>().sprite.name.Equals("BLANK") && BRPoints.GetComponent<SpriteRenderer>().sprite.name.Equals("RB5")){
					achievements.unlockOnePlayerFastShutOutAchievement();
				}
			}else if(fastBallSpeed == 19.5){
				if(OTPoints.GetComponent<SpriteRenderer>().sprite.name.Equals("BLANK")){ 
					achievements.unlockOnePlayerSuperFastWinAchievement();
				}
				if(OTPoints.GetComponent<SpriteRenderer>().sprite.name.Equals("BLANK") && BRPoints.GetComponent<SpriteRenderer>().sprite.name.Equals("RB5")){
					achievements.unlockOnePlayerSuperFastShutOutAchievement();
				}
			}else if(fastBallSpeed == 23){
				if(OTPoints.GetComponent<SpriteRenderer>().sprite.name.Equals("BLANK")){
					achievements.unlockOnePlayerSuperCrazyFastWinAchievement();
				}
				if(OTPoints.GetComponent<SpriteRenderer>().sprite.name.Equals("BLANK") && BRPoints.GetComponent<SpriteRenderer>().sprite.name.Equals("RB5")){
					achievements.unlockOnePlayerSuperCrazyFastShutOutAchievement();
				}
			}
		}

		if(!isSinglePlayer){
			if(OTPoints.GetComponent<SpriteRenderer>().sprite.name.Equals("BLANK")){
				achievements.unlockTwoPlayerWinAchievement();  
			}
			if(OTPoints.GetComponent<SpriteRenderer>().sprite.name.Equals("BLANK") && BRPoints.GetComponent<SpriteRenderer>().sprite.name.Equals("RB5")){
				achievements.unlockTwoPlayerShutOutAchievement();
			}
		}

		//Google Play Incrementationismarianisticle
		if(OTPoints.GetComponent<SpriteRenderer>().sprite.name.Equals("BLANK")){
			achievements.unlockWin10GamesAchievement();
			achievements.unlockWin100GamesAchievement();
			achievements.unlockWin1000GamesAchievement();
		}

		//PLAYER PREF METHOD OF INCREMENTING
//		if(PlayerPrefs.GetInt("numberOfWins") == 10){ 
//			achievements.unlockWin10GamesAchievement();
//		}
//
//		if(PlayerPrefs.GetInt("numberOfWins") == 100){ 
//			achievements.unlockWin100GamesAchievement();
//		}
//
//		if(PlayerPrefs.GetInt("numberOfWins") == 1000){ 
//			achievements.unlockWin1000GamesAchievement();
//		}
	}
}