using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HoverableButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler {

	[SerializeField]
	private Sprite hoverSprite;

	private Image image;
	private Sprite normalSprite;

	void Start () {
		image = GetComponent <Image> ();
		normalSprite = image.sprite;
	}

	public void OnPointerEnter (PointerEventData eventData) {
		image.sprite = hoverSprite;
		image.SetNativeSize ();
	}

	public void OnPointerExit (PointerEventData eventData) {
		image.sprite = normalSprite;
		image.SetNativeSize ();
	}

	public void OnPointerClick (PointerEventData eventData) {
		image.sprite = normalSprite;
		image.SetNativeSize ();
	}

	public void SetNormalSprite (Sprite sprite) {
		normalSprite = sprite;
	}

	public void SetHoverSprite (Sprite sprite) {
		hoverSprite = sprite;
	}

}
