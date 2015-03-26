using UnityEngine;
using System.Collections;

public class Audio : MonoBehaviour {

	private static Audio instance = null;
	public static Audio Instance {
		get { return instance; }
	}

	// Use this for initialization
	void Awake () {
		if (instance != null && instance != this) {
			Destroy(this.gameObject);
			return;
		} else {
			instance = this;
		}
		DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
