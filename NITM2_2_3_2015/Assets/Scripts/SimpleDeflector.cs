using UnityEngine;

public class SimpleDeflector: ADeflector{

	public GameObject DestroyedEffect;
	public float TimeToLive;
	
	public void Update(){
		if ((TimeToLive -= Time.deltaTime) <= 0) {
			DestroyDeflector();
			return;
		}
	}
	
	public void TakeDamage(int damage, GameObject instigator){
//		if (PointsToGiveToPlayer != 0) {
//			var projectile = instigator.GetComponent<Projectile>();
//			if(projectile != null && projectile.Owner.GetComponent<Player>() != null){
//				GameManager.Instance.AddPoints(PointsToGiveToPlayer);
//				//FloatingText.Show(string.Format("+{0}!", PointsToGiveToPlayer), "PointStarText", new FromWorldPointTextPositioner(Camera.main, transform.position, 1.5f, 50));
//			}
//		}
//		DestroyProjectile ();
	}
	
	protected override void OnCollideOther(Collider2D other){
		Debug.Log("OnCollideOther");
	}
	
	protected override void OnCollideOwner(){    
		Debug.Log("OnCollideOwner");    
	}
	
	protected override void OnCollideTakeDamage(Collider2D other, ITakeDamage takeDamage){
		Debug.Log("OnCollideTakeDamage");    
	}
	
	private void DestroyDeflector(){  
		if (DestroyedEffect != null)
			Instantiate (DestroyedEffect, transform.position, transform.rotation);
		
		Destroy (gameObject);
	}
}

