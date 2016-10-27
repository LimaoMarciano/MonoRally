using UnityEngine;
using System.Collections;

public class Robot : MonoBehaviour {

	[Header("Configuration data")]
	public EngineData engineData;
	public BodyData bodyData;
	public WheelData wheelData;
	public SuspensionData suspensionData;

//	public GameObject body;
	public Body body;
	public WheelJoint2D wheelJoint;
	public Rigidbody2D wheelRigidbody;
	public WheelGroundDetector wheelGroundDetector;


	[HideInInspector] public Engine engine;
	[HideInInspector] public Wheel wheel;
	[HideInInspector] public Suspension suspention;

	// Use this for initialization
	void Awake () {
		Debug.Log ("Robot initializing...");

		Debug.Log ("Creating body...");
		GameObject bodyObject = new GameObject ("Body");
		bodyObject.transform.SetParent (transform);
		bodyObject.transform.localPosition = Vector3.zero;
		body = bodyObject.AddComponent<Body> ();
		body.LoadData (bodyData);

		Camera.main.GetComponent<CameraFollow> ().target = bodyObject.transform;

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

		Debug.Log ("Robot initialized");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
