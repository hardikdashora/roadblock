using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;

public class AdScript : MonoBehaviour {

	public const string AD_APP_NAME = "Roadblock",
						AD_UNIT_ID_ANDROID = "ca-app-pub-7653242401865992/7216195462", 
						AD_UNIT_ID_IOS = "ca-app-pub-7653242401865992/3295746262", 
						AD_UNIT_NAME = "roadblock2393";

	// Use this for initialization
	void Start () {
		RequestBanner();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void RequestBanner()
	{
		#if UNITY_ANDROID
		string adUnitId = AD_UNIT_ID_ANDROID;
		#elif UNITY_IPHONE
		string adUnitId = AD_UNIT_ID_IOS;
		#else
		string adUnitId = "unexpected_platform";
		#endif

		print("AdScript::RequestBanner() AD Unit ID = " + adUnitId);

		// Create a 320x50 banner at the top of the screen.
		BannerView bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);
		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder().Build();
		// Load the banner with the request.
		bannerView.LoadAd(request);
	}

}
