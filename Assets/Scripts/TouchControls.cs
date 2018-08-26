// CC 4.0 International License: Attribution--HolisticGaming.com--NonCommercial--ShareALike
// Authors: David W. Corso
// Start: 07/31/2018
// Last:  08/26/2018

using UnityEngine;
using UnityEngine.SceneManagement;

// Controls the actions & display of the GUI input
public class TouchControls : MonoBehaviour
{
    private PlayerMovement pMove;
    private Scene scene;

    public bool bAaction;
    public bool bBaction;
    public bool bXaction;
    public bool bYaction;
    public bool bDown;
    public bool bLeft;
    public bool bRight;
    public bool bUp;
    public bool bUIactive;


    void Start()
    {
        // Initializers
        pMove = FindObjectOfType<PlayerMovement>();
        scene = SceneManager.GetActiveScene();
    }

    void Update()
    {
        // Moving the player based off arrow flags
        if (scene.name == "GuessWhoColluded")
        {
            if (bLeft && !pMove.bStopPlayerMovement)
            {
                if (pMove.bGWCUpdate)
                {
                    pMove.GWCMove(-1.0f, 0.0f);
                    bLeft = false; // dis
                }
            }

            if (bRight && !pMove.bStopPlayerMovement)
            {
                if (pMove.bGWCUpdate)
                {
                    pMove.GWCMove(1.0f, 0.0f);
                    bRight = false; // dis
                }
            }

            if (bUp && !pMove.bStopPlayerMovement)
            {
                if (pMove.bGWCUpdate)
                {
                    pMove.GWCMove(0.0f, 1.0f);
                    bUp = false; // dis
                }
            }

            if (bDown && !pMove.bStopPlayerMovement)
            {
                if (pMove.bGWCUpdate)
                {
                    pMove.GWCMove(0.0f, -1.0f);
                    bDown = false; // dis
                }
            }
        }
        else
        {
            if (bLeft && !pMove.bStopPlayerMovement)
            {
                pMove.Move(-1.0f, 0.0f);
            }

            if (bRight && !pMove.bStopPlayerMovement)
            {
                pMove.Move(1.0f, 0.0f);
            }

            if (bUp && !pMove.bStopPlayerMovement)
            {
                pMove.Move(0.0f, 1.0f);
            }

            if (bDown && !pMove.bStopPlayerMovement)
            {
                pMove.Move(0.0f, -1.0f);
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
    public void PressedLeftArrow()
    {
        bLeft = true;
        bUIactive = true;
    }
    public void UnpressedLeftArrow()
    {
        bLeft = false;
        bUIactive = false;
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
    }

    public void PressedUpArrow()
    {
        bUp = true;
        bUIactive = true;
    }
    public void UnpressedUpArrow()
    {
        bUp = false;
        bUIactive = false;
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
    }

    // Clear all movement / arrow buttons
    public void UnpressedAllArrows()
    {
        UnpressedDownArrow();
        UnpressedLeftArrow();
        UnpressedRightArrow();
        UnpressedUpArrow();
    }

    // Vibrate on touch
    public void Vibrate()
    {
        Handheld.Vibrate();
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
