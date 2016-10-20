using UnityEngine;
using System.Collections;

public class Engine : MonoBehaviour {

	public float maxSpeed;
	public float maxTorque;
	public float engineBrakeForce;
	public AnimationCurve torqueCurve;

	private Robot robot;
	private float minSpeed;
	private float input;
	private float speed = 0;
	private float torque;
	private float wheelAngularDrag;
	private JointMotor2D mt = new JointMotor2D();

	private float smoothV = 0;

	public bool isEngineClutched = true;

	// Use this for initialization
	void Start () {
		wheelAngularDrag = robot.wheelRigidbody.angularDrag;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		//When engine is clutched, current engine speed is driven by wheel speed
		if (isEngineClutched) {
			float wheelSpeed = Mathf.Abs (robot.wheelJoint.jointSpeed);
			speed = Mathf.SmoothDamp(speed, wheelSpeed, ref smoothV, 0.05f);
			speed = Mathf.Clamp (speed, minSpeed, maxSpeed);
			torque = torqueCurve.Evaluate (speed / maxSpeed) * maxTorque * input;

			//Engine brake effects. Higher engine speeds increase engine resistence
			if (input == 0) {
				robot.wheelRigidbody.angularDrag = wheelAngularDrag + (speed * engineBrakeForce) / maxSpeed;
			} else {
				robot.wheelRigidbody.angularDrag = wheelAngularDrag;
			}

			//Temporary code for direct wheel control
//			robot.wheelJoint.SetMotorValues (torque, -maxSpeed);

			robot.wheel.ApplyMotorForce (maxSpeed, torque);
		
		//When engine isn't clutched, engine speed is controlled by a fake inertia based on accelerator input
		} else {
			
			float targetSpeed = maxSpeed * input;
			speed = Mathf.SmoothDamp (speed, targetSpeed, ref smoothV, 0.1f);
			torque = torqueCurve.Evaluate (speed / maxSpeed) * maxTorque;

			robot.wheelJoint.SetMotorValues (0, 0);
		}

	}

	public void SetInput (float value) {
		input = Mathf.Abs (value);
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

	public void LoadData (EngineData data) {
		maxSpeed = data.maxSpeed;
		minSpeed = data.minSpeed;
		maxTorque = data.maxTorque;
		engineBrakeForce = data.engineBrakeForce;
		torqueCurve = data.torqueCurve;
	}

	public void SetRobotReference (Robot robotRef) {
		robot = robotRef;
	}

//	private JointMotor2D SetMotorValues (float motorTorque, float motorSpeed) {
//		mt.maxMotorTorque = motorTorque;
//		mt.motorSpeed = motorSpeed;
//		return mt;
//	}


		
}
