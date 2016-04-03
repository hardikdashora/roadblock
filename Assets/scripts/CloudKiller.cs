using UnityEngine;
using System.Collections;

public class CloudKiller : MonoBehaviour {

	const float killAtY = -6f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y <= killAtY)
			Destroy (gameObject);
	}
}
