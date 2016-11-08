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

	private float inputSpeed;
	private float outputSpeed;
	private float outputTorque;
	private float clutch;

	private float smoothV = 0;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void FixedUpdate () {

		clutch = robot.transmission.GetClutch ();

		//When engine is clutched, current engine speed is driven by wheel speed
		if (clutch >= 1) {

			float gearRatio = robot.transmission.GetCurrentGearRatio ();
			speed = Mathf.SmoothDamp(speed, inputSpeed, ref smoothV, 0.05f);
			speed = Mathf.Clamp (speed, minSpeed, maxSpeed);

			outputTorque = torqueCurve.Evaluate (speed / maxSpeed) * maxTorque * input;

			//Engine brake effects. Higher engine speeds increase engine resistence
			if (input == 0) {
				float brakeForce = (speed * engineBrakeForce) / maxSpeed;
				robot.wheel.ApplyEngineDrag (brakeForce * gearRatio);
			} else {
				robot.wheel.ApplyEngineDrag (0);
			}

			robot.transmission.ApplyMotorForce (maxSpeed, outputTorque);
		
		//When engine isn't clutched, engine speed is controlled by a fake inertia based on accelerator input
		} else {
			
			float targetSpeed = Mathf.Lerp (maxSpeed * input, inputSpeed, robot.transmission.GetClutch());
			speed = Mathf.SmoothDamp (speed, targetSpeed, ref smoothV, 0.1f);
			outputTorque = torqueCurve.Evaluate (speed / maxSpeed) * maxTorque;

			robot.wheelJoint.SetMotorValues (0, 0);
			robot.wheel.ApplyEngineDrag (0);

			robot.transmission.ApplyMotorForce (maxSpeed, outputTorque);
		}

	}

	public void SetInput (float value) {
		input = Mathf.Abs (value);
	}

	public void SetSpeed (float value) {
		inputSpeed = Mathf.Abs (value);
	}

	public float GetSpeed () {
		return speed;
	}

	public float GetTorque () {
		return outputTorque;
	}

	public void LoadData (EngineData data) {
		maxSpeed = data.maxSpeed;
		minSpeed = data.minSpeed;
		maxTorque = data.maxTorque;
		engineBrakeForce = data.engineBrakeForce;
		torqueCurve = data.torqueCurve;

		Debug.Log ("Engine data loaded.");
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
