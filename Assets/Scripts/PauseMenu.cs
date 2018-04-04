using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

	private const int SCENE_NUMBER_OFFSET = 1;

	[System.Serializable]
	public class SceneOption {
		public string name;
		public string title;
		public Sprite normalSprite;
		public Sprite hoverSprite;
		public string subtitle;
		public Sprite pageSprite;
	}

	[SerializeField]
	private int currentScene;
	[SerializeField]
	private float ROTATION = 20f;
	[SerializeField]
	private GvrPointerPhysicsRaycaster physicsRaycaster;
	[SerializeField]
	private List <SceneOption> scenes; 
	[SerializeField]
	private GameObject options;
	[SerializeField]
	private Transform pivot;
	[SerializeField]
	private GameObject prevButton;
	[SerializeField]
	private GameObject nextButton;
	[SerializeField]
	private Text selectedSceneTitle;
	[SerializeField]
	private Image selectedSceneImage;
	[SerializeField]
	private Text selectedSceneSubtitle;
	[SerializeField]
	private Image selectedScenePage;

	private int selectedScene;

	void Start () {
		selectedScene = currentScene - SCENE_NUMBER_OFFSET;
		pivot.localEulerAngles = new Vector3 (0, -selectedScene * ROTATION, 0);
		if (selectedScene == 0) {
			prevButton.SetActive (false);
		} else if (selectedScene == scenes.Count - SCENE_NUMBER_OFFSET) {
			nextButton.SetActive (false);
		}
		pivot.GetChild (selectedScene).gameObject.SetActive (false);
		UpdateSelectedScene ();
	}

	void UpdateSelectedScene () {
		selectedSceneTitle.text = scenes [selectedScene].title;
		selectedSceneImage.sprite = scenes [selectedScene].normalSprite;
		selectedSceneSubtitle.text = scenes [selectedScene].subtitle;
		selectedScenePage.sprite = scenes [selectedScene].pageSprite;
	}

	public void Show () {
		gameObject.SetActive (true);
		options.SetActive (false);
		Pointer.Instance.HideAllVrCanvas ();
		physicsRaycaster.eventMask -= 1;
	}

	public void NextScene () {
		pivot.localEulerAngles = new Vector3 (0, pivot.localEulerAngles.y - ROTATION, 0);
		if (selectedScene == 0) {
			prevButton.SetActive (true);
		}
		pivot.GetChild (selectedScene).gameObject.SetActive (true);
		++selectedScene;
		pivot.GetChild (selectedScene).gameObject.SetActive (false);
		if (selectedScene == scenes.Count - SCENE_NUMBER_OFFSET) {
			nextButton.SetActive (false);
		}
		UpdateSelectedScene ();
	}

	public void PrevScene () {
		pivot.localEulerAngles = new Vector3 (0, pivot.localEulerAngles.y + ROTATION, 0);
		if (selectedScene == scenes.Count - SCENE_NUMBER_OFFSET) {
			nextButton.SetActive (true);
		}
		pivot.GetChild (selectedScene).gameObject.SetActive (true);
		--selectedScene;
		pivot.GetChild (selectedScene).gameObject.SetActive (false);
		if (selectedScene == 0) {
			prevButton.SetActive (false);
		}
		UpdateSelectedScene ();
	}

	public void ChooseScene () {
		SceneController.Instance.LoadScene (scenes [selectedScene].name);
	}

	public void BackToHome () {
		StartCoroutine (VRController.Instance.BackToMainMenu ());
	}

}
