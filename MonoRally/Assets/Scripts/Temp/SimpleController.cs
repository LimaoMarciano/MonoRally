﻿using UnityEngine;
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

		robot.jumpMechanism.JumpInput (Input.GetButton ("Jump"));

		if (Input.GetButtonDown ("DownShift")) {
			robot.transmission.DownShift ();
		}

		if (Input.GetButtonDown ("UpShift")) {
			robot.transmission.UpShift ();
		}

		robot.boost.ChargeBoost (Input.GetButton ("Boost"));
		if (Input.GetButtonUp ("Boost")) {
			robot.boost.ReleaseBoost ();
		}


	}
}
