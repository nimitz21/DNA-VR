using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour {

	private bool tap;
	private bool swipeLeft;
	private bool swipeRight;
	private bool swipeUp;
	private bool swipeDown;
	private bool isDragging;

	private Vector2 startTouch;
	private Vector2 swipeDelta;

	void Update () {
		tap = swipeLeft = swipeRight = swipeUp = swipeDown = false;

		#region Mouse Inputs
		if (Input.GetMouseButtonDown (0)) {
			tap = true;
			isDragging = true;
			startTouch = Input.mousePosition;
		} else if (Input.GetMouseButtonUp (0)) {
			isDragging = false;
			Reset ();
		}
		#endregion

		#region Mobile Inputs
		if (Input.touches.Length > 0) {
			if (Input.touches [0].phase == TouchPhase.Began) {
				isDragging = true;
				tap = true;
				startTouch = Input.touches[0].position;
			} else if (Input.touches [0].phase == TouchPhase.Ended || Input.touches [0].phase == TouchPhase.Canceled) {
				isDragging = false;
				Reset ();
			}
		}
		#endregion

		// Calculate swipe distance
		if (isDragging) {
			if (Input.touches.Length > 0) {
				swipeDelta = Input.touches [0].position - startTouch;
			} else if (Input.GetMouseButton (0)) {
				swipeDelta = (Vector2)Input.mousePosition - startTouch;
			}
		}

		if (swipeDelta.magnitude > 100) {
			if (Mathf.Abs (swipeDelta.x) > Mathf.Abs (swipeDelta.y)) {
				if (swipeDelta.x < 0) {
					swipeLeft = true;
				} else {
					swipeRight = true;
				}
			} else {
				if (swipeDelta.y < 0) {
					swipeDown = true;
				} else {
					swipeUp = true;
				}
			}

			Reset ();
		}
	}

	void Reset () {
		startTouch = swipeDelta = Vector2.zero;
		isDragging = false;
	}

	public Vector2 SwipeDelta { get { return swipeDelta; }}

	public bool SwipeLeft { get { return swipeLeft; } }
	public bool SwipeRight { get { return swipeRight; } }
	public bool SwipeUp { get { return swipeUp; } }
	public bool SwipeDown { get { return swipeDown; } }
		
}
