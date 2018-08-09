﻿// CC 4.0 International License: Attribution--HolisticGaming.com--NonCommercial--ShareALike
// Authors: David W. Corso
// Start: 07/31/2018
// Last:  07/31/2018

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Controls the actions & display of the GUI input
public class TouchControls : MonoBehaviour
{
    private PlayerMovement thePlayer;
    private Scene scene;

    public bool bAction;
    public bool bBaction;
    public bool bXaction;
    public bool bYaction;
    public bool bDown;
    public bool bLeft;
    public bool bRight;
    public bool bUp;


    void Start()
    {
        // Initializers
        scene = SceneManager.GetActiveScene();
        thePlayer = FindObjectOfType<PlayerMovement>();

        // DC TODO
        bAction = false;
        bBaction = false;
        bXaction = false;
        bYaction = false;
        bDown = false;
        bLeft = false;
        bRight = false;
        bUp = false;
    }

    void Update()
    {
        // Moving the player based off arrow flags
        if (scene.name == "GuessWhoColluded")
        {
            if (bLeft && !thePlayer.bStopPlayerMovement)
            {
                if (thePlayer.bGWCUpdate)
                {
                    thePlayer.GWCMove(-1.0f, 0.0f);
                    bLeft = false; // dis
                }

                //if (bLeft)
                //{
                //    thePlayer.bGWCUpdate = false;
                //}
                //else
                //{
                //    thePlayer.bGWCUpdate = true;
                //}
            }

            if (bRight && !thePlayer.bStopPlayerMovement)
            {
                if (thePlayer.bGWCUpdate)
                {
                    thePlayer.GWCMove(1.0f, 0.0f);
                    bRight = false; // dis
                }

                //if (bRight)
                //{
                //    thePlayer.bGWCUpdate = false;
                //}
                //else
                //{
                //    thePlayer.bGWCUpdate = true;
                //}
            }

            if (bUp && !thePlayer.bStopPlayerMovement)
            {
                if (thePlayer.bGWCUpdate)
                {
                    thePlayer.GWCMove(0.0f, 1.0f);
                    bUp = false; // dis
                }

                //if (bUp)
                //{
                //    thePlayer.bGWCUpdate = false;
                //}
                //else
                //{
                //    thePlayer.bGWCUpdate = true;
                //}
            }

            if (bDown && !thePlayer.bStopPlayerMovement)
            {
                if (thePlayer.bGWCUpdate)
                {
                    thePlayer.GWCMove(0.0f, -1.0f);
                    bDown = false; // dis
                }

                //if (bDown)
                //{
                //    thePlayer.bGWCUpdate = false;
                //}
                //else
                //{
                //    thePlayer.bGWCUpdate = true;
                //}
            }
        }
        else
        {
            if (bLeft && !thePlayer.bStopPlayerMovement)
            {
                thePlayer.Move(-1.0f, 0.0f);
            }

            if (bRight && !thePlayer.bStopPlayerMovement)
            {
                thePlayer.Move(1.0f, 0.0f);
            }

            if (bUp && !thePlayer.bStopPlayerMovement)
            {
                thePlayer.Move(0.0f, 1.0f);
            }

            if (bDown && !thePlayer.bStopPlayerMovement)
            {
                thePlayer.Move(0.0f, -1.0f);
            }
        }
    }

    // Action button flags
    public void StartAction()
    {
        bAction = true;
        StartCoroutine(DelayedStopA());
    }
    IEnumerator DelayedStopA()
    {
        yield return new WaitForSeconds(0.1f);
        bAction = false;
        StopCoroutine(DelayedStopA());
    }

    // Baction (boosting / secondary) button flags
    //public void StartBoosting()
    //{
    //    thePlayer.bBoosting = true;
    //    bBaction = true;
    //}
    // DC TODO never used?
    //public void StopBoosting()
    //{
    //    thePlayer.bBoosting = false;
    //    bBaction = false;
    //}

    public void BAction()
    {
        bBaction = true;
    }

    // Xaction (zoom in) button flags
    public void XAction()
    {
        bXaction = true;
    }

    // Yaction (zoom out) button flags
    public void StartYAction()
    {
        bYaction = true;
    }

    // Movement / arrow button flags
    public void PressedLeftArrow()
    {
        bLeft = true;
    }
    public void UnpressedLeftArrow()
    {
        bLeft = false;
    }

    public void PressedRightArrow()
    {
        bRight = true;
    }
    public void UnpressedRightArrow()
    {
        bRight = false;
    }

    public void PressedUpArrow()
    {
        bUp = true;
    }
    public void UnpressedUpArrow()
    {
        bUp = false;
    }

    public void PressedDownArrow()
    {
        bDown = true;
    }
    public void UnpressedDownArrow()
    {
        bDown = false;
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
}
