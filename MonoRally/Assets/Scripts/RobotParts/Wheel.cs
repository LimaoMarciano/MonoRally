using UnityEngine;
using System.Collections;

public class Wheel : MonoBehaviour {

	private Robot robot;
	private int facing = -1;
	private PhysicsMaterial2D physicsMaterial;
	private Rigidbody2D rb;

	private float wheelAngularDrag;
	private float engineDrag;

	private float motorSpeed;
	private float motorTorque;

	private float brakeTorque;

	public bool isGrounded = false;
	public Vector2 groundNormal = new Vector2(0, 1);

	// Use this for initialization
//	void Awake () {
//		
//	}
	

	void FixedUpdate () {
		rb.angularDrag = wheelAngularDrag + engineDrag;

		float speed;
		float torque = motorTorque - brakeTorque;

		if (torque < 0) {
			speed = 0;
			torque *= -1;
		} else {
			speed = motorSpeed;
		}

		robot.wheelJoint.SetMotorValues (speed * facing, torque);
	}

	public void ApplyMotorForce (float speed, float torque) {
//		robot.wheelJoint.SetMotorValues (speed * facing, torque);
		motorSpeed = speed;
		motorTorque = torque;
	}

	public void ApplyBrakeForce (float torque) {
		brakeTorque = torque;
	}

	public void SetFacing (float direction) {
		if (direction > 0) {
			facing = -1;
		}

		if (direction < 0) {
			facing = 1;
		}
	}

	public void ApplyEngineDrag (float drag) {
		engineDrag = drag;
	}

	public void LoadData (WheelData data) {
		robot = GetComponentInParent<Robot> ();

		gameObject.AddComponent<SpriteRenderer> ();
		SpriteRenderer sprite = GetComponent<SpriteRenderer> ();
		sprite.sprite = data.sprite;
		sprite.sortingOrder = 2;

		gameObject.AddComponent<CircleCollider2D> ();
		CircleCollider2D collider = GetComponent<CircleCollider2D> ();
		collider.radius = data.radius;
		physicsMaterial = new PhysicsMaterial2D ();
		physicsMaterial.friction = data.friction;
		physicsMaterial.bounciness = data.bounciness;
		collider.sharedMaterial = physicsMaterial;

		gameObject.AddComponent<Rigidbody2D> ();
		rb = GetComponent<Rigidbody2D> ();
		rb.mass = data.mass;
		rb.drag = data.drag;
		rb.angularDrag = data.angularDrag;
		rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;

		wheelAngularDrag = data.angularDrag;

		Debug.Log ("Wheel data loaded");

	}

	public float GetCurrentSpeed () {
		return rb.velocity.magnitude;
	}

	public int GetFacing () {
		return facing;
	}

	public float GetAngularVelocity () {
		return rb.angularVelocity;
	}

	void OnCollisionEnter2D () {
		isGrounded = true;
	}

	void OnCollisionStay2D (Collision2D col) {
		isGrounded = true;

		if (col.gameObject.layer == LayerMask.NameToLayer("Road")) {
			groundNormal = col.contacts [0].normal;
		}
	}

	void OnCollisionExit2D () {
		isGrounded = false;
	}

}
