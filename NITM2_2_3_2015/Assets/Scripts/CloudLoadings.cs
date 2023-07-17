using System;
using UnityEngine;

public class CloudLoadings : MonoBehaviour{

	public void Start(){

		//WIP
		//Application.targetFrameRate = 60; 

		DontDestroyOnLoad(transform.gameObject);


	}
}

