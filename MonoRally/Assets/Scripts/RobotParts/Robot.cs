using UnityEngine;
using System.Collections;

public class Robot : MonoBehaviour {

	public Vector3 wheelPosition;

	[Header("Configuration data")]
	public EngineData engineData;
	public WheelData wheelData;
	public SuspensionData suspensionData;

	public WheelJoint2D wheelJoint;
	public Rigidbody2D wheelRigidbody;
	public WheelGroundDetector wheelGroundDetector;


	[HideInInspector] public Engine engine;
	[HideInInspector] public Wheel wheel;
	[HideInInspector] public Suspension suspention;

	// Use this for initialization
	void Awake () {
		engine = gameObject.AddComponent<Engine>() as Engine;
		engine.LoadData (engineData);
		engine.SetRobotReference (this);

		GameObject wheelObject = new GameObject ("Wheel");
		wheelObject.transform.SetParent (wheelJoint.gameObject.transform);
		wheelObject.transform.localPosition = wheelPosition;
		wheelObject.AddComponent<Wheel> ();
		wheel = wheelObject.GetComponent<Wheel> ();
		wheel.LoadData (wheelData);

		wheelRigidbody = wheelObject.GetComponent<Rigidbody2D> ();
		wheelJoint.anchor = new Vector2 (0, -0.75f);
		wheelJoint.connectedBody = wheel.GetComponent<Rigidbody2D> ();

		suspention = gameObject.AddComponent<Suspension> ();
		suspention.LoadData (suspensionData);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
