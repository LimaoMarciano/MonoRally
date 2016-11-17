using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

	public void Quit () {
		Application.Quit ();
	}

	public void LoadScene (string scene) {
		SceneManager.LoadScene (scene);
	}

}
