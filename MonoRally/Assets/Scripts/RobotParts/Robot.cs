using UnityEngine;
using System.Collections;

public class Robot : MonoBehaviour {

	[Header("Configuration data")]
	public EngineData engineData;
	public TransmissionData transmissionData;
	public BodyData bodyData;
	public WheelData wheelData;
	public SuspensionData suspensionData;
	public StabilizerData stabilizerData;
	public JumpMechanismData jumpMechanismData;
	public BrakeData brakeData;
	public BoostData boostData;

	public VehicleConfig vehicleConfig;

//	public GameObject body;
	[HideInInspector] public Body body;
	[HideInInspector] public WheelJoint2D wheelJoint;
	[HideInInspector] public Rigidbody2D wheelRigidbody;
	[HideInInspector] public WheelGroundDetector wheelGroundDetector;


	[HideInInspector] public Engine engine;
	[HideInInspector] public Transmission transmission;
	[HideInInspector] public Brakes brakes;
	[HideInInspector] public Wheel wheel;
	[HideInInspector] public Suspension suspention;
	[HideInInspector] public Stabilizer stabilizer;
	[HideInInspector] public JumpMechanism jumpMechanism;
	[HideInInspector] public Boost boost;

	// Use this for initialization
	void Awake () {

	}
	
	public void InitializeRobot ( VehicleConfig data) {
		vehicleConfig = data;

		Debug.Log ("Robot initializing...");

		Debug.Log ("Creating body...");
		GameObject bodyObject = new GameObject ("Body");
		bodyObject.transform.SetParent (transform);
		bodyObject.transform.localPosition = Vector3.zero;
		body = bodyObject.AddComponent<Body> ();
		body.LoadData (vehicleConfig.bodyData);

		Debug.Log ("Creating stabilizer...");
		stabilizer = bodyObject.AddComponent<Stabilizer> ();
		stabilizer.LoadData (vehicleConfig.stabilizerData);

		Debug.Log ("Creating engine...");
		engine = gameObject.AddComponent<Engine>() as Engine;
		engine.LoadData (vehicleConfig.engineData);
		engine.SetRobotReference (this);

		Debug.Log ("Creating transmission...");
		transmission = body.gameObject.AddComponent<Transmission> ();
		transmission.LoadData (vehicleConfig.transmissionData);

		Debug.Log ("Creating boost...");
		GameObject boostObject = new GameObject ("Boost");
		boostObject.transform.SetParent (body.transform);
		boostObject.transform.localPosition = vehicleConfig.bodyData.boostPosition;
		boost = boostObject.gameObject.AddComponent<Boost> ();
		boost.LoadData (vehicleConfig.boostData);

		Debug.Log ("Creating wheel...");
		GameObject wheelObject = new GameObject ("Wheel");
		wheelObject.transform.SetParent (bodyObject.transform);
		wheelObject.transform.localPosition = vehicleConfig.bodyData.wheelPosition;
		wheelObject.AddComponent<Wheel> ();
		wheel = wheelObject.GetComponent<Wheel> ();
		wheel.LoadData (vehicleConfig.wheelData);
		wheelRigidbody = wheelObject.GetComponent<Rigidbody2D> ();

		Debug.Log ("Creating brake...");
		GameObject brakeObject = new GameObject ("Brake");
		brakeObject.transform.SetParent (wheelObject.transform);
		brakeObject.transform.localPosition = Vector3.zero;
		brakes = brakeObject.AddComponent<Brakes> ();
		brakes.LoadData (vehicleConfig.brakeData);

		Debug.Log ("Creating wheel joint...");
		wheelJoint = bodyObject.AddComponent<WheelJoint2D> ();
		wheelJoint.anchor = vehicleConfig.bodyData.wheelPosition;
		wheelJoint.connectedBody = wheelRigidbody;
		wheelJoint.enableCollision = true;
		Debug.Log ("Wheel joint created and configured");

		Debug.Log ("Creating jump mechanism...");
		jumpMechanism = bodyObject.gameObject.AddComponent<JumpMechanism> ();
		jumpMechanism.LoadData (vehicleConfig.jumpMechanismData);

		Debug.Log ("Creating suspension...");
		GameObject suspension = new GameObject ("Suspension");
		suspension.transform.SetParent (body.transform);
		suspension.transform.localPosition = body.transform.position;
		suspention = suspension.AddComponent<Suspension> ();
		suspention.LoadData (vehicleConfig.suspensionData);

		Camera.main.GetComponent<CameraFollow> ().target = bodyObject.transform;

		Debug.Log ("Robot initialized");
	}
}
