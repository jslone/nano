using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody2D), typeof(Collider2D), typeof(Animator))]
public class PlayerController : MonoBehaviour {
	
	public float Speed;
	public float JumpSpeed;
	
	public LayerMask GroundLayer;
	public bool canMove;
	public bool canJump;
	
	public bool grounded
	{
		get
		{
			return Physics2D.Raycast(transform.position, -Vector2.up, 0.1f, GroundLayer).collider != null;
		}
	}
	
	private Vector2 delta;
	private Animator anim;
	
	// Use this for initialization
	void Start () {
		delta = Vector2.zero;
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		// get delta vector
		delta.x = Speed * Input.GetAxis("Horizontal");
		delta.y = JumpSpeed * Input.GetAxis("Jump");
		anim.SetFloat("speed",delta.x);
	}
	
	// Fixed update called every physics update
	void FixedUpdate() {
		if(canMove) {
			Vector3 d = delta;
			d.y = canJump && grounded ? d.y : 0;
			
			rigidbody2D.AddForce(d);
		}
	}
}
