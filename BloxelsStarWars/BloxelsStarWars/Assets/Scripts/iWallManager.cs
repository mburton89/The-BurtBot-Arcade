using UnityEngine;
using System.Collections;

public class iWallManager : MonoBehaviour {

	public GameObject LightSideGames;
	public GameObject DarkSideGames;

	public UIButton LightSideGamesTab;
	public UIButton DarkSideGamesTab;

	void Start () {
		LightSideGamesTab.OnClick += HandleLightTabPressed;
		DarkSideGamesTab.OnClick += HandleDarkTabPressed;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void HandleDarkTabPressed(){
		LightSideGames.SetActive(false);
		DarkSideGames.SetActive(true);
	}

	private void HandleLightTabPressed(){
		LightSideGames.SetActive(true);
		DarkSideGames.SetActive(false);
	}
}
