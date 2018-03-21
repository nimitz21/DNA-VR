using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VrUi : MonoBehaviour {

	[SerializeField]
	private Transform nextObject;
	[SerializeField]
	private Transform prevObject;

	public void Open () {
		gameObject.SetActive (true);
	}

	public void Close () {
		gameObject.SetActive (false);
	}

	public void PointToNextObject () {
		Pointer.Instance.PointTo (nextObject.position);
	}

	public void PointToPrevObject () {
		Pointer.Instance.PointTo (prevObject.position);
	}

}
