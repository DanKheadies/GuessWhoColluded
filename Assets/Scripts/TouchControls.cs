// CC 4.0 International License: Attribution--HolisticGaming.com--NonCommercial--ShareALike
// Authors: David W. Corso
// Start: 07/31/2018
// Last:  04/11/2019

using UnityEngine;
using UnityEngine.UI;

// Controls the actions & display of the GUI input
public class TouchControls : MonoBehaviour
{
    private PlayerMovement pMove;
    public Toggle vibeTog;

    public bool bAaction;
    public bool bBaction;
    public bool bXaction;
    public bool bYaction;
    public bool bDown;
    public bool bLeft;
    public bool bRight;
    public bool bUp;

    public bool bAvoidSubUIElements;
    public bool bControlsVibrate;
    public bool bUIactive;

    public int currentContVibe;

    public string lastDirection;


    void Start()
    {
        // Initializers
        pMove = FindObjectOfType<PlayerMovement>();
        vibeTog = GameObject.Find("VibrateToggle").GetComponent<Toggle>();

        // Sets initial vibrate based off saved data
        if (!PlayerPrefs.HasKey("ControlsVibrate"))
        {
            currentContVibe = 1;
            vibeTog.isOn = true;
            bControlsVibrate = true;
        }
        else
        {
            currentContVibe = PlayerPrefs.GetInt("ControlsVibrate");

            // Set control type based off level
            if (currentContVibe == 1)
            {
                vibeTog.isOn = true;
                bControlsVibrate = true;
            }
            else if (currentContVibe == 0)
            {
                vibeTog.isOn = false; // Prob not necessary; gets called in function
                bControlsVibrate = true;
                ToggleVibrate();
            }
        }
    }

    void Update()
    {
        // Moving the player based off arrow flags
        if (pMove.bGWCUpdate &&
            !pMove.bStopPlayerMovement)
        {
            if (bUp)
            {
                pMove.GWCMove(0.0f, 1.0f);
                bUp = false;
            }

            if (bLeft)
            {
                pMove.GWCMove(-1.0f, 0.0f);
                bLeft = false;
            }

            if (bDown)
            {
                pMove.GWCMove(0.0f, -1.0f);
                bDown = false;
            }

            if (bRight)
            {
                pMove.GWCMove(1.0f, 0.0f);
                bRight = false;
            }
        }
    }

    // A button flagging
    public void aActionStart()
    {
        bAaction = true;
        bUIactive = true;
    }
    public void aActionStop()
    {
        bAaction = false;
        bUIactive = false;
    }

    // B button flagging
    public void bActionStart()
    {
        bBaction = true;
        bUIactive = true;
    }
    public void bActionStop()
    {
        bBaction = false;
        bUIactive = false;
    }
    
    // X button flagging
    public void xActionStart()
    {
        bXaction = true;
        bUIactive = true;
    }
    public void xActionStop()
    {
        bXaction = false;
        bUIactive = false;
    }

    // Y button flagging
    public void yActionStart()
    {
        bYaction = true;
        bUIactive = true;
    }
    public void yActionStop()
    {
        bYaction = false;
        bUIactive = false;
    }

    // Movement / arrow button flags
    // Cartesian coordinate arrangement
    public void PressedUpArrow()
    {
        bUp = true;
        bUIactive = true;
    }
    public void UnpressedUpArrow()
    {
        bUp = false;
        bUIactive = false;

        lastDirection = "up";
    }

    public void PressedLeftArrow()
    {
        bLeft = true;
        bUIactive = true;
    }
    public void UnpressedLeftArrow()
    {
        bLeft = false;
        bUIactive = false;

        lastDirection = "left";
    }

    public void PressedDownArrow()
    {
        bDown = true;
        bUIactive = true;
    }
    public void UnpressedDownArrow()
    {
        bDown = false;
        bUIactive = false;

        lastDirection = "down";
    }

    public void PressedRightArrow()
    {
        bRight = true;
        bUIactive = true;
    }
    public void UnpressedRightArrow()
    {
        bRight = false;
        bUIactive = false;

        lastDirection = "right";
    }

    // Clear all movement / arrow buttons
    public void UnpressedAllArrows()
    {
        UnpressedUpArrow();
        UnpressedLeftArrow();
        UnpressedDownArrow();
        UnpressedRightArrow();
    }

    // Vibrate on touch
    public void Vibrate()
    {
        if (bControlsVibrate)
        {
        #if UNITY_ANDROID
            Handheld.Vibrate();
        #endif

        #if UNITY_IOS
            Handheld.Vibrate();
        #endif
        }
    }

    public void ToggleVibrate()
    {
        if (bControlsVibrate)
        {
            bControlsVibrate = false;
            currentContVibe = 0;
        }
        else if (!bControlsVibrate)
        {
            bControlsVibrate = true;
            currentContVibe = 1;
        }
    }

    // DC TODO 02/14/2019 -- Avoid & UIAct might be doing the same thing; see about consolidating
    public void AvoidSubUIElements()
    {
        bAvoidSubUIElements = true;
    }

    public void StopAvoidSubUIElements()
    {
        bAvoidSubUIElements = false;
    }

    public void UIActive()
    {
        bUIactive = true;
    }
    public void UIInactive()
    {
        bUIactive = false;
    }
}
