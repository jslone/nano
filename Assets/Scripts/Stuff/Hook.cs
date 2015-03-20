using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Collider2D), typeof(AnchoredJoint2D))]
public class Hook : MonoBehaviour {
	AnchoredJoint2D joint;

	// Use this for initialization
	void Start () {
		joint = GetComponent<AnchoredJoint2D>();
		joint.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxis("Vertical") < 0) {
			//child.GetComponent<Rigidbody2D>().isKinematic = true;
			joint.connectedBody = null;
			joint.enabled = false;
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(joint.connectedBody == null && other.gameObject.layer == LayerMask.NameToLayer("Player")) {
			joint.enabled = true;
			joint.connectedBody = other.GetComponent<Rigidbody2D>();
			joint.connectedAnchor = other.transform.Find("Head").localPosition;
		}
	}
}
