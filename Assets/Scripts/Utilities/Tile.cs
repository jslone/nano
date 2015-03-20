using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Renderer))]
public class Tile : MonoBehaviour {
	public Vector2 scale = new Vector2(5.0f, 5.0f);

	// Use this for initialization
	void Awake () {
		GetComponent<Renderer>().material.mainTextureScale = new Vector2 (transform.localScale.x / scale.x, transform.localScale.y / scale.y);
		GetComponent<Renderer>().material.mainTexture.wrapMode = TextureWrapMode.Repeat;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
