using UnityEngine;
using System.Collections;

public class PicoTimer : MonoBehaviour {
	public TogglePlayer toggle;
	public float TTL;

	// Use this for initialization
	void Start () {
		toggle = FindObjectOfType<TogglePlayer>();
	}
	
	// Update is called once per frame
	void Update () {
		TTL -= Time.deltaTime;
		if(TTL < 0) {
			toggle.ZoomOut();
			Destroy(gameObject);
		}
	}
}
