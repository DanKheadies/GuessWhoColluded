// CC 4.0 International License: Attribution--HolisticGaming.com--NonCommercial--ShareALike
// Authors: David W. Corso
// Start: 07/31/2018
// Last:  04/11/2019

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// Change the text / color of a button after it's clicked
public class ChangeButtonText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    public Text buttonText;

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Red
        buttonText.color = new Color(255.0f / 255.0f, 0.0f / 255.0f, 0.0f / 255.0f);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Blue
        buttonText.color = new Color(22.0f / 255.0f, 44.0f / 255.0f, 119.0f / 255.0f);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Red
        buttonText.color = new Color(255.0f / 255.0f, 0.0f / 255.0f, 0.0f / 255.0f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // White
        buttonText.color = new Color(255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f);
    }
}
