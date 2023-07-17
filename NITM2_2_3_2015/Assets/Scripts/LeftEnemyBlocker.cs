using UnityEngine;
using System.Collections;

public class LeftEnemyBlocker : MonoBehaviour {
	
	public void Awake(){
		//transform.position = Camera.main.ScreenToWorldPoint( new Vector3(180, Screen.height, 1));
		transform.position = Camera.main.ScreenToWorldPoint( new Vector3((Screen.width/10), Screen.height, 1));

		//STATIC
		//transform.position = Camera.main.ScreenToWorldPoint( new Vector3( transform.position.x, Screen.height, 1));
		//transform.position = new Vector3 (-14, transform.position.y, transform.position.z);  
	}
}