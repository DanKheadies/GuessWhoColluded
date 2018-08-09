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
    public AspectUtility aUtil;
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
    public TouchControls touches;
    public UIManager uiMan;

    private bool bAvoidUpdate;

    public float timer;

    void Start()
    {
        // Initializers
        aUtil = FindObjectOfType<AspectUtility>();
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
        touches = GameObject.FindObjectOfType<TouchControls>();
        uiMan = FindObjectOfType<UIManager>();
        
        timer = 0.333f;

        // min cam size: 1.142857 / aspect_ratio
        // max cam size: 5.5
        // max cam posi: (4.98, -3)
        // starting cam: max
        // player start: (0, 0)
        // player scale: (1.05, 1.05)
        // 
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
        
        if (Input.GetAxis("Mouse ScrollWheel") > 0 &&
            mainCamera.orthographicSize >= aUtil._wantedAspectRatio)
        {
            mainCamera.orthographicSize = mainCamera.orthographicSize - 0.25f;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0 &&
           mainCamera.orthographicSize < 5.5f)
        {
            mainCamera.orthographicSize = mainCamera.orthographicSize + 0.25f;
        }

        if (touches.bXaction &&
            mainCamera.orthographicSize >= aUtil._wantedAspectRatio)
        {
            mainCamera.orthographicSize = mainCamera.orthographicSize - 0.25f;
            touches.bXaction = false;
        }

        if (touches.bYaction &&
           mainCamera.orthographicSize < 5.5f)
        {
            mainCamera.orthographicSize = mainCamera.orthographicSize + 0.25f;
            touches.bYaction = false;
        }



        
    }
}
