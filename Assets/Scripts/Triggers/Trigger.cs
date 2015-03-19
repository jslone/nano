using UnityEngine;
using System.Collections;

public abstract class Trigger : MonoBehaviour {
	public bool TriggerOnEnter;
	public bool TriggerOnExit;

	public bool ChangeEach = true;
	public bool UseOnce;

	private int count = 0;
	
	public abstract void Flip();
	public abstract bool On { get; set; }

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

	public void OnTrigger() {
		if(ChangeEach) {
			Flip();
		} else {
			On = !On;
		}
		if(UseOnce) {
			Destroy(this);
		}
	}
}
