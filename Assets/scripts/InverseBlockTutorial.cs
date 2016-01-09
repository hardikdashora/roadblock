using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InverseBlockTutorial : MonoBehaviour
{
		private const int tutorialThreshold = 1; 				// Constant defining how many times the user is shown the tutorial
		private const string tutorialKey = "no_of_tutorial_displays", tutorialGameObjectName = "TutorialCanvas";
		private static Canvas tutorialCanvas;
		

		// Use this for initialization
		void Start ()
		{
				print ("InverseBlockTutorial::Start() ");
				GetTutorialCanvasIfNeeded ();
				if (!HasUserLearnedInverseBlocks ()) {
						ShowTutorial ();
				}
		}
		
		void GetTutorialCanvasIfNeeded ()
		{
				/**
				 * Method gets Canvas reference containing tutorial and 
				 * stores it in a static variable 'tutorialCanvas'
				 */ 
				if(tutorialCanvas == null)
				{
					GameObject gameObject = GameObject.Find (tutorialGameObjectName);
					tutorialCanvas = gameObject.GetComponent<Canvas> ();
				}
		}

		bool HasUserLearnedInverseBlocks ()
		{
				/**
		 * Method returns bool as to whether the user has seen
		 * the tutorial and doesn't need to see it anymore
		 * 
		 * NOTE : As of now, the user is shown the tutorial twice
		 */

				int noOfTutorialDisplays = PlayerPrefs.GetInt (tutorialKey, 0);
				print ("InverseBlockTutorial::HasUserLearnedInverseBlocks() No of tut displays = " + noOfTutorialDisplays);
				if (noOfTutorialDisplays >= tutorialThreshold) {
						return true;		
				} else {
						return false;		
				}

		}

		static void RegisterTutorialDismissal ()
		{
				/**
		 * Method registers that the user has dismissed the tutorial
		 * and updates PlayerPrefs accordingly
		 */
		
				int noOfTutorialDisplays = PlayerPrefs.GetInt (tutorialKey, 0);
				PlayerPrefs.SetInt (tutorialKey, ++noOfTutorialDisplays);
		
		}
	
		public static void ShowTutorial ()
		{
				/**
		 * Method shows 'tutorialCanvas' if it isn't null
		 */
		
				if (tutorialCanvas != null) {
						tutorialCanvas.enabled = true;	
						GamePause.StatPauseGame();	
				}
		}
	
		public static void HideTutorial ()
		{
				/**
		 * Method shows 'tutorialCanvas' if it isn't null
		 */
		
				if (tutorialCanvas != null) {
						tutorialCanvas.enabled = false;		
 						RegisterTutorialDismissal();
						GamePause.StatResumeGame();
				}
		}


}
