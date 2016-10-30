using UnityEngine;
using System.Collections;

public class WheelCollisionDetector : MonoBehaviour {

	public bool isGrounded = false;
	public LayerMask scenario;

	void Update () {
		Collider2D collider = Physics2D.OverlapCircle (transform.position, 0.33f, scenario);
		if (collider) {
			isGrounded = true;
		} else {
			isGrounded = false;
		}
	}
}
