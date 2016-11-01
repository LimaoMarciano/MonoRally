using UnityEngine;
using System.Collections;

public class Brakes : MonoBehaviour {

	public float brakeDrag = 400f;

	private Robot robot;
	private float input;

	// Use this for initialization
	void Start () {
		robot = GetComponentInParent<Robot> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		robot.wheel.ApplyBrakeForce (brakeDrag * input, input);
	}

	public void SetInput (float value) {
		input = value;
	}

}
