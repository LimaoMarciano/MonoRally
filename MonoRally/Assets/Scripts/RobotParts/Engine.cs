using UnityEngine;
using System.Collections;

public class Engine : MonoBehaviour {

	public float maxSpeed;
	public float maxTorque;
	public AnimationCurve torqueCurve;

	private float input;
	private float speed;
	private float torque;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		speed = maxSpeed * input;
		torque = torqueCurve.Evaluate (speed / maxSpeed) * maxTorque;
	}

	public void SetInput (float value) {
		input = value;
	}

	public float GetSpeed () {
		return speed;
	}

	public float GetTorque () {
		return torque;
	}
}
