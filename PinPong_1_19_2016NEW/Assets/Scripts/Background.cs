using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {

	public Animator Animator;

	void Start () {
	
	}

	public void GlowHot(){ 
		Animator.SetTrigger("GlowHot");
	}

	public void GlowCool(){
		Animator.SetTrigger("GlowCool");
	}
}
