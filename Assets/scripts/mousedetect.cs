using UnityEngine;
using System.Collections;

public class MouseDetect : MonoBehaviour {

	public Vector2 SwipeForceLeft = new Vector2 (-300,0);
	public Vector2 SwipeForceRight = new Vector2(300,0);
	public float swipeThreshold = 50f;



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
			print ("mouseDown hit at " + MouseDownPos);
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
		
		if ((MouseDownPos - MouseUpPos) >= swipeThreshold) {
			//Register Left Swipe
			OnLeftSwipe ();
		} else if ((MouseDownPos - MouseUpPos) <= swipeThreshold * -1) {
			//Register Right Swipe
			OnRightSwipe ();
		} else {
			//Deadzone release
			OnDeadzoneRelease();
		}
	}
	
	void OnRightSwipe()
	{
		//print("Right Swipe on " + gameObject.name);
		// To house all actions to be performed when the parent object registers a right swipe
		ShuntToTheRight ();
	}
	
	void OnLeftSwipe()
	{
		//print("Right Swipe on " + gameObject.name);
		// To house all actions to be performed when the parent object registers a right swipe
		ShuntToTheLeft ();
	}
	
	void OnDeadzoneRelease()
	{
		print("Swipe harder");
	}
	
	void ShuntToTheRight()
	{

		rigidbody2D.AddForce(SwipeForceRight);
	}
	void ShuntToTheLeft()
	{
		rigidbody2D.AddForce(SwipeForceLeft);
	}

}
