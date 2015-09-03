using UnityEngine;
using System.Collections;

public class DestroyOnCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		print ("Something hit me!");
		if (coll.gameObject.CompareTag ("Enemy")) {
			print ("It's an enemy!!");
			Destroy(coll.gameObject);
		}
	}
}
