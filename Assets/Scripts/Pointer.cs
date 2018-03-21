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
		
	[SerializeField]
	private float MAGNITUDE_THRESHOLD = 0.75f;
	[SerializeField]
	private Transform cameraTransform;

	private Vector3 destination;
	private Transform arrowTransform;

	void Start () {
		if (arrowTransform == null) {
			arrowTransform = transform.GetChild (0);
		}
	}

	void Update () {
		if (arrowTransform.gameObject.activeInHierarchy) {
			transform.localEulerAngles = Vector3.zero;
			Vector3 realDirection = destination - transform.position;
			Vector3 pivotNormal = cameraTransform.position - transform.position;
			Vector3 projectedDirection = Vector3.ProjectOnPlane (realDirection, pivotNormal);
			if (projectedDirection.magnitude > MAGNITUDE_THRESHOLD) {
				Vector3 arrowZeroPosition = arrowTransform.position - transform.position;
				float angle = Vector3.SignedAngle (arrowZeroPosition, projectedDirection, pivotNormal);
				transform.localEulerAngles = Vector3.back * angle;
			} else {
				arrowTransform.gameObject.SetActive (false);
			}
		}
	}

	public void PointTo (Vector3 destination) {
		this.destination = destination;
		arrowTransform.gameObject.SetActive (true);
	}

}
