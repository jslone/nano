using UnityEngine;
using System.Collections;

public abstract class Trigger : MonoBehaviour {
	public bool TriggerOnEnter;
	public bool TriggerOnExit;
	public abstract void OnTrigger();
	
	void OnTriggerEnter2D(Collider2D other) {
		if(TriggerOnEnter) OnTrigger();
	}
	
	void OnTriggerExit2D(Collider2D other) {
		if(TriggerOnExit) OnTrigger();
	}
}
