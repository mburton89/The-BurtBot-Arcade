using UnityEngine;
using System.Collections;

public abstract class ADeflector : MonoBehaviour {

	public LayerMask CollisionMask;
	public GameObject Owner { get; private set; }
	public Vector2 Direction { get; set; }

	public AudioClip PunchDeflectSound;
	public AudioClip RoboDeflectSound;
	public AudioClip StaffDeflectSound;
	
	public void Initialize(GameObject owner, Vector2 direction){
		transform.right = direction;
		Owner = owner;
		Direction = direction;
		OnInitialized();
	}
	
	protected virtual void OnInitialized(){
		return;
	}
	
	public virtual void OnTriggerEnter2D(Collider2D other){

		if(Owner.gameObject.name.Equals("Punch")){    
			AudioSource.PlayClipAtPoint(PunchDeflectSound, transform.position);
		}

		else if(Owner.gameObject.name.Equals("Robo")){  
			AudioSource.PlayClipAtPoint(RoboDeflectSound, transform.position);
		}

		else{    
			AudioSource.PlayClipAtPoint(StaffDeflectSound, transform.position);
		}
	}
	
	protected virtual void OnNotCollideWith(Collider2D other){
		return;
	}
	
	protected virtual void OnCollideOwner(){
		return;
	}
	
	protected virtual void OnCollideTakeDamage(Collider2D other, ITakeDamage takeDamage){
		return;      
	}
	
	protected virtual void OnCollideOther(Collider2D other){
		return;
	}
}
