using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Collider2D))]
public class Feet : MonoBehaviour {
	public bool isGrounded { get; private set; }
	private bool touchedLastFrame;
	
	// Use this for initialization
	void Start () {
		isGrounded = false;
		touchedLastFrame = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(touchedLastFrame) {
			touchedLastFrame = false;
		} else {
			isGrounded = false;
		}
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if(!other.isTrigger) {
			isGrounded = true;
			touchedLastFrame = true;
		}
	}

	void OnTriggerStay2D(Collider2D other) {
		if(!other.isTrigger) {
			isGrounded = true;
			touchedLastFrame = true;
		}
	}
}
