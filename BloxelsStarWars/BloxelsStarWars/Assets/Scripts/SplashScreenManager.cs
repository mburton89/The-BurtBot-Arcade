using UnityEngine;
using System.Collections;
using DG.Tweening;

public class SplashScreenManager : MonoBehaviour {
	
	public GameObject BloxelsLogo;
	public GameObject SmallBloxelsLogo;
	public GameObject MattelLogo;
	public GameObject StarWarsLogo;
	public GameObject StarLogo;
	public GameObject WarsLogo;
	public GameObject YellowRectangle;
	public GameObject GalacticBuilderLogo;
	public GameObject RedCloud;
	public GameObject BlueCloud;

	public SpriteRenderer YellowRectangleSprite1;
	public SpriteRenderer YellowRectangleSprite2;
	public SpriteRenderer YellowRectangleSprite3;
	public SpriteRenderer YellowRectangleSprite4;
	public SpriteRenderer YellowRectangleSprite5;

	//LOGO AND SCALE POSITIONING 
	public Vector3 StarLogoScale = new Vector3(.5f,.5f,1);
	public Vector3 StarLogoPosistion = new Vector3(-1.77f,3,1);
	public Vector3 WarsLogoScale = new Vector3(.5f,.5f,1);
	public Vector3 WarsLogoPosistion = new Vector3(4.17f,-1,1);

	public HomeScreenManager homeScreenManager;

	void Start () {
		SetScalesToZero();
		ShowBloxelsGroupLogo();
	}

	void Update () {
	
	}

	public void SetScalesToZero(){
		BloxelsLogo.transform.localScale = Vector3.zero;
		MattelLogo.transform.localScale = Vector3.zero;
		StarWarsLogo.transform.localScale = Vector3.zero;
		GalacticBuilderLogo.transform.localScale = Vector3.zero;

		homeScreenManager.AccountButton.transform.localScale = Vector3.zero;
		homeScreenManager.NavMenuButton.transform.localScale = Vector3.zero;
		homeScreenManager.CampaignButton.transform.localScale = Vector3.zero;
		homeScreenManager.BuildButton.transform.localScale = Vector3.zero;
		homeScreenManager.IWallButton.transform.localScale = Vector3.zero;
	}

	public void ShowBloxelsGroupLogo(){
		StartCoroutine(ShowBloxelsGroupLogoCo());
	}

	private IEnumerator ShowBloxelsGroupLogoCo(){
		yield return new WaitForSeconds(1);
		BloxelsLogo.transform.DOScale(1,.4f);
		yield return new WaitForSeconds(.4f);
		MattelLogo.transform.DOScale(1,.4f);
		yield return new WaitForSeconds(2f);
		BloxelsLogo.transform.DOLocalMoveY(-10,.4f);
		MattelLogo.transform.DOLocalMoveY(-10,.4f);
		StarWarsLogo.transform.DOScale(1,.4f);
		yield return new WaitForSeconds(2f);
		BloxelsLogo.transform.localScale = new Vector3(.3f,.3f,0);
		StarLogo.transform.DOLocalMove(new Vector3(-1.77f,3,1),.4f,false);
		WarsLogo.transform.DOLocalMove(new Vector3(4.2f,-3.01f,1),.4f,false);
		StarLogo.transform.DOScale(StarLogoScale,.4f);
		WarsLogo.transform.DOScale(WarsLogoScale,.4f);
		GalacticBuilderLogo.transform.DOScale(1,.4f);
		SmallBloxelsLogo.transform.DOLocalMove(new Vector3(0,-2.1f,0),.4f);
		yield return new WaitForSeconds(.45f);
		YellowRectangleSprite1.sortingOrder = 1;
		yield return new WaitForSeconds(.05f);
		YellowRectangleSprite1.sortingOrder = -10;
		YellowRectangleSprite2.sortingOrder = 1;
		yield return new WaitForSeconds(.05f);
		YellowRectangleSprite2.sortingOrder = -10;
		YellowRectangleSprite3.sortingOrder = 1;
		yield return new WaitForSeconds(.05f);
		YellowRectangleSprite3.sortingOrder = -10;
		YellowRectangleSprite4.sortingOrder = 1;
		yield return new WaitForSeconds(.05f);
		YellowRectangleSprite4.sortingOrder = -10;
		YellowRectangleSprite5.sortingOrder = 1;
		yield return new WaitForSeconds(.4f);
		StarWarsLogo.transform.DOScale(.7f,.25f);
		StarWarsLogo.transform.DOMoveY(1.2f,.25f);
		yield return new WaitForSeconds(.25f);
		RedCloud.transform.DOMoveX(8,.4f).SetEase(Ease.OutBack);
		BlueCloud.transform.DOMoveX(-10,.4f).SetEase(Ease.OutBack);
		yield return new WaitForSeconds(.4f);
		homeScreenManager.AccountButton.transform.DOScale(1,.2f);
		yield return new WaitForSeconds(.2f);
		homeScreenManager.NavMenuButton.transform.DOScale(1,.2f);
		yield return new WaitForSeconds(.2f);
		homeScreenManager.CampaignButton.transform.DOScale(1,.2f);
		yield return new WaitForSeconds(.2f);
		homeScreenManager.BuildButton.transform.DOScale(1,.2f);
		yield return new WaitForSeconds(.2f);
		homeScreenManager.IWallButton.transform.DOScale(1,.2f);

	}
}
