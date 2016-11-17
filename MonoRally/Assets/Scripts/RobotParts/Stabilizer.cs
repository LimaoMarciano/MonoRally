using UnityEngine;
using System.Collections;

public class Stabilizer : MonoBehaviour {

	private float angleLimit = 90f;
	private float toAngularSpeed = 10f;
	private float maxAngularSpeed = 200f;
	private float maxTorque = 2000.0f;
	private float gain = 5f;

	private Robot robot;
	private Rigidbody2D rb;
	private float bodyAngle;
	private Vector2 targetDirection = Vector2.up;

	private float airTimer = 0;
	private float torque;
	private float angleDistance;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void FixedUpdate () {
		Vector3 bodyDirection = transform.up;
		Vector2 groundNormal =  robot.wheel.groundNormal;

		//If the robot is grounded, use the ground normal
		if (robot.wheel.isGrounded) {
			targetDirection = groundNormal;
		} else {
			//If the robot is airborne, hold the last normal for 0.5 seconds. If the timer runs out, make the normal point up
			if (airTimer > 0.5f) {
				targetDirection = Vector3.up;
				airTimer = 0;
			} else {
				airTimer += Time.fixedDeltaTime;
			}
		}

		bodyAngle = SignedAngle (bodyDirection, targetDirection);

		if (Mathf.Abs(bodyAngle) < angleLimit) {
			StabilizeBody (0);
		}
	}

	void LateUpdate () {
		Debug.DrawLine (transform.position, transform.position + (Vector3)targetDirection.normalized, Color.red);
	}

	public void LoadData (StabilizerData data) {
		robot = GetComponentInParent<Robot> ();
		rb = GetComponent<Rigidbody2D> ();
		angleLimit = data.angleLimit;
		toAngularSpeed = data.toAngularSpeed;
		maxAngularSpeed = data.maxAngularSpeed;
		maxTorque = data.maxTorque;
		gain = data.gain;
	}

	public float GetTorque() {
		return torque;
	}

	public float GetAngleDistance() {
		return angleDistance;
	}

	public float GetMaxTorque() {
		return maxTorque;
	}

	public float GetAngleLimit() {
		return angleLimit;
	}

	private float SignedAngle (Vector3 a, Vector3 b) {
		float sign = Mathf.Sign(Vector3.Cross(b, a).z);
		return Vector3.Angle (a, b) * sign;
	}

	private void StabilizeBody (float targetAngle) {

		angleDistance = targetAngle - bodyAngle;
		// calc a target vel proportional to distance (clamped to maxVel)
		float targetAngularSpeed = Mathf.Clamp (toAngularSpeed * angleDistance, -maxAngularSpeed, maxAngularSpeed);
		// calculate the velocity error
		float error = targetAngularSpeed - rb.angularVelocity;
		// calc a force proportional to the error (clamped to maxForce)
		torque = Mathf.Clamp(gain * error, -maxTorque, maxTorque);

		rb.AddTorque(torque, ForceMode2D.Force);
	}
		

}
