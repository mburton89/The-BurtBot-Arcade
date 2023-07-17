using UnityEngine;
using System.Collections;

public class APaddle : MonoBehaviour {
	
	public Deflector Deflector;
	public Transform DeflectorSpawnLocation;
	public AudioClip SwingSound;
	public Animator Animator;
	public float fireRate;
	public float canFireIn;
	
	void Start () {
		
	}
	
//	public virtual void HandleKeyboard(){
//
//	}
	
	public virtual void SpawnDeflector(){
		if(Application.loadedLevel == 1){
			if(canFireIn > 0
			   || Animator.GetCurrentAnimatorStateInfo(0).IsName("UpperBluePaddleDeflect")
			   || Animator.GetCurrentAnimatorStateInfo(0).IsName("UpperRedPaddleDeflect")
			   || Animator.GetCurrentAnimatorStateInfo(0).IsName("LowerBluePaddleDeflect")
			   || Animator.GetCurrentAnimatorStateInfo(0).IsName("LowerRedPaddleDeflect")
			   ){ 
				return;     
			}   
			  
			AudioSource.PlayClipAtPoint(SwingSound, transform.position); 
			Animator.SetTrigger("Deflect");
			var deflector = (Deflector)Instantiate(Deflector, DeflectorSpawnLocation.position, DeflectorSpawnLocation.rotation);
			deflector.Initialize(gameObject);
			canFireIn = fireRate;
		}
	}
}
