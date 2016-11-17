using UnityEngine;
using System.Collections;

public class WheelGroundDetector : MonoBehaviour {

	public bool isGrounded = false;
	public Vector2 groundNormal = new Vector2(0, 1);
	public LayerMask groundLayer;

	void Start () {
	}

	void OnCollisionEnter2D () {
		isGrounded = true;
	}

	void OnCollisionStay2D (Collision2D col) {
		if (col.gameObject.layer == LayerMask.NameToLayer("Road")) {
			groundNormal = col.contacts [0].normal;
			Debug.Log("Collided with: " + col.gameObject.name);
		}
	}

	void OnCollisionExit2D () {
		isGrounded = false;
	}
}
