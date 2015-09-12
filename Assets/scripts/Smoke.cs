using UnityEngine;
using System.Collections;

public class Smoke : MonoBehaviour {

	Vector2 downForce = new Vector2 (0f, -50f);
	public float timeRemaining, alpha;

	public static float scaleFactor = 0.02f, destroyInS = 1f;

	// Use this for initialization
	void Start () {
		timeRemaining = destroyInS;
		rigidbody2D.AddForce (downForce);
		transform.localScale = new Vector3 (transform.localScale.x * (0.25f), transform.localScale.y * (0.25f), transform.localScale.z );

		}

	// Update is called once per frame
	void Update () {

		transform.localScale = new Vector3 (transform.localScale.x * ( 1+ scaleFactor), transform.localScale.y * ( 1+ scaleFactor), transform.localScale.z );
		alpha = timeRemaining / destroyInS;
		renderer.material.color = new Color(  
		                                        renderer.material.color.r,
		                                        renderer.material.color.g,
		                                        renderer.material.color.b,
		                                    	alpha);
		timeRemaining -= Time.deltaTime;
		if (timeRemaining <= 0f) {
			Destroy(gameObject);		
		}
	}
}