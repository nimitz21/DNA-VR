using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelSlider : MonoBehaviour {

	public class Move {
		public const int IDLE = 0;
		public const int LEFT = -1;
		public const int RIGHT = 1;
	}

	private static float MOVE_DISTANCE = 1080;

	[SerializeField]
	[Range (0, 0.5f)]
	private float SWIPE_THRESHOLD = 0.5f;
	[SerializeField]
	private float MOVE_SPEED = 1f;
	[SerializeField]
	private List <RectTransform> panelTransforms;

	private int moveDirection;
	private float distanceMoved;
	private int currentPosition;

	void Start () {
		moveDirection = Move.IDLE;
		distanceMoved = 0;
		currentPosition = 0;
	}

	void Update () {
		//Debug.Log (Swipe.Instance.SwipeDelta.x);
		if (moveDirection == Move.IDLE) {
			if (Swipe.Instance.SwipeDelta.x < 0 && currentPosition < panelTransforms.Count - 1) {
				distanceMoved = Swipe.Instance.SwipeDelta.x;
				transform.localPosition = Vector3.right * (-currentPosition * MOVE_DISTANCE + distanceMoved);

				// Change transition panels alpha
				TransitionPanel currentTransition = panelTransforms [currentPosition].GetComponent <TransitionPanel> ();
				currentTransition.Right.color = new Color (1, 1, 1, distanceMoved / -MOVE_DISTANCE);
				TransitionPanel nextTransition = panelTransforms [currentPosition + 1].GetComponent <TransitionPanel> ();
				nextTransition.Left.color = new Color (1, 1, 1, 1 - distanceMoved / -MOVE_DISTANCE);
			} else if (Swipe.Instance.SwipeDelta.x > 0 && currentPosition > 0) {
				distanceMoved = Swipe.Instance.SwipeDelta.x;
				transform.localPosition = Vector3.right * (-currentPosition * MOVE_DISTANCE + distanceMoved);

				// Change transition panels alpha
				TransitionPanel currentTransition = panelTransforms [currentPosition].GetComponent <TransitionPanel> ();
				currentTransition.Left.color = new Color (1, 1, 1, distanceMoved / MOVE_DISTANCE);
				TransitionPanel nextTransition = panelTransforms [currentPosition - 1].GetComponent <TransitionPanel> ();
				nextTransition.Right.color = new Color (1, 1, 1, 1 - distanceMoved / MOVE_DISTANCE);
			} else {
				if (distanceMoved > SWIPE_THRESHOLD && currentPosition > 0) {
					moveDirection = Move.RIGHT;
				} else if (distanceMoved > 0 && distanceMoved <= SWIPE_THRESHOLD) {
					--currentPosition;
					moveDirection = Move.LEFT;
					distanceMoved = -MOVE_DISTANCE + distanceMoved;
				} else if (distanceMoved < -SWIPE_THRESHOLD && currentPosition < panelTransforms.Count - 1) {
					moveDirection = Move.LEFT;
				} else if (distanceMoved < 0 && distanceMoved >= -SWIPE_THRESHOLD) {
					++currentPosition;
					moveDirection = Move.RIGHT;
					distanceMoved = MOVE_DISTANCE + distanceMoved;
				}
			}
		}
	
		if (moveDirection == Move.LEFT && distanceMoved > -MOVE_DISTANCE) {
			// Move panels to left
			if (distanceMoved - MOVE_SPEED > -MOVE_DISTANCE) {
				transform.localPosition = transform.localPosition + Vector3.left * MOVE_SPEED;
				distanceMoved -= MOVE_SPEED;
			} else {
				transform.localPosition = transform.localPosition + Vector3.left * (MOVE_DISTANCE + distanceMoved);
				distanceMoved = -MOVE_DISTANCE;
				moveDirection = Move.IDLE;
			}

			// Change transition panels alpha
			TransitionPanel currentTransition = panelTransforms [currentPosition].GetComponent <TransitionPanel> ();
			currentTransition.Right.color = new Color (1, 1, 1, distanceMoved / -MOVE_DISTANCE);
			TransitionPanel nextTransition = panelTransforms [currentPosition + 1].GetComponent <TransitionPanel> ();
			nextTransition.Left.color = new Color (1, 1, 1, 1 - distanceMoved / -MOVE_DISTANCE);

			// Update current position & reset distance moved
			if (moveDirection == Move.IDLE) {
				++currentPosition;
				distanceMoved = 0;
			}

		} else if (moveDirection == Move.RIGHT) {
			// Move panels to right
			if (distanceMoved + MOVE_SPEED < MOVE_DISTANCE) {
				transform.localPosition = transform.localPosition + Vector3.right * MOVE_SPEED;
				distanceMoved += MOVE_SPEED;
			} else {
				transform.localPosition = transform.localPosition + Vector3.right * (MOVE_DISTANCE - distanceMoved);
				distanceMoved = MOVE_DISTANCE;
				moveDirection = Move.IDLE;
			}

			// Change transition panels alpha
			TransitionPanel currentTransition = panelTransforms [currentPosition].GetComponent <TransitionPanel> ();
			currentTransition.Left.color = new Color (1, 1, 1, distanceMoved / MOVE_DISTANCE);
			TransitionPanel nextTransition = panelTransforms [currentPosition - 1].GetComponent <TransitionPanel> ();
			nextTransition.Right.color = new Color (1, 1, 1, 1 - distanceMoved / MOVE_DISTANCE);

			// Update current position & reset distance moved
			if (moveDirection == Move.IDLE) {
				--currentPosition;
				distanceMoved = 0;
			}
		}
	}
}
