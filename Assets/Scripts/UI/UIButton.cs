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
				Application.LoadLevel(1);	// game scene
				break;
			case ButtonAction.BACK:
				Application.LoadLevel(0);	// title scene
				break;
			case ButtonAction.CREDITS:
				Application.LoadLevel(7);	// credits scene
				break;
			case ButtonAction.QUIT:
				Application.Quit();
				break;
		}
	}
}
