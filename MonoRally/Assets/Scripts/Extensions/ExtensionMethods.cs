using UnityEngine;
using System.Collections;

public static class ExtensionMethods {

	public static void SetMotorValues (this WheelJoint2D joint, float speed, float torque) {
		JointMotor2D jm = new JointMotor2D ();
		jm.motorSpeed = speed;
		jm.maxMotorTorque = torque;
		joint.motor = jm;
	}
}
