using UnityEngine;
using System.Collections;

public class WheelGroundDetector : MonoBehaviour {

	public bool isGrounded = false;

	void OnCollisionEnter2D () {
		isGrounded = true;
	}

	void OnCollisionExit2D () {
		isGrounded = false;
	}
}
