using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TransitionPanelButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	[SerializeField]
	private int myMenuIndex = 0;

	Vector2 downPosition;

	public void OnPointerDown (PointerEventData eventData) {
		downPosition = eventData.position;
	}

	public void OnPointerUp (PointerEventData eventData) {
		if (eventData.position.Equals(downPosition)) {
			MainMenu.Instance.ShowMenu (myMenuIndex);
		}
	}

}
