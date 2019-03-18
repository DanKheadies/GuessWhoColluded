// CC 4.0 International License: Attribution--HolisticGaming.com--NonCommercial--ShareALike
// Authors: David W. Corso
// Start: 07/31/2018
// Last:  03/15/2019

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// Contains 'key' GWC code
public class GWC001 : MonoBehaviour
{
    public AspectUtility aUtil;
    public CharacterTile[] charTiles;
    public Camera mainCamera;
    public CameraFollow camFollow;
    public DialogueManager dMan;
    public GameObject dBox;
    public GameObject guiConts;
    public GameObject HUD;
    public GameObject muellerCards;
    public GameObject pauseBtn;
    public GameObject oBox;
    public GameObject playerCard;
    public GameObject sFaderAnim;
    public GameObject sFaderAnimDia;
    public GameObject thePlayer;
    public GameObject trumpCards;
    public Image dPic;
    public ImageStrobe dArrow;
    public MoveOptionsMenuArrow moveOptsArw;
    public MusicManager mMan;
    public OptionsManager oMan;
    public SaveGame save;
    public SFXManager SFXMan;
    public Sprite[] portPic;
    public Text dText;
    public TouchControls touches;
    public UIManager uiMan;

    public bool bAllowPlayerToGuess;
    public bool bAvoidUpdate;
    public bool bBoardReset;
    public bool bCanFlip;
    public bool bIsPlayerG2G;
    public bool bOppMueller;
    public bool bOppTrump;
    public bool bOptModeSelect;
    public bool bOptModeSingle;
    public bool bOptModeMulti;
    public bool bOptTeamSelect;
    public bool bOptOppSelect;
    public bool bOppQ1;
    public bool bOppQ2;
    public bool bOppQ3;
    public bool bOppQ4;
    public bool bOppQ5;
    public bool bOppQ6;
    public bool bPlayerGuessing;
    public bool bPlayQ1;
    public bool bPlayQ2;
    public bool bPlayQ3;
    public bool bPlayQ4;
    public bool bPlayQ5;
    public bool bPlayQ6;
    public bool bSingleReminder;
    public bool bStartGame;
    public bool bStartSingle;
    public bool bTeamMueller;
    public bool bTeamTrump;

    public float buttonTimer;
    public float guessDownTime;
    public float guessUpTime;
    public float guessPressedTime;
    public float guessThreshold;
    public float musicTimer1;
    public float musicTimer2;
    public float strobeTimer;

    public int playerGuessNumber;
    public int randomCharacter;

    public string pAnswer;
    public string teamName;
    public string oppName;

    public string[] dialogueLines;
    public string[] optionsLines;

    void Start()
    {
        // Initializers
        aUtil = FindObjectOfType<AspectUtility>();
        camFollow = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>();
        dArrow = GameObject.Find("Dialogue_Arrow").GetComponent<ImageStrobe>();
        dBox = GameObject.Find("Dialogue_Box");
        dMan = FindObjectOfType<DialogueManager>();
        dPic = GameObject.Find("Dialogue_Picture").GetComponent<Image>();
        dText = GameObject.Find("Dialogue_Text").GetComponent<Text>();
        guiConts = GameObject.Find("GUIControls");
        HUD = GameObject.Find("HUD");
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        mMan = FindObjectOfType<MusicManager>();
        moveOptsArw = FindObjectOfType<MoveOptionsMenuArrow>();
        muellerCards = GameObject.Find("Mueller Cards");
        oBox = GameObject.Find("Options_Box");
        oMan = FindObjectOfType<OptionsManager>();
        pauseBtn = GameObject.Find("Pause_Button");
        playerCard = GameObject.Find("Player_Character_Card");
        save = FindObjectOfType<SaveGame>();
        sFaderAnim = GameObject.Find("Screen_Fader");
        sFaderAnimDia = GameObject.Find("Screen_Fader_Dialogue");
        SFXMan = FindObjectOfType<SFXManager>();
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        touches = FindObjectOfType<TouchControls>();
        trumpCards = GameObject.Find("Trump Cards");
        uiMan = FindObjectOfType<UIManager>();

        charTiles = new CharacterTile[24];

        guessThreshold = 3.0f;
        musicTimer1 = 5.39f;
        musicTimer2 = 1.05f;
        strobeTimer = 1.0f;

        // Trump Dialogue
        //dialogueLines = new string[] {
        //        "There was no collusion. Everybody knows there was no collusion.",
        //        "The Fake News, the Disgusting Democrats, and the Deep State would say different."
        //    };

        // Initial prompt to pick a mode
        dMan.bDialogueActive = false;
        guiConts.transform.localScale = Vector3.zero;
        pauseBtn.transform.localScale = Vector3.zero;
        mMan.bMusicCanPlay = false;

        HMB_PromptRestrictions();

        dialogueLines = new string[] {
                "I want YOU.. to         Guess Who Colluded."
            };

        dMan.dialogueLines = dialogueLines;
        dMan.currentLine = 0;
        dText.text = dialogueLines[dMan.currentLine];
        dPic.sprite = portPic[48];
        dBox.transform.localScale = Vector3.one;
        sFaderAnimDia.GetComponent<Animator>().enabled = true;
    }

    void Update()
    {
        // New Game -- Dialogue activation & strobe arrow start
        if (strobeTimer > 0)
        {
            strobeTimer -= Time.deltaTime;

            if (strobeTimer <= 0)
            {
                bOptModeSelect = true;
                StartCoroutine(dArrow.Strobe());
                dMan.bDialogueActive = true;
                sFaderAnimDia.transform.localScale = Vector3.zero; // Remove to allow mouse click on options prompts

                // Sound Effect
                SFXMan.sounds[2].PlayOneShot(SFXMan.sounds[2].clip);
            }
        }

        if (bOptModeSelect &&
            !dMan.bDialogueActive)
        {
            HMB_PromptRestrictions();

            dialogueLines = new string[] {
                "First and first mostly, who's playing?"
            };
            HMB_DialogueRestter();

            optionsLines = new string[] {
                "Me (Single player)",
                "Us (Multiplayer)"
            };
            HMB_OptionsResetter_2Q();
        }

        // Begin play -- Activate music, UI, and fade after team selection
        if (!dMan.bDialogueActive &&
            !bAvoidUpdate &&
            bStartGame)
        {
            thePlayer.GetComponent<PlayerMovement>().bStopPlayerMovement = false;
            guiConts.transform.localScale = Vector3.one;
            pauseBtn.transform.localScale = Vector3.one;
            mMan.bMusicCanPlay = true;
            sFaderAnim.GetComponent<Animator>().enabled = true;

            // Change to avoid running this logic
            bAvoidUpdate = true;

            // Allow tile flipping
            StartCoroutine(StartFlipping());

            // Mode Reminders
            if (bOptModeMulti)
            {
                StartCoroutine(StartMulti());
            }
            if (bOptModeSingle)
            {
                StartCoroutine(StartSingle());
            }
        }

        // Change from first music track to second
        if (!dMan.bDialogueActive &&
            bStartGame &&
            musicTimer1 > 0)
        {
            musicTimer1 -= Time.deltaTime;

            if (musicTimer1 <= 0)
            {
                mMan.SwitchTrack(1);
            }
        }

        // Change from second music track to third
        if (musicTimer1 <= 0 &&
            musicTimer2 > 0)
        {
            musicTimer2 -= Time.deltaTime;

            if (musicTimer2 <= 0)
            {
                mMan.SwitchTrack(2);
            }
        }

        // Resetting
        if (!dMan.bDialogueActive &&
            bBoardReset &&
            !bCanFlip)
        {
            // Change to avoid running this logic
            bBoardReset = false;

            // Allow tile flipping
            bCanFlip = true;
        }

        // Zoom In -- Scroll Forward or press Y
        if ((Input.GetAxis("Mouse ScrollWheel") > 0 &&
             mainCamera.orthographicSize >= aUtil._wantedAspectRatio) ||
            (Input.GetKeyDown(KeyCode.Comma) &&
             mainCamera.orthographicSize >= aUtil._wantedAspectRatio) ||
            (Input.GetKeyDown(KeyCode.JoystickButton3) &&
             mainCamera.orthographicSize >= aUtil._wantedAspectRatio) ||
            (touches.bYaction &&
             mainCamera.orthographicSize >= aUtil._wantedAspectRatio))
        {
            mainCamera.orthographicSize = mainCamera.orthographicSize - 0.25f;
            touches.bYaction = false;
        }

        // Zoom Out -- Scroll Back or press X
        if ((Input.GetAxis("Mouse ScrollWheel") < 0 &&
             mainCamera.orthographicSize < 5.5f) ||
            (Input.GetKeyDown(KeyCode.Period) &&
             mainCamera.orthographicSize < 5.5f) ||
            (Input.GetKeyDown(KeyCode.JoystickButton2) &&
             mainCamera.orthographicSize < 5.5f) ||
            (touches.bXaction &&
             mainCamera.orthographicSize < 5.5f))
        {
            mainCamera.orthographicSize = mainCamera.orthographicSize + 0.25f;
            touches.bXaction = false;
        }

        // Single Player - Opponent's First Guess
        if (bStartSingle &&
            !dMan.bDialogueActive)
        {
            bStartSingle = false;
            bOppQ1 = true;

            HMB_PromptRestrictions();

            dialogueLines = new string[] {
                "Are you a man?"
            };
            HMB_DialogueRestter();

            optionsLines = new string[] {
                "Yes",
                "No"
            };
            HMB_OptionsResetter_2Q();
        }

        // Single Player - Reminder to Guess
        if (bSingleReminder &&
            !dMan.bDialogueActive)
        {
            bSingleReminder = false;
            bAllowPlayerToGuess = true;

            HMB_PromptRestrictions();

            dialogueLines = new string[] {
                "Oh and when you're ready to guess, just hold down for 3 seconds."
            };
            HMB_DialogueRestter();
        }

        // Single Player - Player's First Guess
        if (bPlayerGuessing &&
            playerGuessNumber == 1 &&
            !dMan.bDialogueActive)
        {
            bPlayerGuessing = false;
            bPlayQ1 = true;

            HMB_PromptRestrictions();

            dialogueLines = new string[] {
                "Hmmm..."
            };
            HMB_DialogueRestter();

            // The meat of the logic tree
            // Will want to know what team player is on & against (worked in WH vs on MIT)
            // Keep track of what has been asked
            // Allow user to select a character (or hold down again cancel)
            optionsLines = new string[] {
                "Are you wearing red?",
                "Are you a female?",
                "You work in the white house?",
                "I know who it is!"
            };
            HMB_OptionsResetter_4Q();
        }

        // Single Player - Player Guess
        if (Input.GetMouseButton(0) &&
            bAllowPlayerToGuess &&
            !dMan.bDialogueActive)
        {
            buttonTimer += Time.deltaTime;

            if (buttonTimer >= guessThreshold &&
                !bIsPlayerG2G)
            {
                IsPlayerGoodToGuess();
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            buttonTimer = 0;
        }
    }

    IEnumerator StartFlipping()
    {
        yield return new WaitForSeconds(1.0f);
        
        bCanFlip = true;
    }

    IEnumerator StartSingle()
    {
        yield return new WaitForSeconds(1.0f);

        HMB_PromptRestrictions();

        if (bTeamMueller)
        {
            teamName = "Mueller";
        }
        else if (bTeamTrump)
        {
            teamName = "Trump";
        }

        if (bOppMueller)
        {
            oppName = "Mueller";
        }
        else if (bOppTrump)
        {
            oppName = "Trump";
        }

        dialogueLines = new string[] {
                "As Team " + teamName + ", I'll go first...",
            };
        HMB_DialogueRestter();
        dPic.sprite = portPic[48];

        bStartSingle = true;
    }

    IEnumerator StartMulti()
    {
        yield return new WaitForSeconds(1.0f);

        HMB_PromptRestrictions();

        dialogueLines = new string[] {
                "Oh and don't forget about the Colluminac in the menu. GLHF"
            };
        HMB_DialogueRestter();
        dPic.sprite = portPic[48];
    }

    public void OptionsSelection()
    {
        // Dialogue 1 - Option * - Selected Mode
        if (bOptModeSelect &&
           (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt1 ||
            moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt2))
        {
            bOptModeSelect = false;
            bOptTeamSelect = true;

            // Selected Single Player
            if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt1)
            {
                bOptModeSingle = true;
            }
            // Selected Multi Player
            else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt2)
            {
                bOptModeMulti = true;
            }

            HMB_PromptRestrictions();

            dialogueLines = new string[] {
                "Got it. Now more importantly, whose side are you on?"
            };
            HMB_DialogueRestter();

            optionsLines = new string[] {
                "Team Trump",
                "Team Mueller"
            };

            HMB_OptionsResetter_2Q();
        }

        // Dialogue 2 - Option 1 - Selected Trump
        else if (bOptTeamSelect &&
            moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt1)
        {
            bOptTeamSelect = false;
            bOptOppSelect = true;
            bTeamTrump = true;

            HMB_PromptRestrictions();

            dialogueLines = new string[] {
                "But what to do, what to do... Are you going to.."
            };
            HMB_DialogueRestter();

            optionsLines = new string[] {
                "Stop the leaks!",
                "End the witch hunt!"
            };

            HMB_OptionsResetter_2Q();
        }

        // Dialogue 2 - Option 2 - Selected Mueller
        else if (bOptTeamSelect &&
                 moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt2)
        {
            bOppTrump = true;
            bOptTeamSelect = false;
            bTeamMueller = true;

            oMan.ResetOptions();

            // Display Trump board
            trumpCards.transform.localScale = Vector3.one;

            // 'Store' Trump board
            for (int i = 0; i < 24; i++)
            {
                charTiles[i] = trumpCards.transform.GetChild(i).GetComponent<CharacterTile>();
            }

            dMan.dialogueLines = new string[] {
                "Time to find out who on Team Trump is colluding...",
                "And I better do it quickly."
            };
            dMan.currentLine = 0;
            dText.text = dMan.dialogueLines[dMan.currentLine];
            dMan.ShowDialogue();

            bStartGame = true;

            // Pick random Mueller character for the player
            randomCharacter = Random.Range(0, 23);
            dPic.sprite = portPic[randomCharacter];
            playerCard.gameObject.transform.GetChild(randomCharacter).localScale = Vector3.one;
        }

        // Dialogue 3 - Option 1 - Selected Trump (and very Fine People)
        else if (bOptOppSelect &&
                 moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt1)
        {
            bOppTrump = true;
            bOptOppSelect = false;
            bOptTeamSelect = false;

            oMan.ResetOptions();

            // Display Trump board
            trumpCards.transform.localScale = Vector3.one;

            // 'Store' Trump board
            for (int i = 0; i < 24; i++)
            {
                charTiles[i] = trumpCards.transform.GetChild(i).GetComponent<CharacterTile>();
            }

            dMan.dialogueLines = new string[] {
                "Time to find out who on Team Trump is leaking information...",
                "And I better do it quickly."
            };
            dMan.currentLine = 0;
            dText.text = dMan.dialogueLines[dMan.currentLine];
            dMan.ShowDialogue();

            bStartGame = true;

            // Pick random Trump character for the player
            randomCharacter = Random.Range(24, 47);
            dPic.sprite = portPic[randomCharacter];
            playerCard.gameObject.transform.GetChild(randomCharacter).localScale = Vector3.one;
        }

        // Dialogue 3 - Option 2 - Selected Mueller (and the Fake News)
        else if (bOptOppSelect &&
                 moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt2)
        {
            bOppMueller = true;
            bOptOppSelect = false;
            bOptTeamSelect = false;

            oMan.ResetOptions();

            // Display Mueller board
            muellerCards.transform.localScale = Vector3.one;

            // 'Store' Mueller board
            for (int i = 0; i < 24; i++)
            {
                charTiles[i] = muellerCards.transform.GetChild(i).GetComponent<CharacterTile>();
            }

            dMan.dialogueLines = new string[] {
                "Time to find out who on Team Mueller is leading this witch hunt...",
                "And I better do it quickly."
            };
            dMan.currentLine = 0;
            dText.text = dMan.dialogueLines[dMan.currentLine];
            dMan.ShowDialogue();

            bStartGame = true;

            // Pick random Trump character for the player
            randomCharacter = Random.Range(24, 47);
            dPic.sprite = portPic[randomCharacter];
            playerCard.gameObject.transform.GetChild(randomCharacter).localScale = Vector3.one;
        }

        // Single Player - Player Guess Check
        else if (bIsPlayerG2G)
        {
            if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt1)
            {
                playerGuessNumber = playerGuessNumber + 1;
                bPlayerGuessing = true;
            }
            else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt2)
            {
                bPlayerGuessing = false;
            }

            bIsPlayerG2G = false;

            oMan.ResetOptions();
        }

        // Single Player - Opponent Question 1 
        else if (bOppQ1)
        {
            if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt1)
            {
                pAnswer = "yes";
            }
            else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt2)
            {
                pAnswer = "no";
            }

            bOppQ1 = false;
            bSingleReminder = true;

            oMan.ResetOptions();
        }

        // Single Player - Opponent Question 1 
        else if (bPlayQ1)
        {
            if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt1)
            {
                // "Are you wearing red?";
            }
            else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt2)
            {
                // "Are you a female?"
            }
            else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt3)
            {
                // "Do or did you work in the white house?"
            }
            else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt4)
            {
                // "I know who it is!"
            }

            bPlayQ1 = false;

            oMan.ResetOptions();
        }
    }

    public void IsPlayerGoodToGuess()
    {
        bIsPlayerG2G = true;

        HMB_PromptRestrictions();

        dialogueLines = new string[] {
                "Would you like to guess?"
            };
        HMB_DialogueRestter();
        //dPic.sprite = portPic[48];

        optionsLines = new string[] {
                "Yes",
                "No"
            };
        HMB_OptionsResetter_2Q();
    }

    public void OpenColluminac()
    {
        #if !UNITY_WEBGL
            Application.OpenURL("http://guesswhocolluded.com/colluminac.html");
        #endif
    }

    public void OpenCharacters()
    {
        #if !UNITY_WEBGL
                Application.OpenURL("http://guesswhocolluded.com/colluminac.html#characters");
        #endif
    }

    public void ResetBoard()
    {
        // Hide current character card on Pause screen
        playerCard.gameObject.transform.GetChild(randomCharacter).localScale = Vector3.zero;

        bBoardReset = true;

        if (bOppMueller)
        {
            // Turn over tiles
            for (int i = 0; i < 24; i++)
            {
                charTiles[i] = muellerCards.transform.GetChild(i).GetComponent<CharacterTile>();
                charTiles[i].ShowFront();
            }
        }

        if (bOppTrump)
        {
            // Turn over tiles
            for (int i = 0; i < 24; i++)
            {
                charTiles[i] = trumpCards.transform.GetChild(i).GetComponent<CharacterTile>();
                charTiles[i].ShowFront();
            }
        }

        if (bTeamMueller)
        {
            // Stop tile flipping
            bCanFlip = false;

            dMan.dialogueLines = new string[] {
                "Time to find out who on Team Trump is colluding...",
                "And I better do it quickly."
            };
            dMan.currentLine = 0;
            dText.text = dMan.dialogueLines[dMan.currentLine];
            dMan.ShowDialogue();

            bStartGame = true;

            // Pick random Mueller character for the player
            randomCharacter = Random.Range(0, 23);
            dPic.sprite = portPic[randomCharacter];
            playerCard.gameObject.transform.GetChild(randomCharacter).localScale = Vector3.one;
        }
        else if (bTeamTrump &&
                 bOppMueller)
        {
            // Stop tile flipping
            bCanFlip = false;

            dMan.dialogueLines = new string[] {
                "Time to find out who on Team Mueller is leading this witch hunt...",
                "And I better do it quickly."
            };
            dMan.currentLine = 0;
            dText.text = dMan.dialogueLines[dMan.currentLine];
            dMan.ShowDialogue();

            bStartGame = true;

            // Pick random Trump character for the player
            randomCharacter = Random.Range(24, 47);
            dPic.sprite = portPic[randomCharacter];
            playerCard.gameObject.transform.GetChild(randomCharacter).localScale = Vector3.one;
        }
        else if (bTeamTrump &&
                 bOppTrump)
        {
            // Stop tile flipping
            bCanFlip = false;

            dMan.dialogueLines = new string[] {
                "Time to find out who on Team Trump is leaking information...",
                "And I better do it quickly."
            };
            dMan.currentLine = 0;
            dText.text = dMan.dialogueLines[dMan.currentLine];
            dMan.ShowDialogue();

            bStartGame = true;

            // Pick random Trump character for the player
            randomCharacter = Random.Range(24, 47);
            dPic.sprite = portPic[randomCharacter];
            playerCard.gameObject.transform.GetChild(randomCharacter).localScale = Vector3.one;
        }
    }

    public void HMB_PromptRestrictions()
    {
        thePlayer.GetComponent<PlayerMovement>().bStopPlayerMovement = true;

        touches.transform.localScale = Vector3.zero;
    }

    public void HMB_DialogueRestter()
    {
        dMan.dialogueLines = dialogueLines;
        dMan.currentLine = 0;
        dText.text = dialogueLines[dMan.currentLine];
        dBox.transform.localScale = Vector3.one;
        dMan.bDialogueActive = true;
    }

    public void HMB_OptionsResetter_2Q()
    {
        for (int i = 0; i < optionsLines.Length; i++)
        {
            GameObject optText = GameObject.Find("Opt" + (i + 1) + "_Text");
            optText.GetComponentInChildren<Text>().text = optionsLines[i];
            oMan.tempOptsCount += 1;
        }

        oMan.bDiaToOpts = true;
        oMan.bOptionsActive = true;
        oMan.HideThirdPlusOpt();
        oBox.transform.localScale = Vector3.one;
        oMan.PauseOptions();
    }

    public void HMB_OptionsResetter_4Q()
    {
        for (int i = 0; i < optionsLines.Length; i++)
        {
            GameObject optText = GameObject.Find("Opt" + (i + 1) + "_Text");
            optText.GetComponentInChildren<Text>().text = optionsLines[i];
            oMan.tempOptsCount += 1;
        }

        oMan.bDiaToOpts = true;
        oMan.bOptionsActive = true;
        //oMan.HideThirdPlusOpt();
        oBox.transform.localScale = Vector3.one;
        oMan.PauseOptions();
    }
}
