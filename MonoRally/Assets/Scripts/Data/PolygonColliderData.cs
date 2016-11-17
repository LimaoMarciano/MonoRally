using UnityEngine;
using System.Collections;

#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName = "PolygonPathData", menuName = "RobotRally/Polygon Path", order = 51)]
public class PolygonColliderData : ScriptableObject {
	public string identifier;
	public Vector2[] path;

	#if UNITY_EDITOR
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
	#endif

}
