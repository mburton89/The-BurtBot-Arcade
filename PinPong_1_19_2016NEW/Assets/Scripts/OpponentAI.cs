using UnityEngine;
using System.Collections;

public class OpponentAI : MonoBehaviour {
	
	public Ball ball { get; private set;}
	public UpperBluePaddle slowPaddle;
	public UpperRedPaddle fastPaddle;
	public GameManager gameManager { get; private set;}
	private static System.Random random = new System.Random();

	public float slowTimeToWait;
	public float fastTimeToWait; 
	public int timesHit; 

	void Start () {
		gameManager = FindObjectOfType<GameManager> ();
	}

	void Update () {  
	
	}

	public void reactToBallServe(){  
		if(gameManager.isSinglePlayer){       
			waitSecondsToHit (1.5f);   
		}    
	}

	public void reactToSlowHit(){
		float scenarioNumber = random.Next (0, 12);
		if (scenarioNumber == 5 || timesHit == 15){
			waitSecondsToHit(fastTimeToWait);
			timesHit = 0;
		}else{
			waitSecondsToHit(slowTimeToWait);
		}
	}

	public void reactToFastHit(){
		float scenarioNumber = random.Next (0, 12);
		if (scenarioNumber == 5 || timesHit == 15){   
			waitSecondsToHit(slowTimeToWait);    
			timesHit = 0;
		}else{
			waitSecondsToHit(fastTimeToWait);
		}
	}  

	private void waitSecondsToHit(float seconds){ 
		timesHit ++;
		//Debug.Log("TIMES HIT" + timesHit);
		StartCoroutine(waitSecondsCo(seconds));
	}

	private IEnumerator waitSecondsCo(float seconds){
		yield return new WaitForSeconds (seconds); 
		fireRandomPaddle ();
	}

	public void fireRandomPaddle(){
		float scenarioNumber = random.Next (0, 2);
		if (scenarioNumber == 0){
			slowPaddle.SpawnDeflector();
		}else{
			fastPaddle.SpawnDeflector();
		}
	}
}
