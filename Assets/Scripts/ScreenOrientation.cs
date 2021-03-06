﻿// CC 4.0 International License: Attribution--HolisticGaming.com--NonCommercial--ShareALike
// Authors: David W. Corso
// Start: 07/29/2018
// Last:  03/15/2019

using UnityEngine;

// Checks orientation and refreshes screen / controls
public class ScreenOrientation : MonoBehaviour
{
    public AspectUtility aspectUtil;
    public DialogueManager dMan;
    public DeviceOrientation devOr;
    public OptionsManager oMan;
    public UIManager uMan;

    public bool bIsFull;
    public bool bSizingChange;

    void Start()
    {
        // Initializers
        aspectUtil = GetComponent<AspectUtility>();
        devOr = Input.deviceOrientation;
        dMan = FindObjectOfType<DialogueManager>();
        oMan = FindObjectOfType<OptionsManager>();
        uMan = FindObjectOfType<UIManager>();

        bIsFull = Screen.fullScreen;
        bSizingChange = false;
    }

    void Update()
    {
        if (Input.deviceOrientation != devOr ||
            Screen.autorotateToLandscapeLeft ||
            Screen.autorotateToLandscapeRight ||
            Screen.autorotateToPortrait ||
            Screen.autorotateToPortraitUpsideDown ||
            bSizingChange)
        {
            ResetParameters();

            bSizingChange = false;
        }

        if (bIsFull != Screen.fullScreen)
        {
            bIsFull = Screen.fullScreen;
            bSizingChange = true;
        }
    }

    public void ResetParameters()
    {
        aspectUtil.Awake();
        dMan.ConfigureParameters();
        oMan.ConfigureParameters();
        uMan.CheckAndSetMenus();
    }
}
