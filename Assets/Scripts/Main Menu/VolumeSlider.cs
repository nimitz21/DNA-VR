using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour {

	private Slider slider;

	void Start () {
		slider = GetComponent <Slider> ();
		slider.value = PlayerPrefs.GetFloat (VolumeController.VOLUME_PREF_KEY);
	}

	public void ChangeVolume () {
		VolumeController.Instance.SetVolume (slider.value);
	}

}
