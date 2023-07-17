using UnityEngine;
using System.Collections;

public class SpaceCloud : MonoBehaviour{

	public float FloatStrength;
	public float RandomRotationStrength;


	void Update () {
		//transform.GetComponent<Rigidbody2D>().AddForce(Vector3.up * FloatStrength);
		transform.Rotate(0,0,RandomRotationStrength);
	}

}
