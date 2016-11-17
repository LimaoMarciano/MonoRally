using UnityEngine;
using System.Collections;

public class JumpMechanism : MonoBehaviour {

	public float jumpForce = 200;
	public float jumpBoostForce = 2000;
	public float jumpBoostTimeLimit = 0.2f;

	private Robot robot;
	private Rigidbody2D rb;
	private bool isHoldingJump = false;
	private bool isJumpAllowed = true;
	private bool isJumpBoostAllowed = false;
	private IEnumerator boostTimer;
	private Vector2 jumpDirection;

	// Use this for initialization
	void Start () {
		jumpDirection = new Vector2 (0, 1);
		robot = GetComponentInParent <Robot> ();
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!isHoldingJump && robot.wheel.isGrounded) {
			isJumpAllowed = true;
		}
	}

	void FixedUpdate () {

		jumpDirection = robot.wheel.groundNormal.normalized;

//		if (robot.wheel.isGrounded && isJumpBoostAllowed) {
//			StopCoroutine (boostTimer);
//			isJumpBoostAllowed = false;
//			Debug.Log ("Jump interrupted.");
//		}

		if (isHoldingJump && isJumpBoostAllowed) {
			rb.AddForce (jumpDirection * jumpBoostForce, ForceMode2D.Force);
		}

		if (isHoldingJump && robot.wheel.isGrounded && isJumpAllowed) {
			rb.AddForce (jumpDirection * jumpForce, ForceMode2D.Impulse);
			boostTimer = StartBoostTimer ();
			StartCoroutine (boostTimer);
			isJumpAllowed = false;
		}
	}

	public void JumpInput (bool input) {
		isHoldingJump = input;
	}

	IEnumerator StartBoostTimer () {
		float boostTimer = 0;
		isJumpBoostAllowed = true;
		while (boostTimer < jumpBoostTimeLimit) {
			boostTimer += Time.fixedDeltaTime;
			yield return null;
		}
		isJumpBoostAllowed = false;
	}

	public void LoadData (JumpMechanismData data) {
		jumpForce = data.jumpForce;
		jumpBoostForce = data.jumpBoostForce;
		jumpBoostTimeLimit = data.jumpBoostTimeLimit;

		Debug.Log ("Jump mechanism data loaded.");
	}
}
