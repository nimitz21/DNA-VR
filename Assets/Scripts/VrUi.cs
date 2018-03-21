using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VrUi : MonoBehaviour {

	[SerializeField]
	private Transform nextObject;
	[SerializeField]
	private int nextObjectIndex = -1;
	[SerializeField]
	private Transform prevObject;
	[SerializeField]
	private int prevObjectIndex = -1;

	public void Open () {
		gameObject.SetActive (true);
		Pointer.Instance.PointTo (Vector3.zero, Pointer.NULL);
	}

	public void Close () {
		gameObject.SetActive (false);
	}

	public void PointToNextObject () {
		Pointer.Instance.PointTo (nextObject.position, nextObjectIndex);
		Close ();
	}

	public void PointToPrevObject () {
		Pointer.Instance.PointTo (prevObject.position, prevObjectIndex);
		Close ();
	}
		
}
