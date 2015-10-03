using UnityEngine;
using UnityEngine.UI; 
using System.Collections;

public class ScoreManager : MonoBehaviour {

	//PlayerPrefs prefs;												//Variable to fetch locally stored preferences from
	private static int score = 0, hiScore = 0;
	public Text scoreDisplay, hiScoreDisplay;
	static ScoreManager staticReference;
	//Constant keys for PlayerPrefs
	public static string PREF_HISCORE  = "user_high_score";

	// Use this for initialization
	void Start () {
		SetReferenceForStatic (this);
		ResetCurrentScore ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	static void ResetCurrentScore()
	{
		score = 0;
		hiScore = PlayerPrefs.GetInt (PREF_HISCORE, 0);
		UpdateDisplay ();
	}

	public static void AddToScore()
	{
		score ++;
		UpdateDisplay ();
	}

	static void SetReferenceForStatic(ScoreManager obj)
	{
		staticReference = obj;
	}

	static void UpdateDisplay()
	{
		if (staticReference == null) {
			print ("ScoreManager::UpdateDisplay() reference is null");
			return;
		}
		if (staticReference.scoreDisplay != null) {
			staticReference.scoreDisplay.text = score + "";		
		}
		if (staticReference.hiScoreDisplay != null) {
			staticReference.hiScoreDisplay.text = hiScore + "";		
		}
	}

	public static void StoreHiScore()
	{
		if (score > hiScore) {
			hiScore = score;
			PlayerPrefs.SetInt(PREF_HISCORE, hiScore);
			PlayerPrefs.Save();
		}
		UpdateDisplay ();
	}

}
