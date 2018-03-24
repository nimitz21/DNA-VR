using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour {

	[SerializeField]
	[Range (0, 1f)]
	private float volume = 0.5f;

	private AudioSource audioSource;

	void Start () {
		audioSource = GetComponent <AudioSource> ();
		audioSource.volume = volume * PlayerPrefs.GetFloat (VolumeController.VOLUME_PREF_KEY);
	}
}
