using UnityEngine;
using System.Collections;

public class Collectible : MonoBehaviour {
	public Vector3 Offset;
	public float Speed = 1.0f;
	bool attached = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(attached) {
			transform.localPosition = Vector3.Lerp(transform.localPosition,Offset,Speed * Time.deltaTime);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == Character.NANO.ToString() && !attached) {
			transform.parent = other.transform;
			GameState.level++;
			attached = true;
		}
	}
}
