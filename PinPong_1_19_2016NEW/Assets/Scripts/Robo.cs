using UnityEngine;
using System.Collections;

public class Robo : MonoBehaviour {

	private static System.Random random = new System.Random();

	public AudioClip Taunt1;
	public AudioClip Taunt2;
	public AudioClip Taunt3;

	public AudioClip Celebration1;
	public AudioClip Celebration2;
	public AudioClip Celebration3;  

	public AudioClip Pout1;
	public AudioClip Pout2;
	public AudioClip Pout3;   
	  
	public AudioClip Ad1;
	public AudioClip Ad2;
	public AudioClip Ad3;

	public Animator Animator;  
	 
	void Start () {
	
	}

	void Update () {   
	 
	} 

	public void DisplayRobo(){ 
		gameObject.GetComponent<SpriteRenderer>().enabled = true;    
	}    

	public void HideRobo(){
		gameObject.GetComponent<SpriteRenderer>().enabled = false;
	}

	public void tauntPlayer(){
		//Debug.Log("TAUNT");  
		Animator.SetTrigger("Taunt");
		float scenarioNumber = random.Next (0, 4);
		if (scenarioNumber == 0){
			sayTaunt1();
		}else if (scenarioNumber == 1){
			sayTaunt2();
		}else{
			sayTaunt3();
		}
	}

	public void celebrate(){
		if(!Animator.GetCurrentAnimatorStateInfo(0).IsName("RoboCelebrate")){
			Animator.SetTrigger("Celebrate");
		}

		float scenarioNumber = random.Next (0, 4);
		if (scenarioNumber == 0){
			sayCelebration1();
		}else if (scenarioNumber == 1){
			sayCelebration2();
		}else{
			sayCelebration3();
		}
	}

	public void pout(){
		if(!Animator.GetCurrentAnimatorStateInfo(0).IsName("RoboPout")){
			Animator.SetTrigger("Pout");
		}
		float scenarioNumber = random.Next (0, 4);
		if (scenarioNumber == 0){
			sayPout1();
		}else if (scenarioNumber == 1){
			sayPout2();
		}else{
			sayPout3();
		}
	}

	public void prepareForAd(){
		StartCoroutine(PreparteForAdCo());
	}

	private IEnumerator PreparteForAdCo(){   

		gameObject.GetComponent<SpriteRenderer>().enabled = true;
		yield return new WaitForSeconds (1.0f); 
		if(!Animator.GetCurrentAnimatorStateInfo(0).IsName("RoboCelebrate")){
			Animator.SetTrigger("Celebrate");
		}
		float scenarioNumber = random.Next (0, 4);
		if (scenarioNumber == 0){
			sayAd1();  
		}else if (scenarioNumber == 1){
			sayAd2();
		}else{
			sayAd3();
		}
		yield return new WaitForSeconds (1.5f);    
		gameObject.GetComponent<SpriteRenderer>().enabled = false;  
	}

	public void sayTaunt1(){
		AudioSource.PlayClipAtPoint(Taunt1, transform.position);
	}

	public void sayTaunt2(){
		AudioSource.PlayClipAtPoint(Taunt2, transform.position);  
	}

	public void sayTaunt3(){
		AudioSource.PlayClipAtPoint(Taunt3, transform.position);
	}

	public void sayCelebration1(){
		AudioSource.PlayClipAtPoint(Celebration1, transform.position);
	}
	
	public void sayCelebration2(){
		AudioSource.PlayClipAtPoint(Celebration2, transform.position);
	}
	
	public void sayCelebration3(){
		AudioSource.PlayClipAtPoint(Celebration3, transform.position);  
	}

	public void sayPout1(){
		AudioSource.PlayClipAtPoint(Pout1, transform.position);
	}
	
	public void sayPout2(){
		AudioSource.PlayClipAtPoint(Pout2, transform.position);
	}
	
	public void sayPout3(){
		AudioSource.PlayClipAtPoint(Pout3, transform.position);
	}

	public void sayAd1(){
		AudioSource.PlayClipAtPoint(Ad1, transform.position);
	}
	
	public void sayAd2(){
		AudioSource.PlayClipAtPoint(Ad2, transform.position);   
	}
	
	public void sayAd3(){
		AudioSource.PlayClipAtPoint(Ad3, transform.position);
	}
}
