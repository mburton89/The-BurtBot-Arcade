using System;       
using System.Collections; 
using System.Collections.Generic;
using System.Linq; 
using UnityEngine;

public class AEnemyAi : MonoBehaviour, ITakeDamage{

	public CharacterController2D _controller;              
	public Vector3 _floatingTextPosition { get; set ; }
	public virtual Vector2 _direction { get; protected set; }
	public virtual Vector2 _startPosition { get; protected set; }
	public AProjectile Projectile;
	public GameObject DestroyedEffect;
	private static System.Random random = new System.Random();
	public Animator Animator;

	public bool IsDead {get; set;}  
	public int PointsToGivePlayer;
	public float Speed;
	public float FireRate;
	private float InitialFireRate = 4; 
	private float _canFireIn;

	public AudioClip EnemyThrowSound;
	public AudioClip EnemyHitSound;

	public virtual void Start(){
		_controller = GetComponent<CharacterController2D> ();  
		_direction = _direction;
		_startPosition = _startPosition;
	}

	public void Update(){

		if((_controller.State.IsCollidingLeft) || (_controller.State.IsCollidingRight)){
			_controller.SetHorizontalForce (0);
			FireProjectile();
			RandomizeProjectileSpeedAndFireRate ();
			_canFireIn = FireRate;
			return; 
		}

		if ((_canFireIn -= Time.deltaTime) > 0)
			return;

		if(_controller.Velocity.x == 0){ 
			var raycast = Physics2D.Raycast(transform.position, _direction, 200, 1 << LayerMask.NameToLayer("Player"));
			if (!raycast)
				return;
			 
			FireProjectile();
			RandomizeProjectileSpeedAndFireRate ();
			_canFireIn = FireRate;
			//Debug.Log ("  Speed = " + Projectile.Speed + "  Fire Rate = " + FireRate); 
		}
	}  
	
	public virtual void TakeDamage(int damage, GameObject instigator){

	}

	public void Kill(){

		if(transform.position.y > 0){
			AudioSource.PlayClipAtPoint(EnemyHitSound, transform.position);
		}

		_controller.HandleCollisions = false;
		//collider2D = false; 
		IsDead = true;
		ResetFireRateAndProjectileSpeed ();   
	}
	
	public void RespawnEnemy(){

		//collider2D.enabled = true;
		_controller.HandleCollisions = true; 
		transform.position = _startPosition;  

//		_controller.SetHorizontalForce(_direction.x * 10); //initially 16. Initially 11 as of 2/2/2015 and before  
//		Debug.Log((_direction.x * 10) + "Slide In Speed"); 

		//WIP
		Vector3 DeviceDimensions = Camera.main.ScreenToWorldPoint( new Vector3((Screen.width), Screen.height, 1));
		float DeviceWidth = DeviceDimensions.x;  
		_controller.SetHorizontalForce(_direction.x * (DeviceWidth/1.776f)); //initially 16. Initially 11 as of 2/2/2015 and before  
		//Debug.Log((_direction.x * (DeviceWidth/1.78f)) + "Slide In Speed");           
		 
		//_controller.SetHorizontalForce(_direction.x * (2));                  


	}
	
	private void FireProjectile(){      

		if(Animator != null && gameObject.name.Equals("RightEnemy")){    
			Animator.SetTrigger("RightEnemyThrow");
		}
		if(Animator != null && gameObject.name.Equals("LeftEnemy")){
			Animator.SetTrigger("LeftEnemyThrow");      
		}
		
		//WIP
		Vector3 projectileSpawnLocation = new Vector3(transform.position.x + _direction.x, transform.position.y, transform.position.z); 
		var projectile = (AProjectile)Instantiate (Projectile, projectileSpawnLocation, transform.rotation); //transform.position replaced
		projectile.Initialize (gameObject, _direction, _controller.Velocity); 

		AudioSource.PlayClipAtPoint(EnemyThrowSound, transform.position);        
	}

	private void ResetFireRateAndProjectileSpeed(){
		FireRate = InitialFireRate;
		//Projectile.Speed = Projectile.InitialSpeed;

		//WIP
		Vector3 DeviceDimensions = Camera.main.ScreenToWorldPoint( new Vector3((Screen.width), Screen.height, 1));
		float DeviceWidth = DeviceDimensions.x;

		//1024*600 = 34.156		800*480 = 33.349		1280*800 =  32.091
		Projectile.Speed = (DeviceWidth * 2); //initially 34   
		//Debug.Log (Projectile.Speed);
		
//		if(GameManager.Instance.Points < 20){  
//
//			Vector3 DeviceDimensions = Camera.main.ScreenToWorldPoint( new Vector3((Screen.width), Screen.height, 1));
//			float DeviceWidth = DeviceDimensions.x;
//			Debug.Log ((DeviceWidth * 2) + "DEVICE WIDTH");
//
//			Projectile.Speed = DeviceWidth * 2; //initially 34   
//			Debug.Log (Projectile.Speed); 
//		}else if(GameManager.Instance.Points >= 20 || GameManager.Instance.Points < 40){
//			Projectile.Speed = 35;
//		}else if(GameManager.Instance.Points >= 40 || GameManager.Instance.Points < 60){
//			Projectile.Speed = 36;
//		}else if(GameManager.Instance.Points >= 60 || GameManager.Instance.Points < 80){
//			Projectile.Speed = 37;
//		}else if(GameManager.Instance.Points >= 80 || GameManager.Instance.Points < 100){
//			Projectile.Speed = 38;
//		}else{
//			Projectile.Speed = 39;
//		}

	}

	private void RandomizeProjectileSpeedAndFireRate(){

		Vector3 DeviceDimensions = Camera.main.ScreenToWorldPoint( new Vector3((Screen.width), Screen.height, 1));
		float DeviceWidth = DeviceDimensions.x;

		float NewFireRate = random.Next (2, 5);
		FireRate = NewFireRate;  

		float NewSpeed = random.Next (1, 4);
		if (NewSpeed == 1) { // 33% chance
			//Projectile.Speed = 25;
			Projectile.Speed = (DeviceWidth * 2) - 9; 
			//1024*600 = 24.11		800*480 = 			1280*800 =  22.02 
			//Debug.Log("SLOW: " + Projectile.Speed);
		} else {	//66% chance
			//Projectile.Speed = 44; //initially 46 
			Projectile.Speed = (DeviceWidth * 2) + 6; //was + 8 before 1/24/2015 
			//1024*600 = 45.11		800*480 = 			1280*800 =  43.02 
			//Debug.Log("FAST: " + Projectile.Speed);
		}
	}
	
	private void WaitTillHit(){
		StartCoroutine(WaitCo());
		//Debug.Log("SCUBA STEVE");
	}
	
	private IEnumerator WaitCo(){
		yield return new WaitForSeconds (2f);
	}
}