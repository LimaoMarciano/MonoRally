using UnityEngine;
using System.Collections;

public class BrakesDebugWindow : MonoBehaviour {

	public Robot robot;

	public Fillbar brakeTorque;

	// Use this for initialization
	void Start () {
		robot = RaceManager.instance.robot;
		if (robot) {
			brakeTorque.SetMaxValue (robot.brakes.brakeTorque);
		}

		brakeTorque.SetLabel ("Torque");
	}
	
	// Update is called once per frame
	void Update () {
		if (robot) {
			brakeTorque.value = robot.brakes.GetBrakeTorque ();
		}
	}
}
