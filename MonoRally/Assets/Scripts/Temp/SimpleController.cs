using UnityEngine;
using System.Collections;

public class SimpleController : MonoBehaviour {

	private Robot robot;

	// Use this for initialization
	void Start () {
		robot = GetComponent<Robot> ();
	}
	
	// Update is called once per frame
	void Update () {
		float hInput = Input.GetAxis ("Horizontal");
		robot.engine.SetInput (hInput);
		robot.wheel.SetFacing (hInput);

		float brakeInput = Input.GetAxis ("Brake");
		robot.brakes.SetInput (brakeInput);
		Debug.Log (brakeInput);

		robot.jumpMechanism.JumpInput (Input.GetButton ("Jump"));

	}
}
