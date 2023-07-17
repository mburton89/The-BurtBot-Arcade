using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class RightEnemyAi : AEnemyAi, ITakeDamage{

	public void Awake(){
		_startPosition = Camera.main.ScreenToWorldPoint( new Vector3((Screen.width) + 18, Screen.height / 2, 1));
		//_startPosition = new Vector3(35, Screen.height / 2, 1); 
	}

	public RightEnemyAi(){
		_direction = new Vector2 (-1, 0);
		_startPosition = _startPosition;
	}
	
	public override void TakeDamage(int damage, GameObject instigator){  
		//WIP

		if(Animator != null){
			Animator.SetTrigger("RightEnemyKilled");
		}

		if (PointsToGivePlayer != 0) {
			GameManager.Instance.AddPoints(PointsToGivePlayer);
			LevelManager.Instance.KillRightEnemy();  
		}
	}
}