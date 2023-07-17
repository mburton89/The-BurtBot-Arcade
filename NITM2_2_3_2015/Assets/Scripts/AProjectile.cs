﻿using UnityEngine;
using System.Collections;

public abstract class AProjectile : MonoBehaviour {
	
	public float Speed;
	public float InitialSpeed = 24;
	public LayerMask CollisionMask;
	
	public GameObject Owner { get; private set; }
	public Vector2 Direction { get; set; }
	public Vector2 InitialVelocity { get; private set; }

	//WIP
	public bool IsDeflectable { get; private set; }
	public bool IsActive { get; set; }
	public bool IsDeflected { get; set;} 
	
	public void Initialize(GameObject owner, Vector2 direction, Vector2 initialVelocity){
		transform.right = direction;

		Owner = owner;
		Direction = direction;
		InitialVelocity = initialVelocity;
		OnInitialized();
	}
	
	protected virtual void OnInitialized(){

	}
	
	public virtual void OnTriggerEnter2D(Collider2D other){
		if((CollisionMask.value & (1 << other.gameObject.layer)) == 0){
			OnNotCollideWith(other);
			return;
		}
		var isOwner = other.gameObject == Owner;
		var takeDamageOwner = (ITakeDamage)other.GetComponent (typeof(ITakeDamage));
		if (isOwner) {
			OnCollideOwner(other, takeDamageOwner);
			return;
		}
		var takeDamage = (ITakeDamage)other.GetComponent (typeof(ITakeDamage));
		if (takeDamage != null) {
			OnCollideTakeDamage(other, takeDamage);
			return;
		}
		OnCollideOther(other);
	}
	
	protected virtual void OnNotCollideWith(Collider2D other){
   
	}
	
	protected virtual void OnCollideOwner(Collider2D other, ITakeDamage takeDamage){

	}
	
	protected virtual void OnCollideTakeDamage(Collider2D other, ITakeDamage takeDamage){
  
	}
	
	protected virtual void OnCollideOther(Collider2D other){
         
	} 
}
