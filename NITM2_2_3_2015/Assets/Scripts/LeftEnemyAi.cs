using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LeftEnemyAi : AEnemyAi, ITakeDamage{

	public void Awake(){								  //initially -8
		_startPosition = Camera.main.ScreenToWorldPoint( new Vector3(-18, (Screen.height/2) - 5, 1));
	}

	public LeftEnemyAi(){
		_direction = new Vector2 (1, 0);
		_startPosition = _startPosition;
	}
	
	public override void TakeDamage(int damage, GameObject instigator){

		if(Animator != null){
			Animator.SetTrigger("LeftEnemyKilled"); 
		}
		
		if (PointsToGivePlayer != 0) {
			GameManager.Instance.AddPoints(PointsToGivePlayer);
			LevelManager.Instance.KillLeftEnemy();
		}
	}
}