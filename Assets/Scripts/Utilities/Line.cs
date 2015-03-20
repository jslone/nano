using UnityEngine;
using System.Collections;

[RequireComponent (typeof(LineRenderer))]
public class Line : MonoBehaviour {
	public Transform[] links;
	private LineRenderer lrend;

	// Use this for initialization
	void Start () {
		lrend = GetComponent<LineRenderer> ();
		lrend.SetWidth (1.0f, 1.0f);
		lrend.SetVertexCount (links.Length);
	}
	
	// Update is called once per frame
	void Update () {
		for(int i = 0; i < links.Length; i++) {
			lrend.SetPosition(i,links[i].localPosition);
		}
	}
}
