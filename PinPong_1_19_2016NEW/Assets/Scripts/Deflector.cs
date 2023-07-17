using UnityEngine;
using System.Collections;

public class Deflector : MonoBehaviour {

	public GameObject Owner { get; private set;}
	public LayerMask CollisionMask;
	public AudioClip DeflectSound;
	public float timeToLive;
	
	void Update () {
		if((timeToLive -= Time.deltaTime) <= 0){
			DestroyDeflector();
			return;
		}
	}

	public void Initialize(GameObject owner){ //, Vector2 direction){
		Owner = owner; 
		OnInitialized();
	}

	protected virtual void OnInitialized(){
		return;
	}

	public virtual void OnTriggerEnter2D(Collider2D other){
		AudioSource.PlayClipAtPoint(DeflectSound, transform.position);
	}

	private void DestroyDeflector(){
		Destroy(gameObject);
	}
}
