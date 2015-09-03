using UnityEngine;
using System.Collections;

public class mousedetect : MonoBehaviour {

	public Vector2 SwipeForceLeft = new Vector2 (-5000,0);
	public Vector2 SwipeForceRight = new Vector2(5000,0);

	private bool isValidHit = false; // flag for hit

	private float MouseDownPos; // down position
	private float MouseUpPos; // up position 


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	 void OnMouseDown()
	{
			MouseDownPos = Input.mousePosition.x;
			print ("Valid hit on " + gameObject.name + ". mouseDown hit at " + MouseDownPos);
			//print ("mouseDown hit at " + MouseDownPos);
			isValidHit = true;
			
	}

	void OnMouseUp()
	{
		if (isValidHit) {
			MouseUpPos = Input.mousePosition.x;
			print ("Valid hit on " + gameObject.name + ". Mouse up at : " + MouseUpPos);
			SwipeDirDetect();
		}
		isValidHit = false;
	}

	void SwipeDirDetect()
	{
		if ((MouseDownPos - MouseUpPos) < -50) 
		{
			print("Right Swipe on " + gameObject.name);
			rigidbody2D.AddForce(SwipeForceRight);
			rigidbody2D.AddTorque(50);
			//Destroy(gameObject);
		} 

		if ((MouseDownPos - MouseUpPos) > 50) 
		{
			print("Left Swipe on" + gameObject.name);
			rigidbody2D.AddForce(SwipeForceLeft);
			rigidbody2D.AddTorque(-50);
			//Destroy(gameObject);
		}
	}

	/*void OnMouseDown(){
		// this object was clicked - do something
		print("love mera hit hit");
		//clone.Destroy (gameObject);
	}   */
}
