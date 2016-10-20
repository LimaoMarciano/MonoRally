using UnityEngine;
using System.Collections;

public class Wheel : MonoBehaviour {

	private Robot robot;
	private int facing = -1;

	// Use this for initialization
	void Awake () {
		robot = GetComponentInParent<Robot> ();
	}
	
	// Update is called once per frame
//	void Update () {
//	
//	}

	public void ApplyMotorForce (float speed, float torque) {
		robot.wheelJoint.SetMotorValues (speed * facing, torque);
	}

	public void SetFacing (float direction) {
		if (direction > 0) {
			facing = -1;
		}

		if (direction < 0) {
			facing = 1;
		}
	}
}
