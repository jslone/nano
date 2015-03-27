using UnityEngine;
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
				Application.LoadLevel("hubWorldCutscene");	// game scene
				break;
			case ButtonAction.BACK:
				Application.LoadLevel("title");	// title scene
				break;
			case ButtonAction.CREDITS:
				Application.LoadLevel("credits");	// credits scene
				break;
			case ButtonAction.QUIT:
				Application.Quit();
				break;
		}
	}
}
