using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public PlayerController player;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = player.transform.position - 10*Vector3.forward;
	}
}
