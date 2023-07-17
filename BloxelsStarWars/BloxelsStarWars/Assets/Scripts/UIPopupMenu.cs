using UnityEngine;
using System.Collections;
using DG.Tweening;

public class UIPopupMenu : MonoBehaviour {

	public UIButton DismissButton;

	protected void Start () {
		print("START");
		DismissButton.OnClick += HandleDismissButtonPressed;
	}

	void Update () {
	
	}

	private void HandleDismissButtonPressed(){
		print("DOING STUFF");
		transform.DOScale(0,UIAnimationManager.speedMedium).OnComplete(() => {
			Destroy(gameObject);
		});
	}
}
