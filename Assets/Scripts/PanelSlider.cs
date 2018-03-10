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
	private float MOVE_SPEED = 1f;
	[SerializeField]
	private List <RectTransform> panelTransforms;
	[SerializeField]
	private Swipe swipeController;

	private int moveDirection;
	private float distanceMoved;
	private int currentPosition;

	void Start () {
		moveDirection = Move.IDLE;
		distanceMoved = 0;
		currentPosition = 0;
	}

	void Update () {
		// Detect Swipe
		if (swipeController.SwipeLeft && currentPosition < panelTransforms.Count - 1) {
			moveDirection = Move.LEFT;
		}
		if (swipeController.SwipeRight && currentPosition > 0) {
			moveDirection = Move.RIGHT;
		}
	
		if (moveDirection == Move.LEFT && distanceMoved > -MOVE_DISTANCE) {
			// Move panels to left
			if (distanceMoved - MOVE_SPEED > -MOVE_DISTANCE) {
				foreach (RectTransform panelTransform in panelTransforms) {
					panelTransform.localPosition = panelTransform.localPosition + Vector3.left * MOVE_SPEED;
				}
				distanceMoved -= MOVE_SPEED;
			} else {
				foreach (RectTransform panelTransform in panelTransforms) {
					panelTransform.localPosition = panelTransform.localPosition + Vector3.left * (MOVE_DISTANCE + distanceMoved);
				}
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
				foreach (RectTransform panelTransform in panelTransforms) {
					panelTransform.localPosition = panelTransform.localPosition + Vector3.right * MOVE_SPEED;
				}
				distanceMoved += MOVE_SPEED;
			} else {
				foreach (RectTransform panelTransform in panelTransforms) {
					panelTransform.localPosition = panelTransform.localPosition + Vector3.right * (MOVE_DISTANCE - distanceMoved);
				}
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
