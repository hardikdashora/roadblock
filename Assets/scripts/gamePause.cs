using UnityEngine;
using System.Collections;

public class gamePause : MonoBehaviour {
	// Use this for initialization
	
	private float MouseDownPos; // down position
	private float MouseUpPos; // up position 


	void Start () {
	
	}

	
	// Update is called once per frame
	void Update () {
	

	}

	void OnMouseDown()
	{
		MouseDownPos = Input.mousePosition.x;
		print ("Valid hit on " + gameObject.name + ". mouseDown hit at " + MouseDownPos);
		print ("mouseDown hit at " + MouseDownPos);
		
	}
	

}
