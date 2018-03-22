using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour {

	private static Pointer instance;
	public static Pointer Instance {
		get {
			if (instance == null) {
				instance = FindObjectOfType <Pointer> ();
			}
			return instance;
		}
	}
		
	public const int NULL = -1;

	[System.Serializable]
	public class VrCanvas {
		public int index;
		public GameObject canvas;
	}

	[SerializeField]
	private float MAGNITUDE_THRESHOLD = 0.75f;
	[SerializeField]
	private Transform cameraTransform;
	[SerializeField]
	private List<VrCanvas> vrCanvases;

	private Transform arrowTransform;
	private Vector3 destinationPosition;
	private int destinationIndex;
	private float originalAngle;

	void Start () {
		if (arrowTransform == null) {
			arrowTransform = transform.GetChild (0);
		}
		destinationIndex = NULL;
	}

	void Update () {
		if (arrowTransform.gameObject.activeInHierarchy) {
			transform.localEulerAngles = Vector3.zero;
			Vector3 realDirection = destinationPosition - transform.position;
			Vector3 pivotNormal = cameraTransform.position - transform.position;
			Vector3 projectedDirection = Vector3.ProjectOnPlane (realDirection, pivotNormal);
			Vector3 arrowZeroPosition = arrowTransform.position - transform.position;
			float angle = Vector3.SignedAngle (arrowZeroPosition, projectedDirection, pivotNormal);
			transform.localEulerAngles = Vector3.back * angle;
		}
	}

	public void PointTo (Vector3 destinationPosition, int destinationIndex) {
		this.destinationPosition = destinationPosition;
		this.destinationIndex = destinationIndex;
		if (destinationIndex != NULL) {
			arrowTransform.gameObject.SetActive (true);
		} else {
			arrowTransform.gameObject.SetActive (false);
		}
	}

	public void Enter (int objectIndex) {
		foreach (VrCanvas vrCanvas in vrCanvases) {
			if (vrCanvas.index != objectIndex) {
				vrCanvas.canvas.SetActive (false);
			}
		}
		if (objectIndex == destinationIndex) {
			arrowTransform.gameObject.SetActive (false);
			destinationIndex = NULL;
		}
	}

	public void Exit () {
		if (destinationIndex != NULL) {
			arrowTransform.gameObject.SetActive (true);
		}
	}
}
