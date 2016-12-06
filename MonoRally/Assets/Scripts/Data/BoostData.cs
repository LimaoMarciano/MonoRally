using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "BoostData", menuName = "RobotRally/Boost", order = 9)]
public class BoostData : ScriptableObject {

	public string model;
	public string manufacturer;
	public Sprite sprite;
	[FMODUnity.EventRef]
	public string chargeSound;
	[FMODUnity.EventRef]
	public string releaseSound;
	public float force;
	public float chargeTime;
}
