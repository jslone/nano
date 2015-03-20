using UnityEngine;
using System.Collections;

public class MicroLimbs : MonoBehaviour {
	public int Limbs
	{
		get { return _limbs; }
		set
		{
			_limbs = value;
			animator.SetInteger("limbs",value);
		}
	}

	private int _limbs = 0;
	private Animator animator;
	// Use this for initialization
	void Awake () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
