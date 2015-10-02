using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour {

	public GameObject EmptyPauseBut;

	// Use this for initialization
	void Start () {
		transform.position = new Vector3(-1.3f, -2.1f, -5.0f);
		Instantiate(EmptyPauseBut, transform.position,Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
