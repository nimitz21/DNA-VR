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

	public void ShowMenu (int menuIndex) {
		gameObject.SetActive (false);
		menus [menuIndex].SetActive (true);
	}

}
