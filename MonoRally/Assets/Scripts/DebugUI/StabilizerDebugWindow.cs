using UnityEngine;
using System.Collections;

public class StabilizerDebugWindow : MonoBehaviour {

	public Robot robot;

	public Fillbar torque;
	public Fillbar angle;
	public DebugValue angleDistance;

	// Use this for initialization
	void Start () {
		torque.SetLabel ("Torque");
		torque.SetMaxValue (robot.stabilizer.GetMaxTorque ());

		angle.SetLabel ("Angle");
		angle.SetMaxValue (robot.stabilizer.GetAngleLimit ());

		angleDistance.SetLabel ("Angle Dist.");
	}
	
	// Update is called once per frame
	void Update () {
		torque.value = Mathf.Abs(robot.stabilizer.GetTorque ());
		angle.value = Mathf.Abs (robot.stabilizer.GetAngleDistance ());
		angleDistance.SetValue (robot.stabilizer.GetAngleDistance (), true);
	}
}
