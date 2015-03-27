using UnityEngine;
using System.Collections;

public enum Ventricle {
	LEFT,
	RIGHT,
	NONE
};

public class HeartCollider : MonoBehaviour {
	public GameObject Heart;
	public GameObject RightVentricle;
	public GameObject LeftVentricle;
	public Ventricle ventricle;

	void ToggleZ(GameObject heart, bool front) {
		Vector3 position = heart.transform.position;
		position.z = front ? -5 : 0;
		heart.transform.position = position;
	}

	void ToggleColliders(GameObject parent, bool on) {
		Collider2D[] colChildren = parent.GetComponentsInChildren<Collider2D>();
		foreach (Collider2D collider in colChildren) {
			collider.enabled = on;
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(ventricle == Ventricle.LEFT) {
			ToggleColliders(LeftVentricle, true);
			ToggleColliders(RightVentricle, false);
			ToggleZ(Heart, true);
		} else if (ventricle == Ventricle.RIGHT) {
			ToggleColliders(RightVentricle, true);
			ToggleColliders(LeftVentricle, false);
			ToggleZ(Heart, true);
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if(ventricle == Ventricle.NONE) {
			ToggleColliders(LeftVentricle, false);
			ToggleColliders(RightVentricle, false);
			ToggleZ(Heart, false);
		}
	}

}
