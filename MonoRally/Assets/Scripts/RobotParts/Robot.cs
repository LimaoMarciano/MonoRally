using UnityEngine;
using System.Collections;

public class Robot : MonoBehaviour {

	public Vector3 wheelPosition;

	[Header("Configuration data")]
	public EngineData engineData;
	public WheelData wheelData;
	public SuspensionData suspensionData;

	public GameObject body;
	public WheelJoint2D wheelJoint;
	public Rigidbody2D wheelRigidbody;
	public WheelGroundDetector wheelGroundDetector;


	[HideInInspector] public Engine engine;
	[HideInInspector] public Wheel wheel;
	[HideInInspector] public Suspension suspention;

	// Use this for initialization
	void Awake () {
		Debug.Log ("Robot initializing...");

		Debug.Log ("Creating engine...");
		engine = gameObject.AddComponent<Engine>() as Engine;
		engine.LoadData (engineData);
		engine.SetRobotReference (this);

		Debug.Log ("Creating wheel...");
		GameObject wheelObject = new GameObject ("Wheel");
		wheelObject.transform.SetParent (wheelJoint.gameObject.transform);
		wheelObject.transform.localPosition = wheelPosition;
		wheelObject.AddComponent<Wheel> ();
		wheel = wheelObject.GetComponent<Wheel> ();
		wheel.LoadData (wheelData);

		Debug.Log ("Creating wheel joint...");
		wheelRigidbody = wheelObject.GetComponent<Rigidbody2D> ();
		wheelJoint.anchor = new Vector2 (0, -0.75f);
		wheelJoint.connectedBody = wheel.GetComponent<Rigidbody2D> ();
		Debug.Log ("Wheel joint created and configured");

		Debug.Log ("Creating suspension...");
		GameObject suspension = new GameObject ("Suspension");
		suspension.transform.SetParent (body.transform);
		suspension.transform.localPosition = body.transform.position;
		suspention = suspension.AddComponent<Suspension> ();
		suspention.LoadData (suspensionData);

		Debug.Log ("Robot initialized");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
