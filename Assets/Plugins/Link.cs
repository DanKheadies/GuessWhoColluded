// CC 4.0 International License: Attribution--HolisticGaming.com--NonCommercial--ShareALike
// Authors: David W. Corso
// Start: --/--/----
// Last:  06/29/2019

using UnityEngine;

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
            #if UNITY_WEBGL 
                Application.ExternalEval("window.open(\"http://guesswhocolluded.com/colluminac.html\",\"_blank\")");
            #endif

            #if !UNITY_WEBGL 
                Application.OpenURL(ColluminacLink);
            #endif
        }
        else if (bCharacters)
        {
            #if UNITY_WEBGL 
                Application.ExternalEval("window.open(\"http://guesswhocolluded.com/colluminac.html#characters\",\"_blank\")");
            #endif

            #if !UNITY_WEBGL 
                Application.OpenURL(CharactersLink);
            #endif
            Application.OpenURL(CharactersLink);
        }
    }
}