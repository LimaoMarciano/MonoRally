using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DebugWindowController : MonoBehaviour {

	public GameObject debugWindow;
	private bool isActive = false;

	// Use this for initialization
	void Start () {
		debugWindow.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.F9)) {
			isActive = !isActive;
			debugWindow.SetActive (isActive);
		}
	}
}
