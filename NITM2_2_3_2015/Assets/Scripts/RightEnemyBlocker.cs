using UnityEngine;
using System.Collections;

public class RightEnemyBlocker : MonoBehaviour {

	public void Awake(){
		//RELATIVE TO SCREEN WIDTH
		//transform.position = Camera.main.ScreenToWorldPoint( new Vector3((Screen.width) - 180, Screen.height, 1));
		transform.position = Camera.main.ScreenToWorldPoint( new Vector3((Screen.width) - (Screen.width/10), Screen.height, 1));
		//Debug.Log(Screen.width/4);

		//STATIC
		//transform.position = Camera.main.ScreenToWorldPoint( new Vector3( transform.position.x, Screen.height, 1));
		//transform.position = new Vector3 (14, transform.position.y, transform.position.z);
	}
}