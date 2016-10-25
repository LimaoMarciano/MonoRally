using UnityEngine;
using System.Collections;

public class Suspension : MonoBehaviour {

	private Robot robot;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (robot.wheelJoint.reactionForce);
	}

	public void LoadData (SuspensionData data) {
		robot = GetComponentInParent<Robot> ();

		JointSuspension2D suspension = robot.wheelJoint.suspension;
		suspension.frequency = data.stiffness;
		suspension.dampingRatio = data.damping;

		robot.wheelJoint.suspension = suspension;
	}
}
