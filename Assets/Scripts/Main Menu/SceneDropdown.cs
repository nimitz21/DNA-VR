using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneDropdown : MonoBehaviour {

	[SerializeField]
	private GameObject dropdownPanel;

	public void ShowDropdown () {
		dropdownPanel.SetActive (true);
	}

	public void HideDropdown () {
		dropdownPanel.SetActive (false);
	}

}
