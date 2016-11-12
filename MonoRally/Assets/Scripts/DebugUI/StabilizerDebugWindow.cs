using UnityEngine;
using System.Collections;

public class StabilizerDebugWindow : MonoBehaviour {

	public Robot robot;

	public Fillbar torque;
	public Fillbar angle;
	public DebugValue angleDistance;

	// Use this for initialization
	void Start () {
		robot = RaceManager.instance.robot;

		torque.SetLabel ("Torque");
		angle.SetLabel ("Angle");
		angleDistance.SetLabel ("Angle Dist.");

		if (robot) {
			angle.SetMaxValue (robot.stabilizer.GetAngleLimit ());
			torque.SetMaxValue (robot.stabilizer.GetMaxTorque ());
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (robot) {
			torque.value = Mathf.Abs (robot.stabilizer.GetTorque ());
			angle.value = Mathf.Abs (robot.stabilizer.GetAngleDistance ());
			angleDistance.SetValue (robot.stabilizer.GetAngleDistance (), true);
		}
	}
}
