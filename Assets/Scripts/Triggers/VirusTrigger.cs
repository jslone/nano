using UnityEngine;
using System.Collections;

public class VirusTrigger : MonoBehaviour {
	public GameObject[] Viruses;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		CheckViruses();
	}

	void CheckViruses() {
		foreach(GameObject v in Viruses) {
			if(v != null) {
				return;
			}
		}
		MicroLimbs.ActiveLimbs++;
		enabled = false;
	}
}
