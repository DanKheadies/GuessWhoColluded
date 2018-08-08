// CC 4.0 International License: Attribution--HolisticGaming.com--NonCommercial--ShareALike
// Authors: David W. Corso
// Start: 07/31/2018
// Last:  07/31/2018

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Contains 'key' GWC code
public class GWC001 : MonoBehaviour
{
    public Camera mainCamera;
    public CameraFollow camFollow;
    public DialogueManager dMan;
    public GameObject dArrow;
    public GameObject dBox;
    public GameObject sFaderAnim;
    public GameObject sFaderAnimDia;
    public GameObject thePlayer;
    public MoveOptionsMenuArrow moveOptsArw;
    public MusicManager mMan;
    public OptionsManager oMan;
    public SaveGame save;
    public Text dText;
    public UIManager uiMan;

    private bool bAvoidUpdate;

    public float timer;

    void Start()
    {
        // Initializers
        camFollow = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>();
        dArrow = GameObject.Find("Dialogue_Arrow");
        dBox = GameObject.Find("Dialogue_Box");
        dMan = FindObjectOfType<DialogueManager>();
        dText = GameObject.Find("Dialogue_Text").GetComponent<Text>();
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        moveOptsArw = FindObjectOfType<MoveOptionsMenuArrow>();
        mMan = FindObjectOfType<MusicManager>();
        oMan = GameObject.FindObjectOfType<OptionsManager>();
        save = FindObjectOfType<SaveGame>();
        sFaderAnim = GameObject.Find("Screen_Fader");
        sFaderAnimDia = GameObject.Find("Screen_Fader_Dialogue");
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        uiMan = FindObjectOfType<UIManager>();
        
        timer = 0.333f;
    }

    void Update()
    {
        if (!bAvoidUpdate)
        {

            mMan.bMusicCanPlay = true;
            sFaderAnim.GetComponent<Animator>().enabled = true;
            sFaderAnimDia.GetComponent<Animator>().enabled = true;

            // Change to avoid running this logic
            bAvoidUpdate = true;
        }
    }
}
