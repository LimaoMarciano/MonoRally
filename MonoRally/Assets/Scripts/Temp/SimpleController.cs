using UnityEngine;
using System.Collections;

public class SimpleController : MonoBehaviour {

	private Engine engine;

	// Use this for initialization
	void Start () {
		engine = GetComponent<Engine> ();
	}
	
	// Update is called once per frame
	void Update () {
		float hInput = Input.GetAxis ("Horizontal");
		engine.SetInput (hInput);

		if (Input.GetButtonDown ("Fire1")) {
			engine.ToggleCluth ();
		}
	}
}
