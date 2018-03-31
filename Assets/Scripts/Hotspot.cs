using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotspot : MonoBehaviour {

	[SerializeField]
	Transform cameraTransform;

	private Vector3 normalScale;

	void Start () {
		normalScale = transform.GetChild (0).localScale;
	}

	void Update () {
		transform.eulerAngles = cameraTransform.eulerAngles;	
	}
}
