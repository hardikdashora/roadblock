using UnityEngine;
using System.Collections;

public class RoadScroll : MonoBehaviour {
	
	public float speed = 0.5f;
	
	// Use this for initialization
	void Start () {
		//print ("Texture height = " + renderer.material.mainTexture.height);
	}
	
	// Update is called once per frame
	void Update () {
		
		Vector2 offset = new Vector2 (0,(speed * Time.time) % renderer.material.mainTexture.height);
		
		renderer.material.mainTextureOffset = (offset);
	}
}