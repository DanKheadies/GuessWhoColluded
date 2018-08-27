// CC 4.0 International License: Attribution--HolisticGaming.com--NonCommercial--ShareALike
// Authors: valyard (https://github.com/valyard/UnityWebGLOpenLink)
// Contributors: David W. Corso
// Start: --/--/----
// Last:  08/27/2018

using UnityEngine;
using System.Runtime.InteropServices;

public class Link : MonoBehaviour 
{
    public string KREAMinacLink;

    private void Start()
    {
        KREAMinacLink = "https://docs.google.com/document/d/1Q8-YiK7TAVkGBsrL_3F9a92JjTFYVCyLcg-RQNNKYkM/edit?usp=sharing";
    }

    public void OpenLink()
	{
		Application.OpenURL(KREAMinacLink);
	}

	public void OpenLinkJS()
	{
		Application.ExternalEval("window.open('"+ KREAMinacLink + "');");
	}

	public void OpenLinkJSPlugin()
	{
        openWindow(KREAMinacLink);
	}

	[DllImport("__Internal")]
	private static extern void openWindow(string url);

}