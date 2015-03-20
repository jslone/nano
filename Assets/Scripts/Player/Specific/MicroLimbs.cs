using UnityEngine;
using System.Collections;

public class MicroLimbs : MonoBehaviour {
	public static int Limbs = 0;

	private Animator animator;
	// Use this for initialization
	void Awake () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		animator.SetInteger("limbs", Limbs);
	}
}
