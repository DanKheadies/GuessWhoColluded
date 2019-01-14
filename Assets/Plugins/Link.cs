// CC 4.0 International License: Attribution--HolisticGaming.com--NonCommercial--ShareALike
// Authors: valyard (https://github.com/valyard/UnityWebGLOpenLink)
// Contributors: David W. Corso
// Start: --/--/----
// Last:  01/13/2019

using UnityEngine;
using System.Runtime.InteropServices;

public class Link : MonoBehaviour 
{
    public string ColluminacLink;
    public string CharactersLink;

    public bool bColluminac;
    public bool bCharacters;

    private void Start()
    {
        ColluminacLink = "http://guesswhocolluded.com/colluminac.html";
        CharactersLink = "http://guesswhocolluded.com/colluminac.html#characters";
    }

    public void OpenLink()
	{
        if (bColluminac)
        {
            Application.OpenURL(ColluminacLink);
        }
        else if (bCharacters)
        {
            Application.OpenURL(CharactersLink);
        }
    }

	public void OpenLinkJS()
	{
        if (bColluminac)
        {
            Application.ExternalEval("window.open('" + ColluminacLink + "');");
        }
        else if (bCharacters)
        {
            Application.ExternalEval("window.open('" + CharactersLink + "');");
        }
	}

    // Opens links for non-Unity Editor Apps (i.e. standalone, webgl, etc.)
	public void OpenLinkJSPlugin()
	{
        // DC 01/13/2019 -- Causes an error in Unity if this is active; avoid error by doing nothing here
        // Will still open the link via alt code (above?)
        if (!Application.isEditor)
        {
            if (bColluminac)
            {
                openWindow(ColluminacLink);
            }
            else if (bCharacters)
            {
                openWindow(CharactersLink);
            }
        }
	}

	[DllImport("__Internal")]
	private static extern void openWindow(string url);

}