using UnityEngine;
using System.Collections;

public class Suspension : MonoBehaviour {

	private Robot robot;

	private Vector3 bodyCoord;
	private Vector3 wheelCoord;
	private float spriteHeight;

	private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (spriteRenderer) {
			DrawSuspension ();
		}
	}

	public void LoadData (SuspensionData data) {
		robot = GetComponentInParent<Robot> ();

		spriteRenderer = gameObject.AddComponent<SpriteRenderer> ();
		spriteRenderer.sprite = data.sprite;
		spriteRenderer.sortingOrder = 4;
		spriteHeight = spriteRenderer.sprite.bounds.size.y;

		JointSuspension2D suspension = robot.wheelJoint.suspension;
		suspension.frequency = data.stiffness;
		suspension.dampingRatio = data.damping;

		robot.wheelJoint.suspension = suspension;

		Debug.Log ("Suspension data loaded.");
	}

	public void DrawSuspension () {
		bodyCoord = robot.body.transform.position;
		wheelCoord = robot.wheel.gameObject.transform.position;

		float distance = Vector3.Distance (wheelCoord, bodyCoord);
		transform.localScale = new Vector3 (1, distance / spriteHeight);

		Vector3 dir = bodyCoord - wheelCoord;
		transform.rotation = Quaternion.FromToRotation (transform.up, dir) * transform.rotation;

		float yPos = ((bodyCoord.y - wheelCoord.y) / 2) + wheelCoord.y;
		float xPos = ((bodyCoord.x - wheelCoord.x) / 2) + wheelCoord.x;
		transform.position = new Vector3 (xPos, yPos, 1);

	}
}
