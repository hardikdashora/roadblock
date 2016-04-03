using UnityEngine;
using System.Collections;

public class MouseDetect : MonoBehaviour
{

    Vector2 shuntForceLeft = new Vector2(0, 0);
    Vector2 shuntForceRight = new Vector2(0, 0);
    public float swipeThreshold = 50f;
    public float shuntForce = 300f;
    public bool isLeftBlock;
    private bool isValidHit = false, isDragged = false; // flag for hit
    private Vector2 lastMousePosition;
    private float MouseDownPos; // down position
    private float MouseUpPos; // up position 

    public AudioSource flickSoundSource;
    private Vector3 screenPoint;
    private Vector3 offset;
    private float lockedXPosition;

    // Use this for initialization
    void Start()
    {

        if (isLeftBlock)
        {
            // Check if the block is a left swiping block
            // If it is, set shuntForceLeft as shuntForce
            // Else, set shuntForceRight as shuntForce

            shuntForceLeft = Vector2.right * shuntForce * -1;
            shuntForceRight = Vector2.zero;

        }
        else {
            shuntForceLeft = Vector2.zero;
            shuntForceRight = Vector2.right * shuntForce;
        }
        lockedXPosition = transform.position.x;

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDrag()
    {
        if (Time.timeScale <= 0)
        {
            //If the game is paused, ignore the dragging logic
            return;
        }
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;

        /// Applying constraints to drag
        if (isLeftBlock)
        {
            curPosition.x = Mathf.Min(curPosition.x, lockedXPosition);
        }
        else {
            curPosition.x = Mathf.Max(curPosition.x, lockedXPosition);
        }
        if (curPosition.x != transform.position.x)
        {
            isDragged = true;
        }
        curPosition.y = transform.position.y;
        curPosition.z = transform.position.z;

        transform.position = curPosition;
    }

    void OnMouseDown()
    {

        MouseDownPos = Input.mousePosition.x;
        print("Valid hit on " + gameObject.name + ". mouseDown hit at " + MouseDownPos);
        print("mouseDown hit at " + MouseDownPos);
        isValidHit = true;

        ///// Code for dragging
        /// 
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        ///// End 			
    }

    void OnMouseUp()
    {
        if (isValidHit)
        {
            MouseUpPos = Input.mousePosition.x;
            print("Valid hit on " + gameObject.name + ". Mouse up at : " + MouseUpPos);
            SwipeDirDetect();
        }
        isValidHit = false;
        if (isDragged)
        {
            forceShunt();
            isDragged = false;
        }
    }

    void SwipeDirDetect()
    {

        if ((MouseDownPos - MouseUpPos) >= swipeThreshold)
        {
            //Register Left Swipe
            OnLeftSwipe();
        }
        else if ((MouseDownPos - MouseUpPos) <= swipeThreshold * -1)
        {
            //Register Right Swipe
            OnRightSwipe();
        }
        else {
            //Deadzone release
            OnDeadzoneRelease();
        }
    }

    void OnRightSwipe()
    {
        // To house all actions to be performed when the parent object registers a right swipe
        if (!isLeftBlock)
        {
            // Check that the block isn't a left-shunting block. If it is, avoid; if not, 
            // assume it's a right-shunting block and shunt it
            ShuntToTheRight();
        }
        else {
            print("MouseDetect::OnRightSwipe() Swiping in the wrong direction");
        }
    }

    void OnLeftSwipe()
    {
        /**
 * print("Right Swipe on " + gameObject.name);
 * To house all actions to be performed when the parent object registers a right swipe
 * 
 * @author : SlashG
 */
        if (isLeftBlock)
        {
            // Check that the block is a left-shunting block. If it isn't, avoid; 
            // else, shunt it
            ShuntToTheLeft();
        }
        else {
            print("MouseDetect::OnRightSwipe() Swiping in the wrong direction");
        }
    }

    void forceShunt()
    {
        /**
     * Method detects which direction the box can be shunted and shunts it there.
     */
        if (isLeftBlock)
        {
            ShuntToTheLeft();
        }
        else {
            ShuntToTheRight();
        }
    }

    void OnDeadzoneRelease()
    {
        /**
 * Called when the user swipes on the object but releases too early.
 * This indicates that the swipe needs to be stronger.
 * Event is logged
 * 
 * @author : SlashG
 */

        print("MouseDetect::OnDeadzoneRelease() Swipe harder");
    }

    void ShuntToTheRight()
    {
        /**
 * Method to add force to the gameObject to the right
 * 
 * @author : SlashG
 */
        TryToPlayFlickSound();
        GetComponent<Rigidbody2D>().AddForce(shuntForceRight);
    }

    void ShuntToTheLeft()
    {
        /**
 * Method to add force to the gameObject to the left
 * 
 * @author : SlashG
 */
        TryToPlayFlickSound();
        GetComponent<Rigidbody2D>().AddForce(shuntForceLeft);
    }

    private void TryToPlayFlickSound()
    {
        /**
 * Method checks if crash-sound-source has
 * been init. If yes, it plays the crash sound.
 */

        if (flickSoundSource != null)
        {
            flickSoundSource.Stop();
            flickSoundSource.Play();
        }

    }

}
