using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class HomeScreenManager : MonoBehaviour {

	public UIButton AccountButton;
	public UIButton NavMenuButton;
	public UIButton CampaignButton;
	public UIButton BuildButton;
	public UIButton IWallButton;

	public GameObject UserAccountPopup;

	void Start () {
		AccountButton.OnClick += HandleAccountButtonPressed;
		NavMenuButton.OnClick += HandleNavMenuButtonPressed;
		CampaignButton.OnClick += HandleCampaignButtonPressed;
		BuildButton.OnClick += HandleBuildButtonPressed;
		IWallButton.OnClick += HandleIWallButtonPressed;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void HandleAccountButtonPressed(){
		//UserAccountPopup.transform.DOScale(1,UIAnimationManager.speedMedium);
		GameObject menuObject = Instantiate(UserAccountPopup) as GameObject;
		menuObject.transform.SetParent(transform);
		menuObject.transform.localScale = Vector3.zero;
		menuObject.transform.DOScale(Vector3.one, UIAnimationManager.speedMedium);
	}

	private void HandleNavMenuButtonPressed(){

	}

	private void HandleCampaignButtonPressed(){
		SceneManager.LoadScene(1);
	}

	private void HandleBuildButtonPressed(){
		SceneManager.LoadScene(2);
	}

	private void HandleIWallButtonPressed(){
		SceneManager.LoadScene(3);
	}
}
