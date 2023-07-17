using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour, ITakeDamage {

	//public GameObject fastPaddle;
	public GameObject Owner { get; private set;}
	public OpponentAI opponent;
	public Background backGround { get; private set;}
	public GameManager gameManager { get; private set;}
	public BallDispenser ballDispenser { get; private set;}
	public Vector2 Direction { get; set;}
	public Vector2 Velocity { get; private set;}
	public LayerMask CollisionMask;
	public AudioClip GoalSound;
	public Animator Animator;

	private static System.Random random = new System.Random();

	public float Speed;
	public float timeToLive;
	public int damage;
	public int pointsToGiveToPlayer;
	public bool isActive {get; set;}
	public bool isDeflected{get; set;}

	public void Awake(){
		opponent = FindObjectOfType<OpponentAI> ();
	}

	public void Start () {
		gameManager = FindObjectOfType<GameManager> ();
		ballDispenser = FindObjectOfType<BallDispenser> ();
		backGround = FindObjectOfType<Background> ();
//		opponent = FindObjectOfType<OpponentAI> ();


		isActive = true;
	}

	void Update () {
//		if((timeToLive -= Time.deltaTime) <= 0){
//			DestroyBall();
//			isActive = false;      
//			return;
//		}

		if(transform.position.y > 5.2){
			ResetGame("OT");
			return;
		}

		if(transform.position.y < -5.2){  
			ResetGame("BR");
			return;
		}

		transform.Translate ((Direction + new Vector2 (0, Velocity.y)) * Speed * Time.deltaTime, Space.World);
		isActive = true;
	}

	public void TakeDamage(int damage, GameObject instigator){
		if (pointsToGiveToPlayer != 0) {
//			var projectile = instigator.GetComponent<Ball>();
//			if(projectile != null && projectile.Owner.GetComponent<Paddle>() != null){
//				//GameManager.Instance.AddPoints(PointsToGiveToPlayer);
//			}
		}
		DestroyBall ();
	}
	
	public void Initialize(GameObject owner, Vector2 direction, Vector2 velocity){

		float scenarioNumber = random.Next (0, 2);
		if (scenarioNumber == 0){
			direction = new Vector2(0, 1);
			opponent.reactToBallServe();
		}else{
			direction = new Vector2(0, -1);
		}
		transform.up = direction;
		Owner = owner;
		Direction = direction;
		Velocity = velocity;
		Animator.SetTrigger("Dispense");
		OnInitialized();

		
	}
	
	protected virtual void OnInitialized(){
		return;
	}
	
	public virtual void OnTriggerEnter2D(Collider2D other){

		if((CollisionMask.value & (1 << other.gameObject.layer)) == 0){
			OnNotCollideWith(other);
			return;
		}
//		var isOwner = other.gameObject == Owner;
//		var takeDamageOwner = (ITakeDamage)other.GetComponent (typeof(ITakeDamage));
//		if (isOwner) {
//			OnCollideOwner(other, takeDamageOwner);
//			return;
//		}
//		var takeDamage = (ITakeDamage)other.GetComponent (typeof(ITakeDamage));
//		if (takeDamage != null) {
//			OnCollideTakeDamage(other, takeDamage);
//			return;
//		}
		OnCollideOther(other);
	}

	protected virtual void OnNotCollideWith(Collider2D other){
		
	}
	
	protected virtual void OnCollideOwner(Collider2D other, ITakeDamage takeDamage){
		
	}
	
	protected virtual void OnCollideTakeDamage(Collider2D other, ITakeDamage takeDamage){

		//Debug.Log("TAKE DAMAGE"); 

		takeDamage.TakeDamage(damage, gameObject);
		DestroyBall();
	}
	
	public void OnCollideOther(Collider2D other){    

		//Debug.Log(other.gameObject.name);
		 
		if(other.gameObject.name.Equals("FastDeflector(Clone)")){
			Speed = gameManager.fastBallSpeed; //16
			backGround.GlowHot();
			GetComponent<SpriteRenderer>().color = new Color(1f, 0.2f, 0.0f, 1);   

			Direction = -Direction;
			//transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

			if(gameManager.isSinglePlayer && Direction.y == 1){
				opponent.reactToFastHit();
			}

		}else{
			Speed = gameManager.slowBallSpeed; //11
			backGround.GlowCool();
			GetComponent<SpriteRenderer>().color = new Color(.0f, 0.6f, 0.8f, 1);  

			Direction = -Direction;
			//transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

			if(gameManager.isSinglePlayer && Direction.y == 1 ){
				opponent.reactToSlowHit();
			}
		}

//		Direction = -Direction;
//		transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
	} 
	
	private void DestroyBall(){
		Destroy(gameObject);
	}

	private void ResetGame(string side){
		DestroyBall();
		isActive = false;
		AudioSource.PlayClipAtPoint(GoalSound, transform.position);
		//Handheld.Vibrate(); 
		if(side.Equals("BR")){
			gameManager.DeductPointsFromBR();
		}else{
			gameManager.DeductPointsFromOT();
		}
		ballDispenser.GetComponent<SpriteRenderer>().enabled = true;
	}
}