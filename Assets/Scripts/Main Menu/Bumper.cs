using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bumper : MonoBehaviour {

	[SerializeField]
	private float TRANSITION_SPEED = 2.5f;
	[SerializeField]
	private float LENGTH = 1f;
	[SerializeField]
	private Image image;
	[SerializeField]
	private GameObject mainMenu;

	private float timeElapsed;

	void Start () {
		timeElapsed = 0;
	}

	void Update () {
		if (SceneController.Instance.isJustLaunched) {
			if (image.color.a < 1f) {
				image.color = new Color (255, 255, 255, image.color.a + TRANSITION_SPEED * Time.deltaTime);
			} else {
				timeElapsed += Time.deltaTime;
				if (timeElapsed >= LENGTH) {
					SceneController.Instance.isJustLaunched = false;
					ShowMainMenu ();
				}
			}
		} else {
			ShowMainMenu ();
		}
	}

	void ShowMainMenu () {
		gameObject.SetActive (false);
		mainMenu.SetActive (true);
	}
}
