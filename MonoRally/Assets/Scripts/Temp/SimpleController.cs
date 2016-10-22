using UnityEngine;
using System.Collections;

public class SimpleController : MonoBehaviour {

	private Robot robot;
	private Engine engine;

	// Use this for initialization
	void Start () {
		engine = GetComponent<Engine> ();
		robot = GetComponent<Robot> ();
	}
	
	// Update is called once per frame
	void Update () {
		float hInput = Input.GetAxis ("Horizontal");
		robot.engine.SetInput (hInput);
		robot.wheel.SetFacing (hInput);

		if (Input.GetButtonDown ("Jump")) {
			engine.ToggleCluth ();
		}
	}
}
