using UnityEngine;
using System.Collections;

public class Engine : MonoBehaviour {

	[Header("Settings")]
	public float maxSpeed;
	public float maxTorque;
	public float engineBrakeForce;
	public AnimationCurve torqueCurve;

	[Header("Components")]
	public WheelJoint2D wheelJoint;
	public Rigidbody2D wheelRb;
	public WheelGroundDetector groundDetector;

	private float input;
	private float speed = 0;
	private float torque;
	private float engineBrakeTorque;
	private float engineBrakeDrag;
	private float wheelAngularDrag;

	private float smoothV = 0;

	private JointMotor2D mt = new JointMotor2D();
	public bool isEngineClutched = true;

	// Use this for initialization
	void Start () {
		wheelAngularDrag = wheelRb.angularDrag;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (isEngineClutched) {

			speed = Mathf.SmoothDamp(speed, maxSpeed, ref smoothV, 0.1f);
			torque = torqueCurve.Evaluate (-wheelJoint.jointSpeed / maxSpeed) * maxTorque * input;

			wheelJoint.motor = SetMotorValues (torque, -speed);

			//Engine brake effects
			if (input == 0) {
				wheelRb.angularDrag = wheelAngularDrag + (-wheelJoint.jointSpeed * engineBrakeForce) / maxSpeed;
			} else {
				wheelRb.angularDrag = wheelAngularDrag;
			}


		} else {
			//Engine running loose
			float targetSpeed = maxSpeed * input;
			speed = Mathf.SmoothDamp (speed, targetSpeed, ref smoothV, 0.1f);
			torque = torqueCurve.Evaluate (speed / maxSpeed) * maxTorque;

			wheelJoint.motor = SetMotorValues (0, 0);
		}

	}

	public void SetInput (float value) {
		input = value;
	}

	public void ToggleCluth () {
		isEngineClutched = !isEngineClutched;
	}

	public float GetSpeed () {
		return speed;
	}

	public float GetTorque () {
		return torque;
	}

	private JointMotor2D SetMotorValues (float motorTorque, float motorSpeed) {
		mt.maxMotorTorque = motorTorque;
		mt.motorSpeed = motorSpeed;
		return mt;
	}
}
