using UnityEngine;
using System.Collections;

public class Transmission : MonoBehaviour {

	private Robot robot;

	private float[] gears;
	private int currentGear = 0;
	private float clutch = 1;
	private float inputSpeed;
	private float inputTorque;
	private float outputSpeed;
	private float outputTorque;

	private IEnumerator clutchShift;

	void FixedUpdate () {

		if (currentGear >= 0) {
			outputSpeed = inputSpeed / gears [currentGear];
			outputTorque = inputTorque * gears [currentGear] * clutch;
			robot.engine.SetSpeed (robot.wheelJoint.jointSpeed * gears [currentGear] * clutch);
		} else {
			outputSpeed = 0;
			outputTorque = 0;
		}

		robot.wheel.ApplyMotorForce (outputSpeed, outputTorque);

	}

	//Public methods
	//
	//*************************************************************
	public void LoadData (TransmissionData data) {
		robot = GetComponentInParent<Robot> ();
		gears = data.gears;
	}

	public void ApplyMotorForce (float speed, float torque) {
		inputSpeed = speed;
		inputTorque = torque;
	}

	public void UpShift () {
		if (clutchShift != null) {
			StopCoroutine (clutchShift);
		}
			clutchShift = ClutchShift ();
			StartCoroutine (clutchShift);

		if (currentGear < gears.Length) {
			currentGear += 1;
		}
	}

	public void DownShift () {
		if (clutchShift != null) {
			StopCoroutine (clutchShift);
		}

		currentGear -= 1;
		if (currentGear <= 0) {
			robot.engine.isEngineClutched = false;
			clutch = 0;
		} else {
			clutchShift = ClutchShift ();
			StartCoroutine (clutchShift);
		}
	}

	public float GetCurrentGear () {
		return currentGear;
	}

	public float GetCurrentGearRatio () {
		if (currentGear > 0) {
			return gears [currentGear];
		} else {
			return 1;
		}
	}

	public float GetCurrentTorque () {
		return outputTorque;
	}

	public float GetClutch () {
		return clutch;
	}

	//Private methods
	//
	//************************************************************

	IEnumerator ClutchShift () {
		clutch = 0;
//		robot.engine.isEngineClutched = false;
		while (clutch < 1) {
			clutch += 0.05f;
			yield return null;
		}
		clutch = 1;
	}
}
