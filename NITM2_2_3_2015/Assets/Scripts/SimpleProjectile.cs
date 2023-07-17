using UnityEngine;
using System.Collections;

public class SimpleProjectile : AProjectile, ITakeDamage{

	public int Damage;
	public int PointsToGiveToPlayer;
	public GameObject DestroyedEffect;
	//WIP
	public GameObject DestroyedAnimation;

	public float TimeToLive;
	public Animator Animator;

	//public AudioClip ProjectileDeflectSound;

	//WIP
	//public bool IsDeflected { get; set;}

	public void Update(){
		if ((TimeToLive -= Time.deltaTime) <= 0) {
			DestroyProjectile();
			IsActive = false;
			return;
		}
		transform.Translate ((Direction + new Vector2 (InitialVelocity.x, 0)) * Speed * Time.deltaTime, Space.World);
		IsActive = true;
	}

	public void TakeDamage(int damage, GameObject instigator){
		if (PointsToGiveToPlayer != 0) {
			var projectile = instigator.GetComponent<AProjectile>();
			if(projectile != null && projectile.Owner.GetComponent<PlayerAi>() != null){
				GameManager.Instance.AddPoints(PointsToGiveToPlayer);
				//FloatingText.Show(string.Format("+{0}!", PointsToGiveToPlayer), "PointStarText", new FromWorldPointTextPositioner(Camera.main, transform.position, 1.5f, 50));
			}
		}
		DestroyProjectile ();
	}

	protected override void OnCollideOther(Collider2D other){
		if(Animator != null){
			Animator.SetTrigger("Deflected");
		}

		//AudioSource.PlayClipAtPoint(ProjectileDeflectSound, transform.position);

		IsDeflected = true;
		Speed = 55;
		Direction = -Direction;
		transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y , transform.localScale.z);
	}

	protected override void OnCollideOwner(Collider2D other, ITakeDamage takeDamage){
		if (IsDeflected) {
			//Destroy(Owner);
			//Owner.transform.position = new Vector3(44,5,5);
			takeDamage.TakeDamage (Damage, gameObject);
			//GameManager.Instance.AddPoints(1);
			DestroyProjectile();
		}
	}

	protected override void OnCollideTakeDamage(Collider2D other, ITakeDamage takeDamage){
		takeDamage.TakeDamage (Damage, gameObject);
		DestroyProjectile();
	}

	private void DestroyProjectile(){
//		if (DestroyedEffect != null){
//			DestroyedAnimation = (GameObject)Instantiate (DestroyedEffect, transform.position, transform.rotation);
//		}
		Destroy (gameObject);
	}
}

