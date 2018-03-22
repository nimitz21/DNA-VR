using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildCanvas : MonoBehaviour {

	[SerializeField]
	private GameObject parent;

	public void Back () {
		parent.SetActive (true);
		gameObject.SetActive (false);
	}
}
