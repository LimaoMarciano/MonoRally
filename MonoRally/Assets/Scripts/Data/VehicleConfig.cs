using System.Collections;
using UnityEngine;

[System.Serializable]
public struct VehicleConfig {
	public BodyData bodyData;
	public EngineData engineData;
	public TransmissionData transmissionData;
	public BoostData boostData;
	public BrakeData brakeData;
	public WheelData wheelData;
	public SuspensionData suspensionData;
	public JumpMechanismData jumpMechanismData;
	public StabilizerData stabilizerData;
}
