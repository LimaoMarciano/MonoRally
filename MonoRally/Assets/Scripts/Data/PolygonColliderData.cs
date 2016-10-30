using UnityEngine;
using UnityEditor;
using System.Collections;

[CreateAssetMenu(fileName = "PolygonPathData", menuName = "RobotRally/Polygon Path", order = 51)]
public class PolygonColliderData : ScriptableObject {
	public string identifier;
	public Vector2[] path;

	void OnEnable() {
		if (path == null) {
			GameObject go = Selection.activeGameObject;
			if (go) {
				PolygonCollider2D collider = go.GetComponent<PolygonCollider2D> ();
				if (collider != null) {
					path = collider.GetPath (0);
				}
			}
		}
			
	}

}


//public class PolygonColliderData {
//
//	public Vector2Data[] path;
//
//	public class Vector2Data {
//		public float x = 0;
//		public float y = 0;
//	}
//
//	public void SetVector2Data (Vector2[] polygonPath) {
//		Vector2Data[] data = new Vector2Data[polygonPath.Length];
//		for (int i = 0; i < data.Length; i++) {
//			Vector2Data vec;
//			vec.x = polygonPath [i].x;
//			vec.y = polygonPath [i].y;
//			data [i] = vec;
//		}
//
//		path = data;
//	}
//}
