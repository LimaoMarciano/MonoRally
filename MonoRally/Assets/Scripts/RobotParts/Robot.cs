using UnityEngine;
using System.Collections;

public class Robot : MonoBehaviour {

	public EngineData engineData;
	public WheelJoint2D wheelJoint;
	public Rigidbody2D wheelRigidbody;
	public WheelGroundDetector wheelGroundDetector;


	[HideInInspector] public Engine engine;
	[HideInInspector] public Wheel wheel;

	// Use this for initialization
	void Awake () {
		engine = gameObject.AddComponent<Engine>() as Engine;
		wheel = gameObject.AddComponent<Wheel> () as Wheel;
		engine.LoadData (engineData);
		engine.SetRobotReference (this);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
