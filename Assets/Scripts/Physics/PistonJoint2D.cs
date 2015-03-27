using UnityEngine;
using System.Collections;

public class PistonJoint2D : MonoBehaviour {
	public bool useMotor;
	public float Speed;
	public Vector3 Offset;
	
	private Vector3 pos;
	private float time = 0;

	public int unlockLevel;

	private bool _isLocked = true;
	public bool isLocked
	{
		get { return _isLocked; }
		set
		{
			if(value != _isLocked) {
				useMotor = !value;
				_isLocked = value;
			}
		}
	}

	// Use this for initialization
	void Start () {
		pos = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		isLocked = unlockLevel > GameState.level;
		
		if(useMotor) {
			time += Time.deltaTime;
			transform.localPosition = pos + Offset * Mathf.PingPong(Speed * time, 1.0f);
		}
	}
}
