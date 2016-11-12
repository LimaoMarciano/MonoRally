using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BoostDebugWindow : MonoBehaviour {

	public Robot robot;

	public Fillbar boostBar;

	private float boostMaxForce;

	// Use this for initialization
	void Start () {
		boostMaxForce = robot.boost.GetBoostMaxForce ();

		boostBar.SetLabel ("Boost force");
		boostBar.SetMaxValue (boostMaxForce);
	}
	
	// Update is called once per frame
	void Update () {
		boostBar.value = boostMaxForce * robot.boost.GetChargeValue ();
	}
}
