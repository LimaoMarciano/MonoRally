using UnityEditor;
using UnityEngine;
using System.Collections;


public class CreateVehicleSpawn {

	[MenuItem("GameObject/Vehicle Spawn", false, 31)]
	public static void CreateSpawn () {
		GameObject prefab = (GameObject)AssetDatabase.LoadAssetAtPath ("Assets/Prefabs/Entities/VehicleSpawn.prefab", typeof(GameObject));
		if (prefab == null) {
			
			Debug.LogWarning ("Could not found Vehicle Spawn prefab at Prefabs/Entities");

		} else {
			
			GameObject clone = (GameObject)PrefabUtility.InstantiatePrefab (prefab);
		
			clone.transform.position = GetSpawnPos ();
			EditorGUIUtility.PingObject (clone);
			Selection.activeObject = clone;


		}

	}
		
	static Vector3 GetSpawnPos() {
		Plane   plane  = new Plane(new Vector3(0, 0, -1), 0);
		float   dist   = 0;
		Vector3 result = new Vector3(0, 0, 0);
		//Ray     ray    = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
		Ray ray = SceneView.lastActiveSceneView.camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 1.0f));
		if (plane.Raycast(ray, out dist)) {
			result = ray.GetPoint(dist);
		}
		return new Vector3(result.x, result.y, 0);
	}

}
