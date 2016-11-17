using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DebugValue : MonoBehaviour {

	public Text label;
	public Text value;

	public void SetLabel (string text) {
		label.text = text;
	}

	public void SetValue (float number, bool isFractional) {
		if (isFractional) {
			value.text = number.ToString ("F1");
		} else {
			value.text = number.ToString ("F0");
		}
	}

	public void SetValue (int number) {
		value.text = number.ToString ();
	}
}
