using UnityEngine;
using System.Collections;

public class car : MonoBehaviour {

	public Vector2 initialVelocity = new Vector2(0f,60f);
	public Vector2 initialposition = new Vector2(0f,-2.5f);
	public float cutoffTimeInS = 3.0f;
	float timeInS = 0f;
	bool timerReached;

	// Use this for initialization
	void Start () {

		rigidbody2D.transform.position = initialposition;
		rigidbody2D.velocity = initialVelocity;

		timeInS = 0f;
		timerReached = false;
		//print ("Start()");

	}
	
	// Update is called once per frame
	void Update () {
		if (timerReached)
			return;
		timeInS += Time.deltaTime;
		
		rigidbody2D.velocity = new Vector2(0, (initialVelocity.y * ((cutoffTimeInS - timeInS)/cutoffTimeInS))) ;

		if(timeInS % 1 == 0)
			print ("TimeInS = " + timeInS);

		if (timeInS >= cutoffTimeInS) {
			OnCutOffTimeReachedCallback();
		}
	}

	void OnCutOffTimeReachedCallback()
	{
		/**
		 * Called when the timer reaches the specified cut-off time
		 */

		//print ("Cutoff time reached");
		timerReached = true;
		rigidbody2D.velocity = Vector2.zero;
	}

	void OnCollisionEnter2D()
	{
		// print ("player.cs onEnterCollision2D()");
		Die ();
	}
	
	void Die()
	{
		//To reload level
		//Called when the car hits an obstacle
		Application.LoadLevel (Application.loadedLevelName);
		
	}
}
