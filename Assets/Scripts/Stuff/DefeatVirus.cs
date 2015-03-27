using UnityEngine;
using System.Collections;

public class DefeatVirus : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(GameState.level == 8) {
			GameState.SetLevel(9);
			// TODO: make virus sink
			GetComponent<SliderJoint2D>().enabled = false;
			Invoke("EndGame", 2f);
			GameObject.Find(Character.NANO.ToString()).GetComponent<Collider2D>().enabled = false;
		}
	}

	void EndGame () {
		Application.LoadLevel("microWake");
	}

}
