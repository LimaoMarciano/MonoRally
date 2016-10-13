using UnityEngine;
using System.Collections;

public class Engine : MonoBehaviour {

	public float maxSpeed;
	public float maxTorque;
	public AnimationCurve torqueCurve;
	public WheelJoint2D wheelJoint;

	public float force;
	public float engineDrag;
	public float wheelDrag;

	private float input;
	private float speed = 0;
	private float torque;

	public bool isEngineClutched = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float wheelSpeedDif;



		float dragforce = (Mathf.Pow(speed, 2) / 2) * engineDrag * Time.deltaTime;
		speed -= dragforce;

		if (isEngineClutched) {
			wheelSpeedDif = -wheelJoint.jointSpeed - speed;
			Debug.Log (wheelSpeedDif);
			if (wheelSpeedDif <= 0) {
				speed -= Mathf.Pow (wheelSpeedDif, 2) * wheelDrag * Time.deltaTime;
			} else {
				speed += Mathf.Pow (wheelSpeedDif, 2) * wheelDrag * Time.deltaTime;
			}
		}
		float addforce = input * force * Time.deltaTime;
		speed += addforce;



		speed = Mathf.Clamp (speed, 0, maxSpeed);

//		speed = maxSpeed * input;
		torque = torqueCurve.Evaluate (speed / maxSpeed) * maxTorque;

		JointMotor2D mt = wheelJoint.motor;
		mt.motorSpeed = -speed;
		mt.maxMotorTorque = torque;
		wheelJoint.motor = mt;
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
