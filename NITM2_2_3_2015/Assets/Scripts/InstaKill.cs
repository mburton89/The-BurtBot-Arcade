using UnityEngine;

public class InstaKill : MonoBehaviour{

	public void OnTriggerEnter2D(Collider2D other){
		var player = other.GetComponent<PlayerAi> ();
		if (player == null)
						return;

		LevelManager.Instance.KillPlayer ();
	}
}
