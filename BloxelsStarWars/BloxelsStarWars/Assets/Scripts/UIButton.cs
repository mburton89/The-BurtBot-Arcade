using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;
using TMPro;

public class UIButton : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler, IPointerClickHandler {
	public enum Type {
		PositiveAction,
		NegativeAction
	}

	[Header("UI")]
	public RectTransform selfRect;
	public CanvasGroup uiCanvasGroup;

	private TextMeshProUGUI[] _tmProText;

	[Tooltip("The primary part of the button")] 
	public Image uiImageClickReceiver;
	//public Sprite uiImageClickReceiver;

	private Color _normalColor;

	[Tooltip("This will be ignored if autoTint is enabled")]
	public Color tint;

	private Color _autoTintColor;

	[Header("State Tracking")]
	public bool shouldAutoTint;

	private bool _interactable;
	public bool interactable {
		get {
			return _interactable;
		}
		set {
			_interactable = value;

			if(_interactable) {
				FadeGraphics(fadeInAmount);
			}
			else {
				FadeGraphics(fadeOutAmount);
			}

			if (uiCanvasGroup != null) { //TODO Ask Rob if this is ok
				uiCanvasGroup.blocksRaycasts = _interactable;			
			}
		}
	}

	[Header("Data")]

	[Range(0,1)]
	public float fadeOutAmount = 0.5f;

	[Range(0,1)]
	public float fadeInAmount = 1.0f;

	public Type actionType;

	[Header("SFX Overrides")]
	public AudioClip onClickSFX;
	public AudioClip onToggleSFX;

	[Header("=== If Toggle ===")]
	public bool isToggle = false;
	public RectTransform[] toggleIndicators;
	public bool isOn = false;

	public delegate void HandleClick();
	public event HandleClick OnClick;

	public delegate void HandleEnter();
	public event HandleEnter OnEnter;

	public delegate void HandleExit();
	public event HandleExit OnExit;

	public delegate void HandleDown();
	public event HandleDown OnDown;

	public delegate void HandleUp();
	public event HandleUp OnUp;

	public delegate void HandleToggle(UIButton button);
	public event HandleToggle OnToggle;

	public delegate void HandleGemLock(UIButton button);
	public event HandleGemLock OnGemLock;

	void Awake() {
		selfRect = GetComponent<RectTransform>();
		_tmProText = GetComponentsInChildren<TextMeshProUGUI>();
		uiCanvasGroup = GetComponent<CanvasGroup>();

		_autoTintColor = new Color(
			_normalColor.r - (10/255), 
			_normalColor.g - (10/255), 
			_normalColor.b - (10/255), 
			_normalColor.a - (10/255)
		);

		if(isToggle && toggleIndicators == null) {
			Debug.LogError("This Button is a toggle but has no active/inactive indicators");
		}

		if(isToggle) {
			isOn = false;

			uiCanvasGroup.alpha = fadeOutAmount;

			for(int i = 0; i < toggleIndicators.Length; i++) {
				toggleIndicators[i].localScale = Vector3.zero;
			}
		}
	}

	private void FadeGraphics(float amount) {
		
	}

	public void Fade(bool fullAlpha) {
		float alpha = 0;

		if(fullAlpha) {
			alpha = fadeInAmount;
		}
		else {
			alpha = fadeOutAmount;
		}

		FadeGraphics(alpha);
	}

	private void MixColors(bool shouldMix) {

	}

	private void FlipGraphic() {
		uiImageClickReceiver.transform.localScale = new Vector3(1, uiImageClickReceiver.transform.localScale.y * -1, 1);
	}

	private Tweener ScaleAnimation(float scale) {
		return selfRect.DOScale(scale, .2f);
	}

	#region Toggle

	/// <summary>
	/// Should only be used if isToggle is set to True
	/// </summary>
	public void Toggle() {
		if (!isToggle) return;

		if(!isOn) {
			Activate();
		}
		else {
			DeActivate();
		}

		if(OnToggle != null) {
			OnToggle(this);
		}
	}

	/// <summary>
	/// Should only be used if isToggle is set to True
	/// </summary>
	public void Activate() {
		if (!isToggle) return;
		//		if (isOn) return;

		isOn = true;

		Fade(isOn);

		for(int i = 0; i < toggleIndicators.Length; i++) {
			toggleIndicators[i].DOScale(1, .2f);
		}
	}

	/// <summary>
	/// Should only be used if isToggle is set to True
	/// </summary>
	public void DeActivate() {
		if (!isToggle) return;
		//		if (!isOn) return;

		isOn = false;

		Fade(isOn);

		for(int i = 0; i < toggleIndicators.Length; i++) {
			toggleIndicators[i].DOScale(0,.2f);
		}
	}

	#endregion

	#region Pointer Events

	public virtual void OnPointerEnter(PointerEventData eventData) {
		if(OnEnter != null) {
			OnEnter();
		}
	}

	public virtual void OnPointerExit(PointerEventData eventData) {
		if(OnExit != null) {
			OnExit();
		}
	}

	public virtual void OnPointerDown(PointerEventData eventData) {
		if(OnDown != null) {
			OnDown();
		}

		//		MixColors(true);

		ScaleAnimation(0.95f);
	}

	public virtual void OnPointerUp(PointerEventData eventData) {
		if(OnUp != null) {
			OnUp();
		}

		//		MixColors(false);

		ScaleAnimation(1f);
	}

	public virtual void OnPointerClick(PointerEventData eventData) {
		PlaySound();


		if(isToggle) {
			Toggle();

			return;
		}

		if(OnClick != null) {
			OnClick();
		}
	}

	#endregion

	public virtual void PlaySound() {


	}
}
