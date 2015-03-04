using UnityEngine;
using System.Collections;

public abstract class Trigger : MonoBehaviour {
	public bool TriggerOnEnter;
	public bool TriggerOnExit;

	private int count = 0;

	public abstract void OnTrigger();

	void OnTriggerEnter2D(Collider2D other) {
		if(TriggerOnEnter && count == 0) {
			OnTrigger();
		}
		count++;
	}
	
	void OnTriggerExit2D(Collider2D other) {
		count--;
		if(TriggerOnExit && count == 0) {
			OnTrigger();
		}
	}
}
