﻿// CC 4.0 International License: Attribution--HolisticGaming.com--NonCommercial--ShareALike
// Authors: David W. Corso
// Start: 08/02/2018
// Last:  08/10/2018

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// Fades text for animations and scene transitions (i.e. loading screens)
public class TextFader : MonoBehaviour
{
    public Text fadingText;

    public bool bFadeIn;
    public bool bFadeOut;

    public float preFadeInDelay;
    public float fadeInTime;
    public float postFadeInDelay;
    public float preFadeOutDelay;
    public float fadeOutTime;
    public float postFadeOutDelay;

    private IEnumerator Start()
    {
        if (bFadeIn == true)
        {
            fadingText.canvasRenderer.SetAlpha(0.0f);
            yield return new WaitForSeconds(preFadeInDelay);
            FadeIn();
            yield return new WaitForSeconds(postFadeInDelay);
        }
        if (bFadeOut == true)
        {
            fadingText.canvasRenderer.SetAlpha(1.0f);
            yield return new WaitForSeconds(preFadeOutDelay);
            FadeOut();
            yield return new WaitForSeconds(postFadeOutDelay);
        }
    }

    void FadeIn()
    {
        fadingText.CrossFadeAlpha(1.0f, fadeInTime, false);
    }

    void FadeOut()
    {
        fadingText.CrossFadeAlpha(0.0f, fadeOutTime, false);
    }
}
