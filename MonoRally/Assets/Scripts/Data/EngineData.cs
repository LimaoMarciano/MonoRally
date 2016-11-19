using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "EngineData", menuName = "RobotRally/Engine", order = 2)]
public class EngineData : ScriptableObject {

	public string manufacturer;
	public string model;
	[FMODUnity.EventRef]
	public string soundEvent;
	public float minSpeed = 500;
	public float maxSpeed = 10000;
	public float maxTorque = 450;
	public float engineBrakeForce = 3;
	public AnimationCurve torqueCurve;

}
