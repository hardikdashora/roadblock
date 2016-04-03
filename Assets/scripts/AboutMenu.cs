using UnityEngine;
using System.Collections;

public class AboutMenu : MonoBehaviour {

    const string URL_350GC = "http://350gc.com", URL_THREE_CHILLIES = "http://threechillies.com";
    public Canvas pauseMenu;

    public void Goto350GCWebsite()
    {
        Application.OpenURL(URL_350GC);
    }
    public void GotoThreeChilliesWebsite()
    {
        Application.OpenURL(URL_THREE_CHILLIES);
    }

    public void HideAboutMenu()
    {
        if (pauseMenu != null)
        {
            print("AboutMenu::HideAboutMenu() 'pauseMenu' isn't null. Hiding menu");
            GetComponent<Canvas>().enabled = false;
            pauseMenu.enabled = true;
        }
        else
        {
            print("AboutMenu::HideAboutMenu() 'pauseMenu' is null. Can't hide.");
        }
    }
}
