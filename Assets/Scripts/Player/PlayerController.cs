using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody2D), typeof(Collider2D), typeof(Animator))]
public class PlayerController : MonoBehaviour {
	public float Speed;
	public float JumpSpeed;
	public float JumpSpeedDelay;
	public float JumpSpeedFalloff;
	
	public LayerMask GroundLayer;
	public bool canMove;
	public bool canJump;
	
	public Feet Feet;
	public bool isGrounded { get { return Feet.isGrounded; } }
	
	public LayerMask TriggerLayer;
	
	private float lastJump;
	
	public Vector2 Input;
	private Animator anim;
	
	// Use this for initialization
	void Start () {
		Input = Vector2.zero;
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		// set animation
		anim.SetFloat("speed",Input.x);
	}
	
	// Fixed update called every physics update
	void FixedUpdate() {
		if(canMove) {
			Vector3 d = Vector2.zero;
			d.x = Speed * Input.x;
			d.y = canJump && isGrounded ? JumpSpeed * Input.y : 0;
			if(canJump && isGrounded) {
				d.y = JumpSpeed * Input.y;
				lastJump = Time.time;
			} else if(Time.time - lastJump < JumpSpeedDelay) {
				d.y = JumpSpeedFalloff * (JumpSpeed * Input.y);
			}
			
			rigidbody2D.AddForce(d, ForceMode2D.Impulse);
		}
	}
	
	public void DoAction() {
		Collider2D col = Physics2D.OverlapPoint(transform.position,TriggerLayer);
		if(col) {
			col.GetComponent<Trigger>().OnTrigger();
		}
	}
}
