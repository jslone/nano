using UnityEngine;
using System.Collections;

public class CameraTrack : MonoBehaviour {
	public CameraData camData;

	// Use this for initialization
	void Start () {
		Invoke("SetTarget", 0.1f); // hacky wait so it's set after player
	}
	
	// Update is called once per frame
	void Update () {

	}

	void SetTarget() {
		FindObjectOfType<CameraController>().playerCamera = camData;
	}

	void ResetTarget() {
		CameraController camController = FindObjectOfType<CameraController>();
		camController.playerCamera = camController._lastPlayerCamera;
	}
}
