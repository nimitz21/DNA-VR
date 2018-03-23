using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProloguePlayButton : MonoBehaviour {

	[SerializeField]
	private GameObject sceneSelect;
	[SerializeField]
	private GameObject prologue;

	public void ShowPrologue () {
		sceneSelect.SetActive (false);
		prologue.SetActive (true);
		prologue.GetComponent <Prologue> ().Open ();
	}
}
