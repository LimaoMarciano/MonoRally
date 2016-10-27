using UnityEngine;
using System.Collections;

public class Body : MonoBehaviour {

	private Robot robot;
	private Rigidbody2D rb;

	//Stabilizer stuff
	public float toAngularSpeed = 10f;
	public float maxAngularSpeed = 200f;
	public float maxTorque = 2000.0f;
	public float gain = 5f;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 bodyAngle = transform.up;
		float angle = SignedAngle (bodyAngle, Vector3.up);
//		Debug.Log (angle);
//
//		rb.AddTorque (angle * 40,ForceMode2D.Force);
		if (angle < 100 && angle > -100) {
			Stabilizer (0);
		}

	}

	public void LoadData (BodyData data) {
		robot = GetComponentInParent<Robot> ();

		gameObject.AddComponent<SpriteRenderer> ();
		SpriteRenderer sprite = GetComponent<SpriteRenderer> ();
		sprite.sprite = data.sprite;
		sprite.sortingOrder = 5;

		PolygonCollider2D collider = gameObject.AddComponent<PolygonCollider2D> ();
		collider.SetPath (0, data.colliderPath.path);
//		physicsMaterial = new PhysicsMaterial2D ();
//		physicsMaterial.friction = data.friction;
//		physicsMaterial.bounciness = data.bounciness;
//		collider.sharedMaterial = physicsMaterial;

		gameObject.AddComponent<Rigidbody2D> ();
		Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D> ();
		rigidbody2D.mass = data.mass;
		rigidbody2D.drag = data.drag;
//		rigidbody2D.angularDrag = data.angularDrag;
		rigidbody2D.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
//		rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;

		Debug.Log ("Body data loaded.");

	}

	private float SignedAngle (Vector3 a, Vector3 b) {
		float sign = Mathf.Sign(Vector3.Cross(b, a).z);
		return Vector3.Angle (a, b) * sign;
	}

	private void Stabilizer (float targetAngle) {
		Vector3 bodyAngle = transform.up;
		float angle = SignedAngle (bodyAngle, Vector3.up);

		float dist = targetAngle - angle;
		Debug.Log ("Distance: " + dist);
		// calc a target vel proportional to distance (clamped to maxVel)
		float targetAngularSpeed = Mathf.Clamp (toAngularSpeed * dist, -maxAngularSpeed, maxAngularSpeed);
		// calculate the velocity error
		float error = targetAngularSpeed - rb.angularVelocity;
		// calc a force proportional to the error (clamped to maxForce)
		float torque = Mathf.Clamp(gain * error, -maxTorque, maxTorque);
		Debug.Log ("Torque: " + torque);
		Debug.Log ("--------------------");
		rb.AddTorque(torque, ForceMode2D.Force);
	}
}
