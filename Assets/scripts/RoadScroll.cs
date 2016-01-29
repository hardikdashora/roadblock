using UnityEngine;
using System.Collections;

public class RoadScroll : MonoBehaviour {
	
	public float speed = 0.5f;
	float initialXOffset, initialYOffset;
	
	// Use this for initialization
	void Start () {
		//print ("Texture height = " + renderer.material.mainTexture.height);
		initialXOffset = GetComponent<Renderer>().material.mainTextureOffset.x;
		initialYOffset = GetComponent<Renderer>().material.mainTextureOffset.y;
	}
	
	// Update is called once per frame
	void Update () {
		
		Vector2 offset = new Vector2 ( initialXOffset, initialYOffset + ((speed * Time.time) % GetComponent<Renderer>().material.mainTexture.height));
		
		GetComponent<Renderer>().material.mainTextureOffset = (offset);
	}
}