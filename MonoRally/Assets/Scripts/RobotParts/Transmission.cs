using UnityEngine;
using System.Collections;

/// <summary>
/// The transmission is responsible for applying different ratios to torque and speed generated
/// from the engine and transmiting the processed values to the wheel
/// </summary>
public class Transmission : MonoBehaviour {

	private Robot robot;

	private float[] gears;				//Array of gear ratios
	private int currentGear = 0;		//Which gear is engaged
	private float clutch = 1;			//How much the clutch is engaged
	private float clutchTimer = 0.5f;	//How many time it takes to shift gear
	private float inputSpeed;			//Input speed received by transmission
	private float inputTorque;			//Torque received by transmission
	private float outputSpeed;			//Processed max speed sent to wheels
	private float outputTorque;			//Processed torque sent to wheel

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

	/// <summary>
	/// Applies speed and torque to the transmission to be processed
	/// </summary>
	public void ApplyMotorForce (float speed, float torque) {
		inputSpeed = speed;
		inputTorque = torque;
	}

	/// <summary>
	/// Increase the current gear
	/// </summary>
	public void UpShift () {
		
		if (currentGear < gears.Length - 1) {
			if (clutchShift != null) {
				StopCoroutine (clutchShift);
			}
			clutchShift = ClutchShift ();
			StartCoroutine (clutchShift);

			currentGear += 1;
		}
	}

	/// <summary>
	/// Decrease the current gear. If current gear is below zero, then sets the beheviour for neutral
	/// </summary>
	public void DownShift () {

		if (currentGear >= 0) {
			if (clutchShift != null) {
				StopCoroutine (clutchShift);
			}
			currentGear -= 1;
			if (currentGear == -1) {
				clutch = 0;
				currentGear = -1;
			} else {
				clutchShift = ClutchShift ();
				StartCoroutine (clutchShift);
			}
		}
	}

	public float[] GetGears () {
		return gears;
	}

	public int GetCurrentGear () {
		return currentGear;
	}

	public float GetCurrentGearRatio () {
		if (currentGear > -1) {
			return gears [currentGear];
		} else {
			return 1;
		}
	}

	public float GetSpeed () {
		return outputSpeed;
	}

	public float GetTorque () {
		return outputTorque;
	}

	public float GetClutch () {
		return clutch;
	}

	//Private methods
	//
	//************************************************************

	/// <summary>
	/// Timer to simulate clutch being pressed, temporarilly cutting out the transmission
	/// </summary>
	/// <returns>The shift.</returns>
	IEnumerator ClutchShift () {
		clutch = 0;
		float timer = 0;
		while (timer < clutchTimer ) {
			timer += Time.fixedDeltaTime;
			clutch = timer / clutchTimer;
			yield return null;
		}
		clutch = 1;
	}
}
