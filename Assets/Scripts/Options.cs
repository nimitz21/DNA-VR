using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour {

	[SerializeField]
	private float ANGLE_THRESHOLD = 50f;
	[SerializeField]
	private float DISAPPEAR_TIME = 3f;
	[SerializeField]
	private Transform cameraTransform;

	private bool willShow;
	private GameObject canvas;
	private bool isTimerRunning;
	private float disappearTimer;

	void Start () {
		willShow = true;
		canvas = transform.GetChild (0).gameObject;
		isTimerRunning = false;
	}

	void Update () {
		if (!canvas.activeInHierarchy) {
			if (cameraTransform.eulerAngles.x >= ANGLE_THRESHOLD && willShow) {
				transform.eulerAngles = Vector3.up * cameraTransform.eulerAngles.y;
				canvas.SetActive (true);
				willShow = false;
			} else if (cameraTransform.eulerAngles.x < ANGLE_THRESHOLD) {
				willShow = true;
			}
		} else {
			if (cameraTransform.eulerAngles.x < ANGLE_THRESHOLD) {
				canvas.SetActive (false);
				willShow = true;
			} else if (isTimerRunning) {
				disappearTimer -= Time.deltaTime;
				if (disappearTimer <= 0) {
					canvas.SetActive (false);
				}
			}
		}
	}

	public void ResetTimer () {
		isTimerRunning = true;
		disappearTimer = DISAPPEAR_TIME;
	}

	public void StopTimer () {
		isTimerRunning = false;
	}
		
}
