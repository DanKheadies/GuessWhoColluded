﻿// CC 4.0 International License: Attribution--HolisticGaming.com--NonCommercial--ShareALike
// Authors: David W. Corso
// Start: 07/31/2018
// Last:  06/28/2019

using UnityEngine;
using UnityEngine.SceneManagement;

// Pause the game & bring up the menu
public class PauseGame : MonoBehaviour
{
    public DialogueManager dMan;
    public MovePauseMenuArrow movePArw;
    public OptionsManager oMan;
    public PlayerMovement pMove;
    public Scene scene;
    public TouchControls touches;
    public Transform controlsMenu;
    public Transform iconsMenu;
    public Transform pauseMenu;
    public Transform pauseTrans;
    public Transform soundMenu;

    public bool bPauseActive;
    public bool bPausing;

    void Start()
    {
        // Initializers
        controlsMenu = GameObject.Find("ControlsMenu").transform;
        dMan = FindObjectOfType<DialogueManager>();
        iconsMenu = GameObject.Find("IconsMenu").transform;
        movePArw = GameObject.Find("PauseMenu").GetComponent<MovePauseMenuArrow>();
        oMan = FindObjectOfType<OptionsManager>();
        pauseMenu = GameObject.Find("PauseMenu").transform;
        pauseTrans = GameObject.Find("PauseScreen").GetComponent<Transform>();
        pMove = FindObjectOfType<PlayerMovement>();
        soundMenu = GameObject.Find("SoundMenu").transform;
        touches = FindObjectOfType<TouchControls>();

        // Hide submenus to allow Update-Pause-Escape action
        controlsMenu.transform.localScale = Vector3.zero;
        iconsMenu.transform.localScale = Vector3.zero;
        soundMenu.transform.localScale = Vector3.zero;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) ||
            Input.GetKeyUp(KeyCode.JoystickButton7))
        {
            if (controlsMenu.transform.localScale == Vector3.one)
            {
                Controls(false);
            }
            else if (iconsMenu.transform.localScale == Vector3.one)
            {
                Icons(false);
            }
            else if (soundMenu.transform.localScale == Vector3.one)
            {
                Sound(false);
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pausing()
    {
        bPausing = true;
    }

    public void PausingDone()
    {
        bPausing = false;
    }

    public void Pause()
    {
        if (pauseTrans.localScale != Vector3.one)
        {
            controlsMenu.transform.localScale = Vector3.zero;
            iconsMenu.transform.localScale = Vector3.zero;
            pauseMenu.transform.localScale = Vector3.one;
            soundMenu.transform.localScale = Vector3.zero;

            pauseTrans.transform.localScale = Vector3.one;
            Time.timeScale = 0;

            bPausing = false;
            bPauseActive = true;
            pMove.bStopPlayerMovement = true;
        }
        else
        {
            oMan.bPauseOptions = true;
            pauseTrans.transform.localScale = Vector3.zero;
            Time.timeScale = 1;

            movePArw.ResetArrows();

            bPauseActive = false;

            if (oMan.bOptionsActive ||
                dMan.bDialogueActive)
            {
                pMove.bStopPlayerMovement = true;
            }
            else
            {
                pMove.bStopPlayerMovement = false;
            }
        }
    }

    public void Controls(bool bOpen)
    {
        if (bOpen)
        {
            controlsMenu.transform.localScale = Vector3.one;
            pauseMenu.transform.localScale = Vector3.zero;
        }
        else
        {
            controlsMenu.transform.localScale = Vector3.zero;
            pauseMenu.transform.localScale = Vector3.one;
        }
    }

    public void Icons(bool bOpen)
    {
        if (bOpen)
        {
            iconsMenu.transform.localScale = Vector3.one;
            pauseMenu.transform.localScale = Vector3.zero;
        }
        else
        {
            iconsMenu.transform.localScale = Vector3.zero;
            pauseMenu.transform.localScale = Vector3.one;
        }
    }

    public void Sound(bool bOpen)
    {
        if (bOpen)
        {
            soundMenu.transform.localScale = Vector3.one;
            pauseMenu.transform.localScale = Vector3.zero;
        }
        else
        {
            soundMenu.transform.localScale = Vector3.zero;
            pauseMenu.transform.localScale = Vector3.one;
        }
    }
}
