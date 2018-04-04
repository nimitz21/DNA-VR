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
	}

	[SerializeField]
	private float TRANSITION_SPEED = 5f;
	[SerializeField]
	private Image blockingPanelImage;
	[SerializeField]
	private List<Text> textList;

	private int currentPage = 0;
	private int transition = Transition.IDLE;

	void Update () {
		if (blockingPanelImage.color.a > 0) {
			blockingPanelImage.color = new Color (0, 0, 0, blockingPanelImage.color.a - TRANSITION_SPEED * Time.deltaTime);
			blockingPanelImage.gameObject.SetActive (false);
		} else {
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
					}
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
		blockingPanelImage.color = new Color (0, 0, 0, 1); 
		blockingPanelImage.gameObject.SetActive (true);
	}

	public void NextPage () {
		transition = Transition.NEXT;
	}

}
