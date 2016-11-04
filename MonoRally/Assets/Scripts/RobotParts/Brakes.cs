using UnityEngine;
using System.Collections;

public class Brakes : MonoBehaviour {

	public float brakeTorque = 0f;

	private Robot robot;
	private float input = 0;

	// Use this for initialization
	void Start () {
		robot = GetComponentInParent<Robot> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		robot.wheel.ApplyBrakeForce (brakeTorque * input);
	}

	public void SetInput (float value) {
		input = value;
	}

	public void LoadData (BrakeData data) {
		brakeTorque = data.brakeTorque;

		Debug.Log ("Brake data loaded.");
	}

}
