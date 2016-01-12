using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GoToCredits : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("LoadCredits", 15);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void LoadCredits() {
		SceneManager.LoadScene("credits");
	}
}
