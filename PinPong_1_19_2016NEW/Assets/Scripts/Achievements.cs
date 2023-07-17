using UnityEngine;
using System;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

[Serializable]  
public class Achievements{
	
	//ANDROID ACHIEVEMENT STRINGS  
	//Wins  
	public string AOnePlayerMediumWin = "CgkIqeb0_poSEAIQAQ"; 
	public string AOnePlayerFastWin = "CgkIqeb0_poSEAIQAg";  
	public string AOnePlayerSuperFastWin = "CgkIqeb0_poSEAIQAw";
	public string AOnePlayerSuperCrazyFastWin = "CgkIqeb0_poSEAIQBA";        

	//Shut Outs  
	public string AOnePlayerMediumShutOut = "CgkIqeb0_poSEAIQBQ";
	public string AOnePlayerFastShutOut = "CgkIqeb0_poSEAIQBg";  
	public string AOnePlayerSuperFastShutOut = "CgkIqeb0_poSEAIQBw"; 
	public string AOnePlayerSuperCrazyFastShutOut = "CgkIqeb0_poSEAIQCA";  
	  
	//Misc
	public string AWin10Games = "CgkIqeb0_poSEAIQCQ";  
	public string AWin100Games = "CgkIqeb0_poSEAIQCg";
	public string AWin1000Games = "CgkIqeb0_poSEAIQCw";

	//Two Player
	public string ATwoPlayerWin = "CgkIqeb0_poSEAIQDA";
	public string ATwoPlayerShutOut = "CgkIqeb0_poSEAIQDQ";

	//iOS ACHIEVEMENT STRINGS
	//Wins
//	public string iOnePlayerMediumWin = "";
//	public string iOnePlayerFastWin = "";
//	public string iOnePlayerSuperFastWin = "";
//	public string iOnePlayerSuperCrazyFastWin = "";
//	
//	//Shut Outs
//	public string iOnePlayerMediumShutOut = "";
//	public string iOnePlayerFastShutOut = "";
//	public string iOnePlayerSuperFastShutOut = "";
//	public string iOnePlayerSuperCrazyFastShutOut = "";
//	
//	//Misc
//	public string iWin10Games = "";
//	public string iWin100Games = "";
//	public string iWin1000Games = "";

	//Win Methods
	public void unlockOnePlayerMediumWinAchievement(){  
		//Debug.Log("unlockOnePlayerMediumWinAchievement");
		//KTGameCenter.SharedCenter().SubmitAchievement(100,iOnePlayerMediumWin,true);
		Social.ReportProgress("CgkIqeb0_poSEAIQAQ", 100.0f,(bool success) => {});
	}

	public void unlockOnePlayerFastWinAchievement(){
		//Debug.Log("unlockOnePlayerFastWinAchievement");
		//KTGameCenter.SharedCenter().SubmitAchievement(100,iOnePlayerFastWin,true);
		Social.ReportProgress("CgkIqeb0_poSEAIQAg", 100.0f,(bool success) => {});
	}

	public void unlockOnePlayerSuperFastWinAchievement(){
		//Debug.Log("unlockOnePlayerSuperFastWinAchievement");  
		//KTGameCenter.SharedCenter().SubmitAchievement(100,iOnePlayerSuperFastWin,true);
		Social.ReportProgress("CgkIqeb0_poSEAIQAw", 100.0f,(bool success) => {});
	}

	public void unlockOnePlayerSuperCrazyFastWinAchievement(){
		//Debug.Log("unlockOnePlayerSuperCrazyFastWinAchievement");
		//KTGameCenter.SharedCenter().SubmitAchievement(100,iOnePlayerSuperCrazyFastWin,true);
		Social.ReportProgress("CgkIqeb0_poSEAIQBA", 100.0f,(bool success) => {});
	}

	//ShutOut Methods
	public void unlockOnePlayerMediumShutOutAchievement(){
		//Debug.Log("unlockOnePlayerMediumShutOutAchievement");
		//KTGameCenter.SharedCenter().SubmitAchievement(100,iOnePlayerMediumShutOut,true);
		Social.ReportProgress("CgkIqeb0_poSEAIQBQ", 100.0f,(bool success) => {});
	}
	
	public void unlockOnePlayerFastShutOutAchievement(){
		//Debug.Log("unlockOnePlayerFastShutOutAchievement");
		//KTGameCenter.SharedCenter().SubmitAchievement(100,iOnePlayerFastShutOut,true);
		Social.ReportProgress("CgkIqeb0_poSEAIQBg", 100.0f,(bool success) => {});
	}
	
	public void unlockOnePlayerSuperFastShutOutAchievement(){
		//Debug.Log("unlockOnePlayerSuperFastShutOutAchievement");
		//KTGameCenter.SharedCenter().SubmitAchievement(100,iOnePlayerSuperFastShutOut,true);
		Social.ReportProgress("CgkIqeb0_poSEAIQBw", 100.0f,(bool success) => {});
	}
	
	public void unlockOnePlayerSuperCrazyFastShutOutAchievement(){
		//Debug.Log("unlockOnePlayerSuperCrazyFastShutOutAchievement");
		//KTGameCenter.SharedCenter().SubmitAchievement(100,iOnePlayerSuperCrazyFastShutOut,true);
		Social.ReportProgress("CgkIqeb0_poSEAIQCA", 100.0f,(bool success) => {});
	}

	//Misc Methods
	public void unlockWin10GamesAchievement(){
		//Debug.Log("unlockWin10GamesAchievement");
		//KTGameCenter.SharedCenter().SubmitAchievement(100,iWin10Games,true);
		//Social.ReportProgress(AWin10Games, 100.0f,(bool success) => {});
		PlayGamesPlatform.Instance.IncrementAchievement(
			"CgkIqeb0_poSEAIQCQ", 1, (bool success) => {
			//poopie head
		});
	}

	public void unlockWin100GamesAchievement(){
		//Debug.Log("unlockWin100GamesAchievement");
		//KTGameCenter.SharedCenter().SubmitAchievement(100,iWin100Games,true);
		//Social.ReportProgress(AWin100Games, 100.0f,(bool success) => {});  
		PlayGamesPlatform.Instance.IncrementAchievement(
			"CgkIqeb0_poSEAIQCg", 1, (bool success) => {
			//poopie head
		});
	}

	public void unlockWin1000GamesAchievement(){
		//Debug.Log("unlockWin1000GamesAchievement");
		//KTGameCenter.SharedCenter().SubmitAchievement(100,iWin1000Games,true);
		//Social.ReportProgress(AWin1000Games, 100.0f,(bool success) => {});
		PlayGamesPlatform.Instance.IncrementAchievement(
			"CgkIqeb0_poSEAIQCw", 1, (bool success) => {
			//poopie head
		});
	}

	//Two Player
	public void unlockTwoPlayerWinAchievement(){
		//Debug.Log("unlockTwoPlayerWinAchievement");
		//KTGameCenter.SharedCenter().SubmitAchievement(100,iWin1000Games,true);
		Social.ReportProgress("CgkIqeb0_poSEAIQDA", 100.0f,(bool success) => {});
	}

	public void unlockTwoPlayerShutOutAchievement(){
		//Debug.Log("unlockTwoPlayerShutOutAchievement");
		//KTGameCenter.SharedCenter().SubmitAchievement(100,iWin1000Games,true);
		Social.ReportProgress("CgkIqeb0_poSEAIQDQ", 100.0f,(bool success) => {});
	}

	//Support Achievements
	public void unlockNinjevaderAchievement(){      
		//Debug.Log("unlockNinjevaderAchievement");
		//KTGameCenter.SharedCenter().SubmitAchievement(100,iWin1000Games,true);
		Social.ReportProgress("CgkIqeb0_poSEAIQDw", 100.0f,(bool success) => {});
	}

	public void unlockPinPongerAchievement(){
		//Debug.Log("unlockPinPongerAchievement");
		//KTGameCenter.SharedCenter().SubmitAchievement(100,iWin1000Games,true);
		Social.ReportProgress("CgkIqeb0_poSEAIQDg", 100.0f,(bool success) => {});
	}
}
