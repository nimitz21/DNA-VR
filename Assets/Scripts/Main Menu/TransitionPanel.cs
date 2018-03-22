using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TransitionPanel : MonoBehaviour
{

	[SerializeField]
	private Image left;
	[SerializeField]
	private Image right;

	public Image Left { get { return left; } }
	public Image Right{ get { return right; } }
}

