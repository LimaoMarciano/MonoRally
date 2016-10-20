using UnityEngine;
using System.Collections;

public class Robot : MonoBehaviour {

	public EngineData engineData;
	public WheelJoint2D wheelJoint;
	public Rigidbody2D wheelRigidbody;
	public WheelGroundDetector wheelGroundDetector;

	[HideInInspector]
	public Engine engine;
	// Use this for initialization
	void Start () {
		engine = gameObject.AddComponent<Engine>() as Engine;
		engine.LoadData (engineData);
		engine.SetRobotReference (this);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
