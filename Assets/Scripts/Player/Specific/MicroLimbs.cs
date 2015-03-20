using UnityEngine;
using System.Collections;

public class MicroLimbs : MonoBehaviour {
	public static int Limbs = 0;
	public static int ActiveLimbs = 0;

	private Animator animator;
	private PlayerController player;

	// Use this for initialization
	void Awake () {
		animator = GetComponent<Animator>();
		player = GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		animator.SetInteger("limbs", Limbs);
		player.canMove = ActiveLimbs == Limbs;
	}
}
