using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GradientSlider : MonoBehaviour {

	[SerializeField]
	private Color EMPTY_COLOR;
	[SerializeField]
	private Color FULL_COLOR;

	private Slider slider;
	private Image sliderBackground;
	private Image sliderHandle;
	private Gradient gradient;

	void Awake () {
		slider = GetComponent <Slider> ();
		sliderBackground = slider.transform.GetChild (0).GetComponent <Image> ();
		sliderHandle = slider.transform.GetChild (1).GetChild (0).GetComponent <Image> ();
		gradient = new Gradient ();
		GradientColorKey[] gradientColorKey = new GradientColorKey[2];
		gradientColorKey [0].color = EMPTY_COLOR;
		gradientColorKey [0].time = 0;
		gradientColorKey [1].color = FULL_COLOR;
		gradientColorKey [1].time = 1f;
		GradientAlphaKey[] gradientAlphaKey = new GradientAlphaKey[2];
		gradientAlphaKey [0].alpha = 1f;
		gradientAlphaKey [0].time = 0;
		gradientAlphaKey [1].alpha = 1f;
		gradientAlphaKey [1].time = 1f;
		gradient.SetKeys (gradientColorKey, gradientAlphaKey);
	}

	public void ChangeColor () {
		Color newColor = gradient.Evaluate (slider.value);
		sliderBackground.color = newColor;
		sliderHandle.color = newColor;
	}
		
}
