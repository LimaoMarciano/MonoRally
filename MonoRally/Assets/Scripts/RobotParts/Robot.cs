using UnityEngine;
using System.Collections;

public class Robot : MonoBehaviour {

	[Header("Configuration data")]
	public EngineData engineData;
	public BodyData bodyData;
	public WheelData wheelData;
	public SuspensionData suspensionData;
	public StabilizerData stabilizerData;

//	public GameObject body;
	[HideInInspector] public Body body;
	[HideInInspector] public WheelJoint2D wheelJoint;
	[HideInInspector] public Rigidbody2D wheelRigidbody;
	[HideInInspector] public WheelGroundDetector wheelGroundDetector;


	[HideInInspector] public Engine engine;
	[HideInInspector] public Wheel wheel;
	[HideInInspector] public Suspension suspention;
	[HideInInspector] public Stabilizer stabilizer;

	// Use this for initialization
	void Awake () {
		InitializeRobot ();
	}
	
	public void InitializeRobot () {
		Debug.Log ("Robot initializing...");

		Debug.Log ("Creating body...");
		GameObject bodyObject = new GameObject ("Body");
		bodyObject.transform.SetParent (transform);
		bodyObject.transform.localPosition = Vector3.zero;
		body = bodyObject.AddComponent<Body> ();
		body.LoadData (bodyData);

		Debug.Log ("Creating stabilizer...");
		stabilizer = bodyObject.AddComponent<Stabilizer> ();
		stabilizer.LoadData (stabilizerData);

		Debug.Log ("Creating engine...");
		engine = gameObject.AddComponent<Engine>() as Engine;
		engine.LoadData (engineData);
		engine.SetRobotReference (this);

		Debug.Log ("Creating wheel...");
		GameObject wheelObject = new GameObject ("Wheel");
		wheelObject.transform.SetParent (bodyObject.transform);
		wheelObject.transform.localPosition = bodyData.wheelPosition;
		wheelObject.AddComponent<Wheel> ();
		wheel = wheelObject.GetComponent<Wheel> ();
		wheel.LoadData (wheelData);
		wheelRigidbody = wheelObject.GetComponent<Rigidbody2D> ();

		Debug.Log ("Creating wheel joint...");
		wheelJoint = bodyObject.AddComponent<WheelJoint2D> ();
		wheelJoint.anchor = bodyData.wheelPosition;
		wheelJoint.connectedBody = wheelRigidbody;
		wheelJoint.enableCollision = true;
		Debug.Log ("Wheel joint created and configured");

		Debug.Log ("Creating suspension...");
		GameObject suspension = new GameObject ("Suspension");
		suspension.transform.SetParent (body.transform);
		suspension.transform.localPosition = body.transform.position;
		suspention = suspension.AddComponent<Suspension> ();
		suspention.LoadData (suspensionData);

		Camera.main.GetComponent<CameraFollow> ().target = bodyObject.transform;

		Debug.Log ("Robot initialized");
	}
}
