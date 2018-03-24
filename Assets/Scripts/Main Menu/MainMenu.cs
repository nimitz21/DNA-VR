using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

	private static MainMenu instance;
	public static MainMenu Instance {
		get {
			if (instance == null) {
				instance = FindObjectOfType <MainMenu> ();
			}
			return instance;
		}
	}

	[SerializeField]
	private List <GameObject> menus;
	[SerializeField]
	private GameObject settings;
	[SerializeField]
	private Swipe swipe;

	public void ShowMenu (int menuIndex) {
		gameObject.SetActive (false);
		menus [menuIndex].SetActive (true);
	}

	public void ShowSettings () {
		swipe.enabled = false;
		settings.SetActive (true);
	}

	public void HideSettings () {
		swipe.enabled = true;
		settings.SetActive (false);
	}

}
