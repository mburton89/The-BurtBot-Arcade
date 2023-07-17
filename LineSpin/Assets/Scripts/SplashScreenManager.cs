using UnityEngine;
using System.Collections;

public class SplashScreenManager : MonoBehaviour {

	public GameObject robo;
	public GameObject middleText;
	public GameObject thumbScanner;
	public GameObject thumbPrint;
	public SpriteRenderer render;

	//BOOT UP SCREEN STUFF
	public GameObject fullBG;
	public GameObject Cover1;
	public GameObject Cover2;
	public GameObject Cover3;
	public GameObject textRow1;
	public GameObject textRow2;

	public AudioClip scanThumbSound;

	public AudioClip robo1;
	public AudioClip robo2;
	public AudioClip robo3;

	private static System.Random random = new System.Random();


	void Start () {

		bootUp();
		PlayerPrefs.SetInt("hasSetUpInitialMenu",0); //THIS IS FOR THE setupMenu() and setupMenu2() on menu script
		//PlayerPrefs.SetInt("isFirstTimePlaying",0);
	}
	
	// Update is called once per frame
	void Update () {
		//flickerText();
		handleKeyboard();
		handleUserTouches();
	}

	public void handleKeyboard(){
		if (Input.GetKeyDown(KeyCode.Alpha4)) {
			scanThumb();
		} else if(Input.GetKeyDown(KeyCode.Alpha5)){
			invertAllMaterialColors(); 
		}
	}

	public void handleUserTouches(){
		for (int i = 0; i < Input.touchCount; i++){  
			Touch touch = Input.GetTouch(i);
			if (touch.phase == TouchPhase.Began){
				Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position); 
				if(touchPosition.x > 1.29 && touchPosition.x < 3.24 && touchPosition.y > -5 && touchPosition.y < -3){
					scanThumb();
				}
			}
		}
	}
		 

	public void scanThumb(){
		StartCoroutine(scanThumbCo()); 
	}
	
	private IEnumerator scanThumbCo(){ 
		initiateScanThumbAnimation();
		AudioSource.PlayClipAtPoint(scanThumbSound, transform.position);
		yield return new WaitForSeconds (.5f);
		playAccessGrantedAnimationAndSound();
		yield return new WaitForSeconds (1f);
		Application.LoadLevel(1);
	}

	public void initiateScanThumbAnimation(){
		thumbPrint.GetComponent<Animator>().enabled = false;
		thumbPrint.GetComponent<SpriteRenderer>().enabled = true;
		thumbPrint.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("ThumbPrint", typeof(Sprite)) as Sprite;
		thumbScanner.GetComponent<Animator>().enabled = true;
	}

	public void playAccessGrantedAnimationAndSound(){
		playRoboNoise();
		thumbPrint.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("AcessGranted", typeof(Sprite)) as Sprite;
		robo.GetComponent<SpriteRenderer>().sortingLayerName = "Player";
		//robo.SetActive(true);
		//middleText.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("AcessGranted", typeof(Sprite)) as Sprite;
	}

	public void flickerText(){
		StartCoroutine(flickerTextCo()); 
	}
	
	private IEnumerator flickerTextCo(){ 
		middleText.SetActive(false);
		yield return new WaitForSeconds (.5f);
		middleText.SetActive(true);
	}

	public void invertAllMaterialColors () {
		SpriteRenderer[] renderers = FindObjectsOfType(typeof(SpriteRenderer)) as SpriteRenderer[];
		//Renderer[] renderers = FindObjectsOfType(Renderer);
		foreach (SpriteRenderer render in renderers) {
//			if (render.material.HasProperty("_Color")) {
			if (render.color != Color.black) {
				//render.material.color = Color.blue;
				render.color = Color.blue;
			}
		}
	}

	public void bootUp(){
		StartCoroutine(bootUpCo()); 
	}

	private IEnumerator bootUpCo(){ 
		//middleText.SetActive(false);
		yield return new WaitForSeconds (.25f);
		Cover1.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
		yield return new WaitForSeconds (.5f);
		Cover2.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
		yield return new WaitForSeconds (.5f);
		Cover3.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
		yield return new WaitForSeconds (.5f);
		textRow1.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
		textRow2.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
		fullBG.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
		yield return new WaitForSeconds (.025f);
		textRow1.GetComponent<SpriteRenderer>().sortingLayerName = "Player";
		textRow2.GetComponent<SpriteRenderer>().sortingLayerName = "Player";
		fullBG.GetComponent<SpriteRenderer>().sortingLayerName = "Player";
		yield return new WaitForSeconds (.025f);
		textRow1.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
		textRow2.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
		fullBG.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
		yield return new WaitForSeconds (.025f);
		textRow1.GetComponent<SpriteRenderer>().sortingLayerName = "Player";
		textRow2.GetComponent<SpriteRenderer>().sortingLayerName = "Player";
		fullBG.GetComponent<SpriteRenderer>().sortingLayerName = "Player";
		yield return new WaitForSeconds (.025f);
		textRow1.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
		textRow2.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
		fullBG.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
		yield return new WaitForSeconds (.025f);
		textRow1.GetComponent<SpriteRenderer>().sortingLayerName = "Player";
		textRow2.GetComponent<SpriteRenderer>().sortingLayerName = "Player";
		fullBG.GetComponent<SpriteRenderer>().sortingLayerName = "Player";
		yield return new WaitForSeconds (.025f);
		textRow1.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
		textRow2.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
		fullBG.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
	}

	public void playRoboNoise(){
		float sequenceNumber = random.Next (1, 4);
		if(sequenceNumber == 1){ 
			AudioSource.PlayClipAtPoint(robo1, transform.position);
		}else if(sequenceNumber == 2){
			AudioSource.PlayClipAtPoint(robo2, transform.position);
		}else if(sequenceNumber == 3){
			AudioSource.PlayClipAtPoint(robo3, transform.position);
		}
	}
}
