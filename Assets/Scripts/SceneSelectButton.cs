using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSelectButton : MonoBehaviour {

	[SerializeField]
	private float UP_SCALE = 0.1f;

	private Vector3 normalScale;

	void Start () {
		normalScale = transform.localScale;
	}

	public void ScaleUp () {
		transform.localScale = normalScale + Vector3.one * UP_SCALE;
	}

	public void Revert () {
		transform.localScale = normalScale;
	}

}
