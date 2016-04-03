using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms;
using GooglePlayGames;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	//PlayerPrefs prefs;												//Variable to fetch locally stored preferences from
	private static int score = 0, hiScore = 0;
	public Text scoreDisplay, hiScoreDisplay, optionalTutorial;
	static ScoreManager staticReference;

    public const float GPG_PROGRESS_UNLOCK = 100f, GPG_PROGRESS_REVEAL = 0f;

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

	public static int GetCurrentScore ()
	{
		return score;
	}

	public static bool IsNewHiScore()
	{
		bool result;
		if (score > hiScore)
						result = true;
		else
			result = false;
		print ("ScoreManager::IsNewHiScore() hiscore = " + hiScore + ",  result = " + result);
		return result;
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

        ScoreUpdateCallback();

	}

    private static void ScoreUpdateCallback()
    {
        /**
         * Callback function that is called whenever the score is updated.
         * Any code to broadcast to any score update listeners should be 
         * put here.
         *
         * Achievements related to score are also fired here
         *
         */

        if (score % 10 == 0)
        {
            // increase speed after every 10 blocks
            GamePause.IncreaseSpeed();
        }

        if (score == 10)
        {
            Social.ReportProgress(RoadblockGPG.achievement_baby_steps, GPG_PROGRESS_UNLOCK, (bool success) => { print("ScoreManager::ScoreUpdateCallback() unlocking achievement 'Baby Steps' success = " + success); });
        }
        if (score == 100)
        {
            Social.ReportProgress(RoadblockGPG.achievement_pro_spotted, GPG_PROGRESS_UNLOCK, (bool success) => { print("ScoreManager::ScoreUpdateCallback() unlocking achievement 'Pro Spotted' success = " + success); });
        }
        if (score == 1000)
        {
            Social.ReportProgress(RoadblockGPG.achievement_a_ton, GPG_PROGRESS_UNLOCK, (bool success) => { print("ScoreManager::ScoreUpdateCallback() unlocking achievement 'A Ton' success = " + success); });
        }

        UpdateDisplay();
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
		
		if (staticReference.optionalTutorial != null) {
			if(hiScore > 2)
			{
				Destroy( staticReference.optionalTutorial.gameObject );
			}
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

	public void EnableHUD()
	{
		// Function to display HUD

		Canvas canvas = GetComponentInParent<Canvas> ();
		if (canvas == null) 
		{
			print ("ScoreManager::EnableHUD() canvas component is null");		
		} 
		else 
		{
			print ("ScoreManager::EnableHUD() canvas component is not null");	
			canvas.enabled = true;
		}
	
	}
	
	public void DisableHUD()
	{
		// Function to display HUD
		
		Canvas canvas = GetComponentInParent<Canvas> ();
		if (canvas == null) 
		{
			print ("ScoreManager::DisableHUD() canvas component is null");		
		} 
		else 
		{
			print ("ScoreManager::DisableHUD() canvas component is not null");	
			canvas.enabled = false;
		}
		
	}
}
