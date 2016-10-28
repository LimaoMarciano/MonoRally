using UnityEngine;
using System.Collections;

public class Stabilizer : MonoBehaviour {

	private float angleLimit = 90f;
	private float toAngularSpeed = 10f;
	private float maxAngularSpeed = 200f;
	private float maxTorque = 2000.0f;
	private float gain = 5f;

	private Rigidbody2D rb;
	private float bodyAngle;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void FixedUpdate () {
		Vector3 bodyDirection = transform.up;
		bodyAngle = SignedAngle (bodyDirection, Vector3.up);

		if (Mathf.Abs(bodyAngle) < angleLimit) {
			StabilizeBody (0);
		}
	}

	public void LoadData (StabilizerData data) {
		rb = GetComponent<Rigidbody2D> ();
		angleLimit = data.angleLimit;
		toAngularSpeed = data.toAngularSpeed;
		maxAngularSpeed = data.maxAngularSpeed;
		maxTorque = data.maxTorque;
		gain = data.gain;
	}

	private float SignedAngle (Vector3 a, Vector3 b) {
		float sign = Mathf.Sign(Vector3.Cross(b, a).z);
		return Vector3.Angle (a, b) * sign;
	}

	private void StabilizeBody (float targetAngle) {

		float dist = targetAngle - bodyAngle;
		// calc a target vel proportional to distance (clamped to maxVel)
		float targetAngularSpeed = Mathf.Clamp (toAngularSpeed * dist, -maxAngularSpeed, maxAngularSpeed);
		// calculate the velocity error
		float error = targetAngularSpeed - rb.angularVelocity;
		// calc a force proportional to the error (clamped to maxForce)
		float torque = Mathf.Clamp(gain * error, -maxTorque, maxTorque);

		rb.AddTorque(torque, ForceMode2D.Force);
	}

}
