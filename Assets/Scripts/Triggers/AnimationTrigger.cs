using UnityEngine;
using System.Collections;

public class AnimationTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		GetComponent<Animation>().Play();
		Destroy(this);
	}
}
