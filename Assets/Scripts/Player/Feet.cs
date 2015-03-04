using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Collider2D))]
public class Feet : MonoBehaviour {
	public bool isGrounded { get { return count > 0; } }
	int count = 0;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if(!other.isTrigger) count++;
	}
	
	void OnTriggerExit2D(Collider2D other) {
		if(!other.isTrigger) count--;
	}
}
