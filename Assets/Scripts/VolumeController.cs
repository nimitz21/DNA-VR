using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour {

	private static VolumeController instance;
	public static VolumeController Instance {
		get {
			if (instance == null) {
				instance = FindObjectOfType <VolumeController> ();
			}
			return instance;
		}
	}

	public const string VOLUME_PREF_KEY = "volume";

	public void SetVolume (float volume) {
		PlayerPrefs.SetFloat (VOLUME_PREF_KEY, volume); 
	}

}
