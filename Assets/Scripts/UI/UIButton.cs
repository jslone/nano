using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public enum ButtonAction {
	PLAY,
	CREDITS,
	BACK,
	QUIT
}

public class UIButton : MonoBehaviour {
	public ButtonAction action;
	
	public void OnClick() {
		switch(action) {
			case ButtonAction.PLAY:
				SceneManager.LoadScene("hubWorldCutscene");	// game scene
				break;
			case ButtonAction.BACK:
				SceneManager.LoadScene("title");	// title scene
				break;
			case ButtonAction.CREDITS:
				SceneManager.LoadScene("credits");	// credits scene
				break;
			case ButtonAction.QUIT:
				Application.Quit();
				break;
		}
	}
}
