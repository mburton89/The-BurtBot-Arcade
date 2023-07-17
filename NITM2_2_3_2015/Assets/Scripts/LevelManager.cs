using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class LevelManager : MonoBehaviour{
	
	public static LevelManager Instance {get; private set;}
	public PlayerAi Player {get; private set;}
	public LeftEnemyAi LeftEnemy {get; private set;}
	public RightEnemyAi RightEnemy {get; private set;}
	public AProjectile Projectile;
	public AchievementDeterminer AchievementDeterminer;
	public TimeSpan RunningTime{get{return DateTime.UtcNow - _started;}}

	//WIP 
	//public DeathMenu deathMenu;
	//public bool isNewHighScore{ get; set ; }

	private static System.Random random = new System.Random();  
	private DateTime _started;

	//ACHIEVEMENT STRINGS:
	public string yellowBelt = "CgkImaiNpJgYEAIQAQ";
	public string orangeBelt = "CgkImaiNpJgYEAIQAg";
	public string greenBelt = "CgkImaiNpJgYEAIQAw";
	public string blueBelt = "CgkImaiNpJgYEAIQBA";
	public string purpleBelt = "CgkImaiNpJgYEAIQCQ";
	public string brownBelt = "CgkImaiNpJgYEAIQCw";
	public string redBelt = "CgkImaiNpJgYEAIQDA";
	public string blackBelt = "CgkImaiNpJgYEAIQDQ";

	public string pumped = "CgkImaiNpJgYEAIQEA";
	public string evasive = "CgkImaiNpJgYEAIQEg";
	public string swift = "CgkImaiNpJgYEAIQEw";
	public string pacifistic = "CgkImaiNpJgYEAIQFA";

	//LEADERBOARD STRING:
	public string leaderboard = "CgkImaiNpJgYEAIQCA";

	public void Awake(){
		Instance = this;
	}

	public void Start(){
		Player = FindObjectOfType<PlayerAi> ();
		LeftEnemy = FindObjectOfType<LeftEnemyAi> ();
		RightEnemy = FindObjectOfType<RightEnemyAi> ();

		RandomRespawn ();
		_started = DateTime.UtcNow;
		//WIP
		PlayerPrefs.SetInt("previousHighScore4", PlayerPrefs.GetInt("currentHighScore"));
	}

	public void Update(){ 

		if (RunningTime.TotalSeconds < 0.2f) {            
			KillLeftEnemy(); 
			KillRightEnemy(); 
		}

		if (RunningTime.TotalSeconds < 0.3f              
		    && Player.Animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerGettingUp")
		    && !Player._controller.State.IsGrounded){
			Social.ReportProgress(pumped, 100.0f,(bool success) => {
				//PUMPED!
			});
		}

		if(!Player._controller.State.IsGrounded){
			AchievementDeterminer.playerHasntJumped = false;
			//Debug.Log("Jump? " + AchievementDeterminer.playerHasntJumped); 
		}    

		//if((gameObject.name.Equals("Player") || gameObject.name.Equals("Punch"))){
		if((Player.name.Equals("Player") || Player.name.Equals("Punch"))){
			if(AchievementDeterminer.twoStarsAreThrown
			   && AchievementDeterminer.playerHasntJumped 
			   && RightEnemy.IsDead
			   && RightEnemy.IsDead
			   && !Player.IsDead){  
				//DOUBLEDEFLECT ACHIEVEMENT
				Social.ReportProgress(swift, 100.0f,(bool success) => {
				}); 
			}
		}

		if((RightEnemy.Animator.GetCurrentAnimatorStateInfo(0).IsName("RightEnemySplode")
		   ||  LeftEnemy.Animator.GetCurrentAnimatorStateInfo(0).IsName("LeftEnemySplode"))
		   && !Player._controller.State.IsGrounded
		   && RightEnemy.IsDead
		   && RightEnemy.IsDead
		   && !Player.IsDead){ 
			//DEFLECT-N-JUMP Achievement
			Social.ReportProgress(evasive, 100.0f,(bool success) => {
			}); 
		}

		if (RunningTime.TotalSeconds > 30.0f 
		    && GameManager.Instance.Points == 0){
			//PACIFISTIC Achievement
			Social.ReportProgress(pacifistic, 100.0f,(bool success) => {
			});             
		}     
	}

	public void KillPlayer(){ 
		StartCoroutine(KillPlayerCo());
	}

	private IEnumerator KillPlayerCo(){
		Player.Kill ();
		//WIP  
		LeftEnemy.Projectile.enabled = true;

		yield return new WaitForSeconds (.6f); 
		RightEnemy.Animator.SetTrigger("EnemyKilledPlayer");
		LeftEnemy.Animator.SetTrigger("EnemyKilledPlayer");
		yield return new WaitForSeconds (.6f);
		_started = DateTime.UtcNow;
		GameOver ();
	}
	
	public void KillLeftEnemy(){
		StartCoroutine(KillLeftEnemyCo()); 
	}

	private IEnumerator KillLeftEnemyCo(){
		LeftEnemy.Kill ();
		float secondsToWait = .4f;
		if(RunningTime.TotalSeconds < .8){
			secondsToWait = 2f;
		}
		yield return new WaitForSeconds (secondsToWait);
		RandomRespawn ();
	}

	public void KillRightEnemy(){
		StartCoroutine(KillRightEnemyCo()); 
	}
	
	private IEnumerator KillRightEnemyCo(){
		RightEnemy.Kill ();
		float secondsToWait = .4f; //.4
		if(RunningTime.TotalSeconds < .8){
			secondsToWait = 2f;
		}
		yield return new WaitForSeconds (secondsToWait);
		RandomRespawn ();
	}

	private void RandomRespawn(){
		if (LeftEnemy.IsDead && RightEnemy.IsDead) {
			int scenarioNumber = random.Next (1, 4);
			//Debug.Log(scenarioNumber + "Respawn Scenario");
			if (scenarioNumber == 1) {
				LeftEnemy.RespawnEnemy ();	
				LeftEnemy.IsDead = false;

				//WIP
				AchievementDeterminer.twoStarsAreThrown = false;
				//Debug.Log("twoStarsAreThrown " + AchievementDeterminer.twoStarsAreThrown);

			} else if (scenarioNumber == 2) {
				RightEnemy.RespawnEnemy ();	
				RightEnemy.IsDead = false;

				//WIP
				AchievementDeterminer.twoStarsAreThrown = false;
				//Debug.Log("twoStarsAreThrown " + AchievementDeterminer.twoStarsAreThrown);

			} else {
				LeftEnemy.RespawnEnemy ();
				LeftEnemy.IsDead = false;
				RightEnemy.RespawnEnemy ();
				RightEnemy.IsDead = false;

				//WIP
				AchievementDeterminer.twoStarsAreThrown = true;
				//Debug.Log("twoStarsAreThrown " + AchievementDeterminer.twoStarsAreThrown); 
			} 
		}

		//WIP
		AchievementDeterminer.playerHasntJumped = true;
		//Debug.Log("Jump? " + AchievementDeterminer.playerHasntJumped);  
	}

	private void GameOver(){
		//WIP


		//Save score and highscore
		PlayerPrefs.SetInt("score", GameManager.Instance.Points);         

		//USE THIS TO SET HIGHSCORE TO 0. CAREFUL  
		//PlayerPrefs.SetInt("currentHighScore", 0);               

		//Unlock Achievements
		if (GameManager.Instance.Points >= 5){  
			Social.ReportProgress(yellowBelt, 100.0f,(bool success) => {
			});
		}
		
		if (GameManager.Instance.Points >= 10){
			Social.ReportProgress(orangeBelt, 100.0f,(bool success) => {
			});
		}
		
		if (GameManager.Instance.Points >= 20){
			Social.ReportProgress(greenBelt, 100.0f,(bool success) => {
			});
		}
		
		if (GameManager.Instance.Points >= 40){
			Social.ReportProgress(blueBelt, 100.0f,(bool success) => {
			});
		}
		
		if (GameManager.Instance.Points >= 70){
			Social.ReportProgress(purpleBelt, 100.0f,(bool success) => {
			});
		}

		if (GameManager.Instance.Points >= 100){
			Social.ReportProgress(brownBelt, 100.0f,(bool success) => {
			});
		}

		if (GameManager.Instance.Points >= 140){
			Social.ReportProgress(redBelt, 100.0f,(bool success) => {
			});
		}

		if (GameManager.Instance.Points >= 200){
			Social.ReportProgress(blackBelt, 100.0f,(bool success) => {
			});
		}

		//Handle High Score and post to leaderboard

		//RESET TO 1
		//PlayerPrefs.SetInt("currentHighScore", 1);  


		if (GameManager.Instance.Points > PlayerPrefs.GetInt ("currentHighScore")) {
			PlayerPrefs.SetInt("currentHighScore", GameManager.Instance.Points);
		}

		//Reports obtained score to High Score leaderboard.
		Social.ReportScore(GameManager.Instance.Points, leaderboard, (bool success) => {
			
		});

		Application.LoadLevel (2);
	}
}