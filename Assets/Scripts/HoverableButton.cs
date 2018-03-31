using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HoverableButton : MonoBehaviour {

	[SerializeField]
	private Sprite hoverSprite;

	private Image image;
	private Sprite normalSprite;

	void Start () {
		image = GetComponent <Image> ();
		normalSprite = image.sprite;

		EventTrigger trigger = gameObject.AddComponent <EventTrigger> ();

		EventTrigger.Entry pointerEnterEntry = new EventTrigger.Entry ();
		pointerEnterEntry.eventID = EventTriggerType.PointerEnter;
		pointerEnterEntry.callback.AddListener ((data) => {
			Hover ((PointerEventData)data);
		});
		trigger.triggers.Add (pointerEnterEntry);

		EventTrigger.Entry pointerExitEntry = new EventTrigger.Entry ();
		pointerExitEntry.eventID = EventTriggerType.PointerExit;
		pointerExitEntry.callback.AddListener ((data) => {
			Unhover ((PointerEventData)data);
		});
		trigger.triggers.Add (pointerExitEntry);
	}

	public void Hover (PointerEventData data) {
		image.sprite = hoverSprite;
		image.SetNativeSize ();
	}

	public void Unhover (PointerEventData data) {
		image.sprite = normalSprite;
		image.SetNativeSize ();
	}

	public void setNormalSprite (Sprite sprite) {
		normalSprite = sprite;
	}

	public void SetHoverSprite (Sprite sprite) {
		hoverSprite = sprite;
	}

}
