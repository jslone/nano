using UnityEngine;
using System.Collections;

public enum ButtonAction {
	PLAY,
	CREDITS,
	QUIT
}

public class UIButton : MonoBehaviour {
	public ButtonAction action;
	
	public void OnClick() {
		switch(action) {
			case ButtonAction.PLAY:
				Application.LoadLevel(0);	// game scene
				break;
			case ButtonAction.CREDITS:
				Application.LoadLevel(6);	// credits scene
				break;
			case ButtonAction.QUIT:
				Application.Quit();
				break;
		}
	}
}
