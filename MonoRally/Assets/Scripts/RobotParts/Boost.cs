using UnityEngine;
using System.Collections;

public class Boost : MonoBehaviour {

	private Robot robot;
	private Rigidbody2D bodyRb;

	private float force;
	private float chargeTime;

	private float charge = 0;
	private bool isCharging = false;
	private bool doReleaseCharge = false;
	private float timer = 0;

	// Use this for initialization
	void Start () {
		bodyRb = robot.body.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isCharging) {
			if (timer < chargeTime) {
				Debug.Log ("Timer: " + timer);
				timer += Time.deltaTime;
				charge = timer / chargeTime;
			}
		}

	}

	void FixedUpdate () {
		if (doReleaseCharge) {
			charge = Mathf.Clamp01 (charge);
			int direction = -robot.wheel.GetFacing ();
			bodyRb.AddForce (bodyRb.transform.right * direction * force * charge, ForceMode2D.Impulse);
			Debug.Log ("Charge released! " + (force * charge));
			charge = 0;
			timer = 0;
			doReleaseCharge = false;
		}
	}

	public void ChargeBoost (bool value) {
		isCharging = value;
	}

	public void ReleaseBoost () {
		doReleaseCharge = true;
	}

	public void LoadData (BoostData data) {
		robot = GetComponentInParent<Robot> ();

		force = data.force;
		chargeTime = data.chargeTime;
		Debug.Log ("Boost data loaded.");

	}

	public float GetChargeValue () {
		return charge;
	}
}
