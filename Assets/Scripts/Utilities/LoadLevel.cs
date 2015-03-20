using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Collider2D))]
public class LoadLevel : MonoBehaviour {
	public int level;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		Application.LoadLevelAdditive(level);
		Destroy(this);
	}
}
