using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class AchievementDeterminer{

	public bool twoStarsAreThrown{ get; set ; }
	public bool playerHasntJumped{ get; set ; }
	public bool starIsDeflected{ get; set ; }
	public bool leftEnemyGotKilt;
	public bool rightEnemyGotKilt;

	public bool isNewHighScore { get; set ; }

}


