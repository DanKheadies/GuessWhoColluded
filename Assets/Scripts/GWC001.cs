// CC 4.0 International License: Attribution--HolisticGaming.com--NonCommercial--ShareALike
// Authors: David W. Corso
// Start: 07/31/2018
// Last:  03/28/2019

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
    public Characters chars;
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
    public SinglePlayerLogic spLogic;
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
    public bool bSingleReminder;
    public bool bStartGame;
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

    public int playerCharacter;
    public int opponentCharacter;

    public string teamName;
    public string oppName;

    public string[] dialogueLines;
    public string[] optionsLines;

    void Start()
    {
        // Initializers
        aUtil = FindObjectOfType<AspectUtility>();
        camFollow = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>();
        chars = GetComponent<Characters>();
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
        spLogic = FindObjectOfType<SinglePlayerLogic>();
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        touches = FindObjectOfType<TouchControls>();
        trumpCards = GameObject.Find("Trump Cards");
        uiMan = FindObjectOfType<UIManager>();

        charTiles = new CharacterTile[24];

        guessThreshold = 1.25f;
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

        GWC_PromptRestrictions();

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
            GWC_PromptRestrictions();

            dialogueLines = new string[] {
                "First and first mostly, who's playing?"
            };
            GWC_DialogueRestter();

            optionsLines = new string[] {
                "Me (Single player)",
                "Us (Multiplayer)"
            };
            GWC_OptionsResetter_2Q();
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

        // Single Player - Reminder to Guess
        if (bSingleReminder &&
            !dMan.bDialogueActive)
        {
            bSingleReminder = false;
            bAllowPlayerToGuess = true;

            GWC_PromptRestrictions();

            dialogueLines = new string[] {
                "And when you're ready, just hold down for a couple of seconds."
            };
            GWC_DialogueRestter();
        }

        // Single Player - Player Guess
        if (Input.GetMouseButton(0) &&
            bAllowPlayerToGuess &&
            !dMan.bDialogueActive)
        {
            buttonTimer += Time.deltaTime;

            if (buttonTimer >= guessThreshold &&
                !spLogic.bGuessingFTW)
            {
                if (spLogic.bPlayerMidGuess)
                {
                    spLogic.bPlayerGuessing = true;
                }
                else if (!bIsPlayerG2G)
                {
                    IsPlayerGoodToGuess();
                }
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

        GWC_PromptRestrictions();

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
            opponentCharacter = Random.Range(0, 23);
        }
        else if (bOppTrump)
        {
            oppName = "Trump";
            opponentCharacter = Random.Range(24, 47);
        }

        // Randomize Dialogue
        int randomInt = Random.Range(0, 3);
        if (randomInt == 0)
        {
            dialogueLines = new string[] {
                "Sure, I'll be Team " + oppName + ". Please, age before beauty..",
            };
        }
        else if (randomInt == 1)
        {
            dialogueLines = new string[] {
                "Good luck Team " + teamName + ", I'll go first...",
            };
        }
        else if (randomInt == 2)
        {
            dialogueLines = new string[] {
                "Alright Team " + oppName + ", it's you and your squad vs Me and the Revolution..",
            };
        }

        GWC_DialogueRestter();
        dPic.sprite = portPic[48];

        spLogic.bOppQ1 = true;
    }

    IEnumerator StartMulti()
    {
        yield return new WaitForSeconds(1.0f);

        GWC_PromptRestrictions();

        dialogueLines = new string[] {
                "Oh and don't forget about the Colluminac in the menu. GLHF"
            };
        GWC_DialogueRestter();
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

            GWC_PromptRestrictions();

            dialogueLines = new string[] {
                "Got it. Now more importantly, whose side are you on?"
            };
            GWC_DialogueRestter();

            optionsLines = new string[] {
                "Team Trump",
                "Team Mueller"
            };

            GWC_OptionsResetter_2Q();
        }

        // Dialogue 2 - Option 1 - Selected Trump
        else if (bOptTeamSelect &&
            moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt1)
        {
            bOptTeamSelect = false;
            bOptOppSelect = true;
            bTeamTrump = true;

            GWC_PromptRestrictions();

            dialogueLines = new string[] {
                "But what to do, what to do... Are you going to.."
            };
            GWC_DialogueRestter();

            optionsLines = new string[] {
                "Stop the leaks!",
                "End the witch hunt!"
            };

            GWC_OptionsResetter_2Q();
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
            playerCharacter = Random.Range(0, 23);
            dPic.sprite = portPic[playerCharacter];
            playerCard.gameObject.transform.GetChild(playerCharacter).localScale = Vector3.one;
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
            playerCharacter = Random.Range(24, 47);
            dPic.sprite = portPic[playerCharacter];
            playerCard.gameObject.transform.GetChild(playerCharacter).localScale = Vector3.one;
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
            playerCharacter = Random.Range(24, 47);
            dPic.sprite = portPic[playerCharacter];
            playerCard.gameObject.transform.GetChild(playerCharacter).localScale = Vector3.one;
        }

        // Single Player - Player Guess Check
        else if (bIsPlayerG2G)
        {
            if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt1)
            {
                spLogic.playerGuessNumber = spLogic.playerGuessNumber + 1;
                spLogic.bPlayerGuessing = true;
            }
            else if (moveOptsArw.currentPosition == MoveOptionsMenuArrow.ArrowPos.Opt2)
            {
                spLogic.bPlayerGuessing = false;
            }

            bIsPlayerG2G = false;

            oMan.ResetOptions();
        }
        
        if (spLogic.bGuessingTrait)
        {
            spLogic.TraitTree();
        }
        else if (!spLogic.bAvoidingQuickGuess)
        {
            spLogic.LogicTree();
        }
    }

    public void IsPlayerGoodToGuess()
    {
        bIsPlayerG2G = true;

        GWC_PromptRestrictions();

        dialogueLines = new string[] {
                "Would you like to guess?"
            };
        GWC_DialogueRestter();

        optionsLines = new string[] {
                "Yes",
                "No"
            };
        GWC_OptionsResetter_2Q();
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
        Debug.Log("gwc reset");
        // Hide current character card on Pause screen
        playerCard.gameObject.transform.GetChild(playerCharacter).localScale = Vector3.zero;

        bBoardReset = true;

        //oMan.ResetOptions();

        spLogic.ResetSingle();

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
            Debug.Log("m");
            // Stop tile flipping
            bCanFlip = false;

            dMan.dialogueLines = new string[] {
                "Time to find out who on Team Trump is colluding...",
                "And I better do it quickly."
            };
            GWC_DialogueRestter();

            bStartGame = true;

            // Pick random Mueller character for the player
            playerCharacter = Random.Range(0, 23);
            dPic.sprite = portPic[playerCharacter];
            playerCard.gameObject.transform.GetChild(playerCharacter).localScale = Vector3.one;
        }
        else if (bTeamTrump &&
                 bOppMueller)
        {
            Debug.Log("tm");
            // Stop tile flipping
            bCanFlip = false;

            dMan.dialogueLines = new string[] {
                "Time to find out who on Team Mueller is leading this witch hunt...",
                "And I better do it quickly."
            };
            GWC_DialogueRestter();

            bStartGame = true;

            // Pick random Trump character for the player
            playerCharacter = Random.Range(24, 47);
            dPic.sprite = portPic[playerCharacter];
            playerCard.gameObject.transform.GetChild(playerCharacter).localScale = Vector3.one;
        }
        else if (bTeamTrump &&
                 bOppTrump)
        {
            Debug.Log("tt");
            // Stop tile flipping
            bCanFlip = false;

            dMan.dialogueLines = new string[] {
                "Time to find out who on Team Trump is leaking information...",
                "And I better do it quickly."
            };
            GWC_DialogueRestter();

            bStartGame = true;

            // Pick random Trump character for the player
            playerCharacter = Random.Range(24, 47);
            dPic.sprite = portPic[playerCharacter];
            playerCard.gameObject.transform.GetChild(playerCharacter).localScale = Vector3.one;
        }
    }

    public void GWC_PromptRestrictions()
    {
        thePlayer.GetComponent<PlayerMovement>().bStopPlayerMovement = true;

        touches.transform.localScale = Vector3.zero;
    }

    public void GWC_DialogueRestter()
    {
        dMan.dialogueLines = dialogueLines;
        dMan.currentLine = 0;
        dText.text = dialogueLines[dMan.currentLine];
        dBox.transform.localScale = Vector3.one;
        dMan.bDialogueActive = true;
    }

    public void GWC_OptionsResetter_2Q()
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

    public void GWC_OptionsResetter_3Q()
    {
        for (int i = 0; i < optionsLines.Length; i++)
        {
            GameObject optText = GameObject.Find("Opt" + (i + 1) + "_Text");
            optText.GetComponentInChildren<Text>().text = optionsLines[i];
            oMan.tempOptsCount += 1;
        }

        oMan.bDiaToOpts = true;
        oMan.bOptionsActive = true;
        oMan.HideFourthOpt();
        oBox.transform.localScale = Vector3.one;
        oMan.PauseOptions();
    }

    public void GWC_OptionsResetter_4Q()
    {
        for (int i = 0; i < optionsLines.Length; i++)
        {
            GameObject optText = GameObject.Find("Opt" + (i + 1) + "_Text");
            optText.GetComponentInChildren<Text>().text = optionsLines[i];
            oMan.tempOptsCount += 1;
        }

        oMan.bDiaToOpts = true;
        oMan.bOptionsActive = true;
        oBox.transform.localScale = Vector3.one;
        oMan.PauseOptions();
    }
}
