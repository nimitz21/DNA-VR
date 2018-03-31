using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VrUi : MonoBehaviour {

	[SerializeField]
	float HOTSPOT_EXPAND = 2f;
	[SerializeField]
	private Vector3 normalHotspotScale = new Vector3(0.1f, 0.1f, 1f);
	[SerializeField]
	private Transform nextObject;
	[SerializeField]
	private int nextObjectIndex;
	[SerializeField]
	private Transform prevObject;
	[SerializeField]
	private int prevObjectIndex;
	[SerializeField]
	private Image narrationButtonImage;
	[SerializeField]
	private HoverableButton narrationButton;
	[SerializeField]
	private Sprite normalOnSprite;
	[SerializeField]
	private Sprite hoverOnSprite;
	[SerializeField]
	private Sprite normalOffSprite;
	[SerializeField]
	private Sprite hoverOffSprite;
	[SerializeField]
	private Transform hotspotSpriteTransform;
	[SerializeField]
	private ScrollText scrollText;

	private AudioSource audioSource;

	void Awake () {
		normalHotspotScale = hotspotSpriteTransform.localScale;
	}

	void Start () {
		audioSource = GetComponent <AudioSource> ();
	}

	public void Open () {
		gameObject.SetActive (true);
		Debug.Log (normalHotspotScale);
		hotspotSpriteTransform.localScale = normalHotspotScale * HOTSPOT_EXPAND;
		if (scrollText != null) {
			scrollText.Reset ();
		}
	}

	public void Close () {
		hotspotSpriteTransform.localScale = normalHotspotScale;
		gameObject.SetActive (false);
	}

	public void PointToNextObject () {
		Pointer.Instance.PointTo (nextObject.position, nextObjectIndex);
		Close ();
	}

	public void PointToPrevObject () {
		Pointer.Instance.PointTo (prevObject.position, prevObjectIndex);
		Close ();
	}

	public void ToggleNarration () {
		audioSource.mute = !audioSource.mute;
		if (audioSource.mute) {
			narrationButtonImage.sprite = hoverOffSprite;
			narrationButton.SetNormalSprite (normalOffSprite);
			narrationButton.SetHoverSprite (hoverOffSprite);
		} else {
			narrationButtonImage.sprite = hoverOnSprite;
			narrationButton.SetNormalSprite (normalOnSprite);
			narrationButton.SetHoverSprite (hoverOnSprite);

		}
	}
		
}
