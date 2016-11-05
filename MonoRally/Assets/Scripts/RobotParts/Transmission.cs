using UnityEngine;
using System.Collections;

public class Transmission : MonoBehaviour {

	private Robot robot;

	private float[] gears;
	private int currentGear = 1;
	private float inputSpeed;
	private float inputTorque;
	private float outputSpeed;
	private float outputTorque;

	void FixedUpdate () {
		if (currentGear > 0) {
			outputSpeed = inputSpeed / gears [currentGear - 1];
			outputTorque = inputTorque * gears [currentGear - 1];
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
		if (currentGear < gears.Length) {
			robot.engine.isEngineClutched = true;
			currentGear += 1;
		}
	}

	public void DownShift () {
		currentGear -= 1;
		if (currentGear <= 0) {
			robot.engine.isEngineClutched = false;
			currentGear = 0;
		}
	}

	public float GetCurrentGear () {
		return currentGear;
	}

	public float GetCurrentGearRatio () {
		if (currentGear > 0) {
			return gears [currentGear - 1];
		} else {
			return 0;
		}
	}
}
