using UnityEngine;
using System.Collections;

[RequireComponent (typeof(AnchoredJoint2D))]
public class Spawner : MonoBehaviour {
	public GameObject Prefab;
	public LayerMask AttachLayer;
	public float Offset = 0;
	public float Timer = 1;
	public DistanceJoint2D Extender;

	public float MaxDistance;
	private float StartTime;
	private AnchoredJoint2D joint;

	// Use this for initialization
	void Start () {
		joint = GetComponent<AnchoredJoint2D>();
		joint.enabled = false;
		StartTime = Time.time;

		InvokeRepeating("Spawn",Offset,Timer);
		InvokeRepeating("Release",Offset + Timer/2, Timer);
	}

	void FixedUpdate () {
		Extender.distance = MaxDistance * Mathf.PingPong(2*((Time.time - StartTime) + Offset), Timer) / Timer;
	}

	void Spawn() {
		joint.connectedBody = ((GameObject)Instantiate(Prefab,transform.position,transform.rotation)).GetComponent<Rigidbody2D>();
		joint.connectedBody.transform.parent = transform.parent.parent;
		joint.enabled = true;
	}

	void Release() {
		Collider2D[] others = Physics2D.OverlapPointAll(joint.connectedBody.transform.position, AttachLayer);
		Debug.Log((int)AttachLayer);
		Debug.Log(others.Length);
		foreach(Collider2D other in others) {
			if(other != joint.connectedBody.GetComponent<Collider2D>()) {
				joint.connectedBody.transform.parent = other.transform;
				joint.connectedBody.isKinematic = true;
				break;
			}
		}
		joint.connectedBody = null;
		joint.enabled = false;
	}
}
