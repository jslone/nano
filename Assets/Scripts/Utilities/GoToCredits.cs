using UnityEngine;
using System.Collections;

public class GoToCredits : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("LoadCredits",15);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void LoadCredits() {
		Application.LoadLevel("credits");
	}
}
