using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using FMOD.Studio;

public class PauseUI : MonoBehaviour {

	public RectTransform pauseGroup;
	public RectTransform gameplayGroup;
	public Button firstSelection;

	void OnEnable () {
		RaceManager.OnPaused += Pause;
		RaceManager.OnUnpause += Unpause;
	}

	void OnDisable () {
		RaceManager.OnPaused -= Pause;
		RaceManager.OnUnpause -= Unpause;
	}

	void Pause () {
		pauseGroup.gameObject.SetActive (true);
		gameplayGroup.gameObject.SetActive (false);

		EventSystem.current.SetSelectedGameObject (firstSelection.gameObject, null);

		FMODUnity.RuntimeManager.PauseAllEvents (true);

	}

	void Unpause () {
		pauseGroup.gameObject.SetActive (false);
		gameplayGroup.gameObject.SetActive (true);

		FMODUnity.RuntimeManager.PauseAllEvents (false);
	}

	public void OnClickResume () {
		RaceManager.instance.Unpause ();
	}

	public void OnClickRestart () {
		RaceManager.instance.Unpause ();
		string currentScene = SceneManager.GetActiveScene ().name;
		SceneManager.LoadScene (currentScene);
	}

	public void OnClickQuitRace () {
		RaceManager.instance.Unpause ();
		SceneManager.LoadScene ("MainMenu");
	}
}
