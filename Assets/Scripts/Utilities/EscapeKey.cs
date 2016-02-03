using UnityEngine;
using System.Collections;

public class EscapeKey : MonoBehaviour {

	void Update() {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit();
		}
	}
}
