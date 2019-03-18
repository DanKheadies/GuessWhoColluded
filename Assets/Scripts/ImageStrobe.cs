// CC 4.0 International License: Attribution--HolisticGaming.com--NonCommercial--ShareALike
// Authors: David W. Corso
// Start: 07/31/2018
// Last:  03/17/2019

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// Strobe an image's opacity / alpha for the duration of its existence
public class ImageStrobe : MonoBehaviour
{
    private Image image;

    public int pulseTime;

    void Start()
    {
        // Initializers
        image = GetComponent<Image>();

        pulseTime = 1;
    }

    public IEnumerator Strobe()
    {
        for (int i = 1; i > 0; i++)
        {
            yield return new WaitForSeconds(pulseTime);
            image.canvasRenderer.SetAlpha(1.0f);
            yield return new WaitForSeconds(pulseTime);
            image.canvasRenderer.SetAlpha(0.0f);
        }
    }

    public IEnumerator StopStrobe()
    {
        image.canvasRenderer.SetAlpha(1.0f);
        yield return new WaitForSeconds(0);
    }
}
