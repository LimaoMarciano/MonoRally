using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DebugBoolean : MonoBehaviour {

	public Text label;
	public Image tick;

	// Use this for initialization
	void Start () {
		SetValue (false);
	}

	public void SetLabel (string text) {
		label.text = text;
	}

	public void SetValue (bool value) {
		if (value) {
			tick.gameObject.SetActive (true);
		} else {
			tick.gameObject.SetActive (false);
		}
	}
}
