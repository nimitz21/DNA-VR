using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Prologue : MonoBehaviour {

	private const string FIRST_SCENE_NAME = "Circus";

	public const int NULL = -1;

	public class Transition {
		public const int IDLE = 0;
		public const int NEXT = 1;
		public const int PREV = -1;
	}

	[SerializeField]
	private float TRANSITION_SPEED = 5f;
	[SerializeField]
	private List<Text> textList;

	private int currentPage = 0;
	private int transition = Transition.IDLE;

	void Update () {
		if (transition == Transition.IDLE) {
			if (textList [currentPage].color.a < 1f) {
				textList [currentPage].color = new Color (
					textList [currentPage].color.r,
					textList [currentPage].color.g,
					textList [currentPage].color.b,
					textList [currentPage].color.a + TRANSITION_SPEED * Time.deltaTime);
			}
		} else {
			if (textList [currentPage].color.a > 0) {
				textList [currentPage].color = new Color (
					textList [currentPage].color.r,
					textList [currentPage].color.g,
					textList [currentPage].color.b,
					textList [currentPage].color.a - TRANSITION_SPEED * Time.deltaTime);
			} else {
				currentPage += transition;
				transition = 0;
				if (currentPage == textList.Count) {
					SceneController.Instance.LoadScene (FIRST_SCENE_NAME);
				} else if (currentPage == NULL) {
					GetComponent <ChildCanvas> ().Back ();
				}
			}
		}
	}

	public void Open () {
		if (currentPage >= 0) {
			textList [currentPage].color = new Color (
				textList [currentPage].color.r,
				textList [currentPage].color.g,
				textList [currentPage].color.b,
				0);
		}
		currentPage = 0;
		transition = Transition.IDLE;
	}

	public void NextPage () {
		transition = Transition.NEXT;
	}

	public void PrevPage () {
		transition = Transition.PREV;
	}

}
