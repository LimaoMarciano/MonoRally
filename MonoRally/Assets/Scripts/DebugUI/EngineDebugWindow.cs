using UnityEngine;
using System.Collections;

public class EngineDebugWindow : MonoBehaviour {

	public Robot robot;

	public Fillbar speedBar;
	public Fillbar torqueBar;

	// Use this for initialization
	void Start () {
		robot = RaceManager.instance.robot;

		speedBar.SetLabel ("Speed");
		torqueBar.SetLabel ("Torque");

		if (robot) {
			speedBar.SetMaxValue (robot.engine.maxSpeed);
			torqueBar.SetMaxValue (robot.engine.maxTorque);
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (robot) {
			speedBar.value = robot.engine.GetSpeed ();
			torqueBar.value = robot.engine.GetTorque ();
		}
	}
}
